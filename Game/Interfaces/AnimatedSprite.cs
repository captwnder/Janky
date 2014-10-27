using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.Window;

namespace Game
{
    interface AnimatedSprite : Entity
    {
        //This would normally extend the sprite interface but SFML didn't implement it that way. -Jm
    }
}
