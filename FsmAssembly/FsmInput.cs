using System;
using System.Collections.Generic;
using System.Text;

namespace FsmAssembly
{
    public class FsmInput : FsmBase
    {
        public FsmInput(FsmEnsemble parent, string name, int positionX) : base(parent, name, positionX)
        {
            _currentState = null;
            _currentState = AddState("Idle", "");
        }
        public State AddStateValue(string associatedValue)
        {
            return AddState(associatedValue, associatedValue);
        }
        public State SetCurrentStateValue(string associatedValue)
        {
            State state = _stateList[associatedValue];
            if (state == null)
                state = AddState(associatedValue, associatedValue);
            _nextState = state;
            return state;
        }
        override public void EvaluateNextState()
        {
            //Add info in state that was next state (for balancing)
            _nextState.SetBalanceNextState(true);
            _nextState.SetBalanceLastTimeUsed(VirtualTime.GetCurrentTime());
        }
        public void SendSignalTo(FsmBase fsm)
        {
            base.BaseSendSignalTo(fsm);
        }
    }
}
