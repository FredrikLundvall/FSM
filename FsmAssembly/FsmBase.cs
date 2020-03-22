using System;
using System.Collections.Generic;
using System.Text;

namespace FsmAssembly
{
    abstract public class FsmBase
    {
        protected readonly Dictionary<string,State> _stateList;
        public readonly FsmEnsemble Parent;
        public readonly string Name;
        public readonly int PositionX;
        private volatile int _currentPositionY;
        protected volatile State _currentState = null;
        protected volatile State _nextState = null;

        public FsmBase(FsmEnsemble parent, string name, int positionX)
        {
            Parent = parent;
            Name = name;
            PositionX = positionX;
            _stateList = new Dictionary<string, State>();
            _currentState = null;
        }
        protected State AddState(string name = "", string value = "")
        {
            if (name == "")
            {
                name = Parent.Parent.NameGenerator.GenerateStateName();
                if (value == "")
                    value = $"{_currentPositionY:d10}";
            }
            State state = null;
            if (! _stateList.TryGetValue(value, out state))
            {
                state = new State(this, name, _currentPositionY++, value);
                _stateList.Add(value, state);
            }
            return state;
        }
        protected void BaseReceiveSignalFrom(FsmBase fsm)
        {
            fsm.BaseSendSignalTo(this);
        }
        protected void BaseSendSignalTo(FsmBase fsm)
        {
            //Add triggers for all states to different states (no competetion between states from same fsm)
            foreach (State state in _stateList.Values)
            {
                State notConnectedState = fsm.FindStateWithoutOutputConnectionToFsm(this);
                if (notConnectedState == null)
                    notConnectedState = fsm.AddState("", state.AssociatedValue);
                state.AddOutputConnection(notConnectedState, StateEventEnum.Remain, 1.0f, 0.0f);
            }
        }
        protected State FindStateWithoutOutputConnectionToFsm(FsmBase fsm)
        {
            State notConnectedState = null;
            foreach (State state in _stateList.Values)
            {
                if (!state.HasOutputConnectionToFsm(fsm))
                {
                    notConnectedState = state;
                    break;
                }
            }
            return notConnectedState;
        }
        public bool HasInputConnectionFromState(State OutputtingState)
        {
            foreach (State state in _stateList.Values)
            {
                if (state.HasInputConnectionFromState(OutputtingState))
                {
                    return true;
                }
            }
            return false;
        }
        virtual public void EvaluateNextState()
        {
            //Check state with highest input
            float highestInput = float.MinValue;
            State highestState = null;
            foreach (State state in _stateList.Values)
            {
                float input = state.CalculateCurrentInputSignal();
                //Add info in all states about input (for balancing)
                state.SetBalanceLastInput(input);
                if (input <= 0)
                    continue;
                if (input > highestInput)
                {
                    highestInput = input;
                    highestState = state;
                }
                else if (input == highestInput)
                {
                    highestInput = input;
                    if (highestState == null || state.PositionY < highestState.PositionY)
                        highestState = state;
                }
            }
            _nextState = highestState;
            //Add info in state that was next state (for balancing)
            _nextState.SetBalanceNextState(true);
            _nextState.SetBalanceLastTimeUsed(VirtualTime.GetCurrentTime());
        }
        virtual public void ExecuteTriggers()
        {
            if (_nextState == null)
                return;
            if (_nextState == _currentState)
                _nextState.TriggerEvent(StateEventEnum.Remain);
            else
            {
                _currentState.TriggerEvent(StateEventEnum.Exit);
                _nextState.TriggerEvent(StateEventEnum.Entry);
                _currentState = _nextState;
            }
            _nextState = null;
        }
        public void BalanceWeightings()
        {
            foreach (State state in _stateList.Values)
            {
                state.BalanceWeightings();
            }
        }
        public void ResetStatisticsForBalance()
        {
            foreach (State state in _stateList.Values)
            {
                state.ResetStatisticsForBalance();
            }
        }
    }
}
