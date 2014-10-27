using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    interface PlayerInputAnalog
    {
        float Up();
        float Down();
        float Left();
        float Right();
        float Up2();
        float Down2();
        float Left2();
        float Right2();
        Boolean Button1();
        Boolean Button2();
        Boolean Button3();
        Boolean Button4();
    }
}
