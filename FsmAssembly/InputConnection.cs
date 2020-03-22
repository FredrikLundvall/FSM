using System;
using System.Collections.Generic;
using System.Text;

namespace FsmAssembly
{
    public class InputConnection
    {
        public readonly State InputToState;
        private volatile State _outputFromState;
        public State OutputFromState
        {
            get { return _outputFromState; }
        }
        private volatile StateEventEnum _outputEvent;
        private volatile float _bias;
        private volatile float _decay;
        //For balancing
        private volatile float _balanceLastSignal = 0;
        public InputConnection(State inputToState, State outputFromState, StateEventEnum outputEvent, float bias, float decay)
        {
            InputToState = inputToState;
            _outputFromState = outputFromState;
            _outputEvent = outputEvent;
            _bias = bias;
            _decay = decay;
        }
        public float CalculateSignal()
        {
            return _outputFromState.CalculateEventSignal(_outputEvent, _decay) * _bias;
        }
        //For balancing
        public void SetBalanceLastSignal(float balanceLastSignal)
        {
            _balanceLastSignal = balanceLastSignal;
        }
        public float GetBalanceLastSignal()
        {
            return _balanceLastSignal;
        }
        public void StrengthenConnection(float weightingValue)
        {
            _bias *= weightingValue;
        }
    }
}
