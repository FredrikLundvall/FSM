using System;
using System.Collections.Generic;
using System.Text;

namespace FsmAssembly
{
    public class State
    {
        public readonly FsmBase Parent;
        public readonly string Name;
        public readonly int PositionY;
        public readonly string AssociatedValue;
        public readonly bool Removable = false;
        private volatile float _threshold;
        private volatile float _amplificationOfState;
        private readonly List<InputConnection> _inputConnectionList;
        private readonly StateEvent[] _stateEvent = { new StateEvent(), new StateEvent(), new StateEvent() };
        //For balancing
        private volatile float _balanceLastInput = 0;
        private volatile bool _balanceNextState = false;
        private volatile int _balanceLastTimeUsed = 0;

        public State(FsmBase parent, string name, int positionY, string associatedValue, bool removable = true, float threshold = 1, float amplificationOfState = 1)
        {
            Parent = parent;
            Name = name;
            PositionY = positionY;
            AssociatedValue = associatedValue;
            Removable = removable;
            _threshold = threshold;
            _amplificationOfState = amplificationOfState;
            _inputConnectionList = new List<InputConnection>();
        }
        public void AddInputConnection(State outputFromState, StateEventEnum outputEvent, float bias, float decay)
        {
            _inputConnectionList.Add(new InputConnection(this, outputFromState, outputEvent, bias, decay));
        }
        public void AddOutputConnection(State inputToState, StateEventEnum outputEvent, float bias, float decay)
        {
            inputToState._inputConnectionList.Add(new InputConnection(inputToState, this, outputEvent, bias, decay));
        }
        public bool HasOutputConnectionToFsm(FsmBase fsm)
        {
            return fsm.HasInputConnectionFromState(this);
        }
        public bool HasInputConnectionFromState(State state)
        {
            foreach (InputConnection inputConnection in _inputConnectionList)
            {
                if (inputConnection.OutputFromState == state)
                    return true;
            }
            return false;
        }
        public float CalculateEventSignal(StateEventEnum outputEvent, float inputDecay)
        {
            return _stateEvent[Convert.ToInt32(outputEvent)].CurrentEventSignal.CalulateSignal(inputDecay) * _amplificationOfState;
        }
        public float CalculateCurrentInputSignal()
        {
            float currentInput = -_threshold;
            foreach (InputConnection inputConnection in _inputConnectionList)
            {
                float signal = inputConnection.CalculateSignal();
                inputConnection.SetBalanceLastSignal(signal);
                currentInput += signal;
            }
            return currentInput;
        }
        public void TriggerEvent(StateEventEnum triggeredEvent)
        {
            //gc-warning: using struct for EventOutput
            _stateEvent[Convert.ToInt32(triggeredEvent)].CurrentEventSignal = new EventSignal(VirtualTime.GetCurrentTime(), _stateEvent[Convert.ToInt32(triggeredEvent)].CurrentEventSetting);
        }

        //For balancing
        public void SetBalanceLastInput(float balanceLastInput)
        {
            _balanceLastInput = balanceLastInput;
        }
        public void SetBalanceNextState(bool balanceNextState)
        {
            _balanceNextState = balanceNextState;
        }
        public void SetBalanceLastTimeUsed(int balanceLastTimeUsed)
        {
            _balanceLastTimeUsed = balanceLastTimeUsed;
        }
        public void BalanceWeightings()
        {
            foreach (InputConnection inputConnection in _inputConnectionList)
            {
                if( (_balanceNextState && inputConnection.GetBalanceLastSignal() > 0) ||
                     (!_balanceNextState && inputConnection.GetBalanceLastSignal() < 0))
                    inputConnection.StrengthenConnection(1.1f);
            }
        }
        public void ResetStatisticsForBalance()
        {
            _balanceLastInput = 0;
            _balanceNextState = false;
            foreach (InputConnection inputConnection in _inputConnectionList)
            {
                inputConnection.SetBalanceLastSignal(0);
            }
        }
    }
}
