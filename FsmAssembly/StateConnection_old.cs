using System;
using System.Collections.Generic;
using System.Text;

namespace FsmAssembly
{
    public class StateConnection
    {
        public readonly State OutputFromState;
        public readonly string Name;
        private volatile State _inputToState;
        private volatile float _bias; 
        public StateConnection(State outputFromState, State inputToState, string name, float bias)
        {
            OutputFromState = outputFromState;
            _inputToState = inputToState;
            Name = name;
            _bias = bias;
        }

        public void SendSignal(EventAction eventAction)
        {
            _inputToState.AddReceivedSignal(eventAction.CreateSignal(OutputFromState, _inputToState, _bias));
        }
    }
}
