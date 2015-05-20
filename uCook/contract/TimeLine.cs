﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uCookContract
{
    [Serializable]
    public class TimeLine
    {
        public List<TimeSlot> timeLine { get; private set; }
        public int currentSlot { get; private set; }

        public int ammountTimeSlots { get; private set; }

        public TimeLine()
        {
            currentSlot = 0;
            ammountTimeSlots = 0;
            timeLine = new List<TimeSlot>();
        }

        public void addTimeSlot(string action, int duration)
        {
            TimeSlot ts = new TimeSlot(ammountTimeSlots, duration, action);
            ammountTimeSlots++;
            timeLine.Add(ts);
        }

        public void nextSlot()
        {
            currentSlot++;
        }

        public TimeSlot getAction()
        {
            return timeLine[currentSlot];
        }
    }
}