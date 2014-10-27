using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class BasicPlayer : Player
    {
        private BasicAnimatedSprite Idle;
        private BasicAnimatedSprite Walk;
        private Boolean Moving;
        //Add controller access/setup here

        BasicPlayer(BasicAnimatedSprite IdleSprite, BasicAnimatedSprite WalkSprite) {
            Moving = false;
            Idle = IdleSprite;
            Walk = WalkSprite;
        }

        public void Update(int Ticks)
        {
            //this is where we need to add the logic for jumping, controller input, etc.
            //I suggest adding a private jump function to handle those settings, with class values so we can tweak it.
            //The setstate function is an idea to generically handle these things by passing a string:value pair to set variables.
            if (Moving)
            {
                Walk.Update(Ticks);
                Idle.Reset();
            }
            else
            {
                Idle.Update(Ticks);
                Walk.Reset();
            }
        }

        public SFML.Graphics.Drawable Draw()
        {
            if (Moving)
            {
                return Walk.Draw();
            }
            else
            {
                return Idle.Draw();
            }
        }

        //This is implemented as a property in the entity interface.
        public SFML.Window.Vector2f Position
        {
            get
            {
                return Position;
            }
            set
            {
                Position = value;
            }
        }

        public void SetState(string State, string Value)
        {
            throw new NotImplementedException();
        }

        public string GetState()
        {
            throw new NotImplementedException();
        }

        public String Direction { get; set; }
    }
}
