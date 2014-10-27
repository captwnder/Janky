using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Window;
using SFML.Graphics;

namespace Game
{
    //Does not need to inherit from drawable - uses draw() to return a drawable.
    interface Entity
    {
        void Update(int Ticks);
        SFML.Graphics.Drawable Draw();
        Vector2f Position { get; set; }
        String Direction { get; set; }

        //These are experimental -Jm
        void SetState(String State, String Value);
        String GetState();
    }
}
