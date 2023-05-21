using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [Serializable]
    public abstract class Statistic < T >
    {
        public virtual T Value { get; set; }
    }

    [Serializable]
    public class WinRate : Statistic<float>
    {
        public WinRate(Victories victories, Matches matches)
        {
            Value = ((float)victories.Value / matches.Value) * 100f;
        }
    }

    [Serializable]
    public class Victories : Statistic<int>
    {
        public Victories(int initialValue)
        {
            Value = initialValue;
        }
    }

    [Serializable]
    public class Matches : Statistic<int>
    {
        public Matches(int initialValue)
        {
            Value = initialValue;
        }
    }

    [Serializable]
    public class AccumulatedTime : Statistic<float>
    {
        public AccumulatedTime(float time)
        {
            Value = time;
        }
    }

    
}
