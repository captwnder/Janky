using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    interface GameClock
    {
        Int32 GetTickCount();
        Int32 Reset();
    }
}
