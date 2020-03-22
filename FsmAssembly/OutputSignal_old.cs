using System;
using System.Collections.Generic;
using System.Text;

namespace FsmAssembly
{
    public class OutputSignal
    {
        public readonly int TimeOfSignal;
        public readonly int LengthOfDelay;
        public readonly int LengthOfOn;
        public readonly int LengthOfOff;
        public readonly int TimesToSignal;
        public OutputSignal(int timeOfSignal, int lengthOfDelay, int lengthOfOn, int lengthOfOff, int timesToSignal)
        {
            TimeOfSignal = timeOfSignal;
            LengthOfDelay = lengthOfDelay;
            LengthOfOn = lengthOfOn;
            LengthOfOff = lengthOfOff;
            TimesToSignal = timesToSignal;
        }
    }

    //If sorting is needed
    //private List<Signal> signalList;
    //this.signalList.Sort(new SignalSorter());
    //Can be used to find an item
    //this.signalList.BinarySearch();

    //public class SignalSorter : IComparer<Signal>
    //{
    //    public int Compare(Signal s1, Signal s2)
    //    {
    //        return (s2.TimeOfSignal + s2.LengthOfDelay).CompareTo(s1.TimeOfSignal + s1.LengthOfDelay);
    //    }
    //}
}
