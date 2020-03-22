using System;
using System.Collections.Generic;
using System.Text;

namespace FsmAssembly
{
    public static class VirtualTime
    {
        private static readonly object _globalLock = new object();
        private static volatile int _currentTime = 0;
        public static int GetCurrentTime()
        {
            return _currentTime;
        }
        public static void StepCurrentTime()
        {
            lock (_globalLock)
            {
                _currentTime = _currentTime == int.MaxValue? 0 : _currentTime++;
            }
        }
    }
}
