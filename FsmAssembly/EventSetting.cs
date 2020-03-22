using System;
using System.Collections.Generic;
using System.Text;

namespace FsmAssembly
{
    public class EventSetting
    {
        private volatile int _lengthOfDelay;
        private volatile int _lengthOfOn;
        private volatile int _modulusOfSignal;
        private volatile int _lengthOfSignal;
        private volatile float _amplificationOfAction;
        public EventSetting(int lengthOfDelay, int lengthOfOn, int modulusOfSignal, int lengthOfSignal, float amplificationOfAction)
        {
            _lengthOfDelay = lengthOfDelay;
            _lengthOfOn = lengthOfOn;
            _modulusOfSignal = modulusOfSignal;
            _lengthOfSignal = lengthOfSignal;
            _amplificationOfAction = amplificationOfAction;
        }
        public int GetLengthOfDelay()
        {
            return _lengthOfDelay;
        }
        public int GetLengthOfOn()
        {
            return _lengthOfOn;
        }
        public int GetModulusOfSignal()
        {
            return _modulusOfSignal;
        }
        public int GetLengthOfSignal()
        {
            return _lengthOfSignal;
        }
        public float GetAmplificationOfAction()
        {
            return _amplificationOfAction;
        }
        public static EventSetting CreateNullEventAction()
        {
            return new EventSetting(0, 0, 0, 0, 1.0f);
        }
    }
}
