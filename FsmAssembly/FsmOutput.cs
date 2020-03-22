using System;
using System.Collections.Generic;
using System.Text;

namespace FsmAssembly
{
    public class FsmOutput : FsmBase
    {
        public FsmOutput(FsmEnsemble parent, string name, int positionX) : base(parent, name, positionX)
        {
            _currentState = null;
            _currentState = AddState("Idle", "");
        }
        public State AddStateValue(string associatedValue)
        {
            return AddState(associatedValue, associatedValue);
        }
        public string GetCurrentStateValue()
        {
            return _currentState.AssociatedValue;
        }
        override public void ExecuteTriggers()
        {
            _nextState = _stateList["Idle"];
        }
        public void ReceiveSignalFrom(FsmBase fsm)
        {
            base.BaseReceiveSignalFrom(fsm);
        }
    }
}
