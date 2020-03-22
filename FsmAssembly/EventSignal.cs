using System;
using System.Collections.Generic;
using System.Text;

namespace FsmAssembly
{
    public struct EventSignal
    {
        public readonly int TimeOfOutput;
        public readonly int LengthOfDelay;
        public readonly int LengthOfOn;
        public readonly int ModulusOfSignal;
        public readonly int LengthOfSignal;
        public readonly float AmplificationOfAction;
        public EventSignal(int timeOfOutput, int lengthOfDelay, int lengthOfOn, int modulusOfSignal, int lengthOfSignal, float amplificationOfAction)
        {
            TimeOfOutput = timeOfOutput;
            LengthOfDelay = lengthOfDelay;
            LengthOfOn = lengthOfOn;
            ModulusOfSignal = modulusOfSignal;
            LengthOfSignal = lengthOfSignal;
            AmplificationOfAction = amplificationOfAction;
        }
        public EventSignal(int timeOfOutput, EventSetting eventAction) : this(timeOfOutput, eventAction.GetLengthOfDelay(), eventAction.GetLengthOfOn(), eventAction.GetModulusOfSignal(), eventAction.GetLengthOfSignal(), eventAction.GetAmplificationOfAction()) { }
        public static EventSignal CreateNullEventAction()
        {
            return new EventSignal(0, 0, 0, 0, 0, 1.0f);
        }
        public float CalulateSignal(float decay)
        {
            float loss = (VirtualTime.GetCurrentTime() - TimeOfOutput) * decay;
            int startOfSignal = VirtualTime.GetCurrentTime() - (TimeOfOutput  + LengthOfDelay);
            if (ModulusOfSignal == 0 || startOfSignal < 0 || startOfSignal > LengthOfSignal)
                //Not started yet or finished allready
                return 0f;
            return (startOfSignal % ModulusOfSignal < LengthOfOn)?Math.Max(1f * AmplificationOfAction - loss,0f): 0f;
        }
    }
}
