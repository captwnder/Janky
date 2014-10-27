using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    interface PlayerInputBinary
    {
        Boolean Up();
        Boolean Down();
        Boolean Left();
        Boolean Right();
        Boolean Jump();
        Boolean ShootUp();
        Boolean ShootDown();
        Boolean ShootRight();
        Boolean ShootLeft();
    }
}
