using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Game
{
    class BasicPlayerInputBinaryKeyboard : PlayerInputBinary
    {
        public Boolean Down()
        {
            if (Keyboard.IsKeyDown(Key.S))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean Up()
        {
            if (Keyboard.IsKeyDown(Key.W))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean Left()
        {
            if (Keyboard.IsKeyDown(Key.A))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean Right()
        {
            if (Keyboard.IsKeyDown(Key.D))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean Jump()
        {
            if (Keyboard.IsKeyDown(Key.Space))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean ShootLeft()
        {
            if (Keyboard.IsKeyDown(Key.Left))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean ShootRight()
        {
            if (Keyboard.IsKeyDown(Key.Right))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean ShootUp()
        {
            if (Keyboard.IsKeyDown(Key.Up))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean ShootDown()
        {
            if (Keyboard.IsKeyDown(Key.Down))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
