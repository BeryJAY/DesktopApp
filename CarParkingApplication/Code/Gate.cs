using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace CarParkingApplication.Code
{
   public abstract class Gate
    {

        public int state { get; set; }


        Timer GateTimer;

        public void TimeGate()
        {
            GateTimer = new Timer();
            GateTimer.Interval = 5000;
            GateTimer.Elapsed += new ElapsedEventHandler(GateTimerElapsed);

        }

        private void GateTimerElapsed(object sender, ElapsedEventArgs e)
        {
           //switch()
        }

        public void Open()
        {

            
            state = 1;

        }

    }
}
