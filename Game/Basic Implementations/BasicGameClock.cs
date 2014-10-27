using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class BasicGameClock : GameClock
    {
        //Variables
        private Int32 StartTick;

        //Constructor
        public BasicGameClock() {
            StartTick = System.Environment.TickCount;
        }
       
        //Methods
        public Int32 GetTickCount() {
            return(System.Environment.TickCount - StartTick);
        }

        public Int32 Reset() {
            Int32 temp = StartTick;
            StartTick = System.Environment.TickCount;
            return System.Environment.TickCount - temp;
        }
    }
}
