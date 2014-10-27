using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    interface CharacterEntity : Entity
    {
        //I'm not sure that we couldn't just do a setstate that passes values as strings.  Might lose some precision on floats, etc.
        int GetHP();
        void SetHP(int Delta);
        int GetStrength();
        void SetStrength(int Delta);
        int GetSpeed();
        void SetSpeed(int Delta);
    }
}
