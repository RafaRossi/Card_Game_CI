using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class MatchLog
    {
        public float MatchTime;
        public bool Victory;

        public MatchLog(float matchTime, bool victory)
        {
            MatchTime = matchTime;
            Victory = victory;
        }
    }
}

