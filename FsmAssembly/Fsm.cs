using System;
using System.Collections.Generic;
using System.Text;

namespace FsmAssembly
{
    public class Fsm : FsmBase
    {
        public Fsm(FsmEnsemble parent, string name, int positionX) : base(parent, name, positionX)
        {
        }

        public State AddState()
        {
            return base.AddState("", "");
        }
        public void ReceiveSignalFrom(FsmBase fsm)
        {
            base.BaseReceiveSignalFrom(fsm);
        }
        public void SendSignalTo(FsmBase fsm)
        {
            base.BaseSendSignalTo(fsm);
        }
    }
    //public class Fsm
    //{
    //    private readonly List<State> _stateList;
    //    public readonly FsmEnsemble Parent;
    //    public readonly string Name;
    //    public readonly int PositionX;
    //    public readonly bool Removable = false;
    //    public readonly SignalDirectionEnum SignalDirection = SignalDirectionEnum.InputOutput;
    //    public readonly bool FixedNumberOfStates = false;
    //    public readonly bool SelfRegulated = true;
    //    private volatile State _currentState = null;
    //    private volatile State _nextState = null;
    //    public Fsm(FsmEnsemble parent, string name, int positionX, bool addIdleState = false, bool removable = true, SignalDirectionEnum signalDirection = SignalDirectionEnum.InputOutput, bool fixedNumberOfStates = false, bool selfRegulated = true)
    //    {
    //        Parent = parent;
    //        Name = name;
    //        PositionX = positionX;
    //        Removable = removable;
    //        SignalDirection = signalDirection;
    //        FixedNumberOfStates = fixedNumberOfStates;
    //        SelfRegulated = selfRegulated;
    //        _stateList = new List<State>();
    //        _currentState = null;
    //        if (addIdleState)
    //        {
    //            _currentState = new State(this, "Idle", 0, "", false, 1, 1);
    //            _stateList.Add(_currentState);
    //        }
    //    }
    //    public State InputAssociatedValue(string associatedValue)
    //    {           
    //        if (!_stateList.Exists(x => x.AssociatedValue == associatedValue))
    //            return AddState(Parent.Parent.NameGenerator.GenerateStateName(), _stateList[_stateList.Count - 1].PositionY + 1, associatedValue, false);
    //        return null;
    //    }
    //    public State AddState(State state)
    //    {
    //        _stateList.Add(state);
    //        return state;
    //    }
    //    public State AddState(string name, int positionY, string value = "", bool removable = true, float threshold = 1, float amplificationOfState = 1)
    //    {
    //        State state = new State(this, name, positionY, value, removable, threshold, amplificationOfState);
    //        _stateList.Add(state);
    //        return state;
    //    }
    //    public State AddState(int positionY, string value = "", bool removable = true, float threshold = 1, float amplificationOfState = 1)
    //    {
    //        return AddState(Parent.Parent.NameGenerator.GenerateStateName(), positionY, value, removable, threshold, amplificationOfState);
    //    }
    //    public State AddState(string value = "", bool removable = true, float threshold = 1, float amplificationOfState = 1)
    //    {
    //        return AddState(_stateList.Count, value, removable, threshold, amplificationOfState);
    //    }
    //    public void EvaluateNextState()
    //    {
    //        //Check state with highest input
    //        float highestInput = float.MinValue;
    //        State highestState = null;
    //        foreach (State state in _stateList)
    //        {
    //            float input = state.CalculateCurrentInputSignal();
    //            //Add info in all states about input (for balancing)
    //            state.SetBalanceLastInput(input);
    //            if (input <= 0)
    //                continue;
    //            if (input > highestInput)
    //            {
    //                highestInput = input;
    //                highestState = state;
    //            }
    //            else if (input == highestInput)
    //            {
    //                highestInput = input;
    //                if (highestState == null || state.PositionY < highestState.PositionY)
    //                    highestState = state;
    //            }
    //        }
    //        _nextState = highestState;
    //        //Add info in state that was next state (for balancing)
    //        _nextState.SetBalanceNextState(true);
    //        _nextState.SetBalanceLastTimeUsed(VirtualTime.GetCurrentTime());
    //    }
    //    public void ExecuteTriggers()
    //    {
    //        if (_nextState == null)
    //            return;
    //        if (_nextState == _currentState)
    //            _nextState.TriggerEvent(StateEventEnum.Remain);
    //        else
    //        {
    //            _currentState.TriggerEvent(StateEventEnum.Exit);
    //            _nextState.TriggerEvent(StateEventEnum.Entry);
    //            _currentState = _nextState;
    //        }
    //        _nextState = null;
    //    }
    //    public void BalanceWeightings()
    //    {
    //        foreach (State state in _stateList)
    //        {
    //            state.BalanceWeightings();
    //        }
    //    }
    //    public void ResetStatisticsForBalance()
    //    {
    //        foreach (State state in _stateList)
    //        {
    //            state.ResetStatisticsForBalance();
    //        }
    //    }
    //}
}
