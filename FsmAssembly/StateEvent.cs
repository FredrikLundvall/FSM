using System;
using System.Collections.Generic;
using System.Text;

namespace FsmAssembly
{
    public class StateEvent
    {
        public readonly EventSetting CurrentEventSetting;
        public EventSignal CurrentEventSignal; //gc-warning: using struct for EventSignal
        public StateEvent()
        {
            CurrentEventSetting = EventSetting.CreateNullEventAction();
            CurrentEventSignal = EventSignal.CreateNullEventAction();
        }
    }
}
