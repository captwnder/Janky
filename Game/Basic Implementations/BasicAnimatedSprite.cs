using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.Window;

namespace Game
{
    class BasicAnimatedSprite : AnimatedSprite
    {
        //Variables
        private List<Sprite> SpriteArray;
        private Texture AnimatedSpriteTexture;
        private int NumberTicksChangeFrame;
        private int TicksSinceLastChange;
        private Boolean OnlyUpdateFramesWhileMoving;
        private int CurrentFrame;
        private int NumberOfFrames;
        
        //Public Methods
        //public enum SpriteState { Up, Down, Left, Right, Center, UpLeft, Upright, Downleft, Downright };

        public enum SpriteState { Down, Left, Right, Up };
        public BasicAnimatedSprite(String Filename, Int16 SpriteWidth, Int16 SpriteHeight, Int16 NumFrames, int NumTicksPerUpdate, Boolean OnlyWhileMoving, int Direction) {
            //currently assumes that sprite sheets are always horizontal
            AnimatedSpriteTexture = new Texture(Filename);
            //Added this to get multiple row sprite sheets to work for testing
            int Row; 
            Row = Direction;
            int x1 = 0;
            int y1 = SpriteHeight * Row;
            int x2 = SpriteWidth;
            int y2 = SpriteHeight * (Row + 1);
            SpriteArray = new List<Sprite>();
            for(int i = 0; i < NumFrames; i++) {
               SpriteArray.Add(new Sprite(AnimatedSpriteTexture, new IntRect(x1, y1, x2 - x1, y2 - y1)));
                x1 = x1 + SpriteWidth;
                x2 = x2 + SpriteWidth;
            }
            NumberTicksChangeFrame = NumTicksPerUpdate;
            OnlyUpdateFramesWhileMoving = OnlyWhileMoving;
            TicksSinceLastChange = 0;
            CurrentFrame = 0;
            NumberOfFrames = NumFrames;
            Position = new Vector2f(0, 0);
        }

        public void Update(int Ticks) {
            //if (OnlyUpdateFramesWhileMoving)
            //{
            if (Ticks + TicksSinceLastChange > NumberTicksChangeFrame)
            {
                CurrentFrame = (CurrentFrame + 1) % NumberOfFrames;
                TicksSinceLastChange = Ticks + TicksSinceLastChange - NumberTicksChangeFrame;
            }
            else
            {
                TicksSinceLastChange = Ticks + TicksSinceLastChange;
            }
            //}
            //No Movement logic yet.
        }

        public void Reset()
        {
            CurrentFrame = 0;
        }

        public Drawable Draw() {
            SpriteArray[CurrentFrame].Position = Position;
            return SpriteArray[CurrentFrame];
        }

        public void SetState(string State, string Value)
        {
            throw new NotImplementedException();
        }

        public string GetState()
        {
            throw new NotImplementedException();
        }

        public Vector2f Position { get; set; }

        public String Direction { get; set; }


    }
}
