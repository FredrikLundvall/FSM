using System;

namespace FsmAssembly
{
    public class ThreadSafeRandom
    {
        private static readonly object _globalLock = new object();
        private static Random _global;
        [ThreadStatic] private static Random _local;

        public ThreadSafeRandom(int seed)
        {
            if (_global == null)
            {
                lock (_globalLock)
                {
                    if (_global == null)
                    {
                        _global = new Random(seed);
                    }
                }
            }
            if (_local == null)
            {
                lock (_globalLock)
                {
                    if (_local == null)
                    {
                        int threadSeed = _global.Next();
                        _local = new Random(threadSeed);
                    }
                }
            }
        }

        public int Next()
        {
            return _local.Next();
        }

        public int Next(int maxValue)
        {
            return _local.Next(maxValue);
        }
    }
}
