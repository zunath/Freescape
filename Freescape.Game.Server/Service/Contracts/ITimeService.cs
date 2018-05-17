﻿using System;

namespace Freescape.Game.Server.Service
{
    public interface ITimeService
    {
        String GetTimeToWaitLongIntervals(DateTime firstDate, DateTime secondDate, bool showIfZero);
        String GetTimeToWaitShortIntervals(DateTime firstDate, DateTime secondDate, bool showIfZero);
    }
}