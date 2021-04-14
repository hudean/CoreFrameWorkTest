using CoreFrameWork.Infrastructure.Timer;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CoreFrameWork.ElasticSearch
{
    /// <summary>
    /// Elastic客户端跟踪条目
    /// </summary>
    public class ElasticClientTrackingEntry
    {
        private static readonly TimerCallback TimerCallback = s => ((ElasticClientTrackingEntry)s).Timer_Tick();
        private readonly object _lock;
        private bool _timerInitialized;
        private TimerCallback _callback;
        private Timer _timer;

        public TimeSpan Lifetime { get; }

        public string Name { get; }
        public ElasticClient ElasticClient { get; }

        public ElasticClientTrackingEntry(
            string name,
            ElasticClient elasticClient,
            TimeSpan lifetime)
        {
            Name = name;
            ElasticClient = elasticClient;
            Lifetime = lifetime;
            _lock = new object();
        }

        public void StartExpiryTimer(TimerCallback callback)
        {
            if (Lifetime == Timeout.InfiniteTimeSpan || Volatile.Read(ref _timerInitialized))
                return;
            StartExpiryTimerSlow(callback);
        }

        public void StopExpiryTimer()
        {
            lock (_lock)
            {
                if (_timer == null)
                    return;
                _timer.Dispose();
                _timer = null;
                _callback = null;
            }
        }

        private void StartExpiryTimerSlow(TimerCallback callback)
        {
            lock (_lock)
            {
                if (Volatile.Read(ref _timerInitialized))
                    return;
                _callback = callback;
                _timer = NonCapturingTimer.Create(TimerCallback, this, Lifetime, Timeout.InfiniteTimeSpan);
                _timerInitialized = true;
            }
        }

        private void Timer_Tick()
        {
            lock (_lock)
            {
                if (_timer == null)
                    return;
                _timer.Dispose();
                _timer = null;
                _callback(this);
            }
        }


    }
}
