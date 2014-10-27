using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using SlimDX.XInput;

namespace Game
{
    class BasicPlayerInputAnalogController : PlayerInputAnalog
    {
        private Controller controller;
        private State controllerState;
        private uint LastPacketNumber;

        private void UpdateControllerState() {
            State NewState = controller.GetState();
            if (NewState.PacketNumber > LastPacketNumber)
            {
                LastPacketNumber = NewState.PacketNumber;
                controllerState = NewState;
            }
        }

        public BasicPlayerInputAnalogController() {
            controller = new Controller(UserIndex.One);
        }

        public float Up()
        {
            if (!controller.IsConnected)
            {
                return 0;
            }

            UpdateControllerState();

            float ReturnValue = ((float)controllerState.Gamepad.LeftThumbY) / 32768;
            if (ReturnValue < 0.0)
            {
                return 0;
            }
            else
            {
                return ReturnValue;
            }
        }

        public float Down()
        {
            if (!controller.IsConnected)
            {
                return 0;
            }

            UpdateControllerState();

            float ReturnValue = -(((float)controllerState.Gamepad.LeftThumbY) / 32768);
            if (ReturnValue < 0.0)
            {
                return 0;
            }
            else
            {
                return ReturnValue;
            }
        }

        public float Left()
        {
            if (!controller.IsConnected)
            {
                return 0;
            }

            UpdateControllerState();

            float ReturnValue = -((float)controllerState.Gamepad.LeftThumbX / 32768);
            if (ReturnValue < 0.0)
            {
                return 0;
            }
            else
            {
                return ReturnValue;
            }
        }

        public float Right()
        {
            if (!controller.IsConnected)
            {
                return 0;
            }

            UpdateControllerState();

            float ReturnValue = (float)controllerState.Gamepad.LeftThumbX / 32768;
            if (ReturnValue < 0.0)
            {
                return 0;
            }
            else
            {
                return ReturnValue;
            }
        }

        public float Up2()
        {
            if (!controller.IsConnected)
            {
                return 0;
            }

            UpdateControllerState();

            float ReturnValue = ((float)controllerState.Gamepad.RightThumbY) / 32768;
            if (ReturnValue < 0.0)
            {
                return 0;
            }
            else
            {
                return ReturnValue;
            }
        }

        public float Down2()
        {
            if (!controller.IsConnected)
            {
                return 0;
            }

            UpdateControllerState();

            float ReturnValue = -(((float)controllerState.Gamepad.RightThumbY) / 32768);
            if (ReturnValue < 0.0)
            {
                return 0;
            }
            else
            {
                return ReturnValue;
            }
        }

        public float Left2()
        {
            if (!controller.IsConnected)
            {
                return 0;
            }

            UpdateControllerState();

            float ReturnValue = -((float)controllerState.Gamepad.RightThumbX / 32768);
            if (ReturnValue < 0.0)
            {
                return 0;
            }
            else
            {
                return ReturnValue;
            }
        }

        public float Right2()
        {
            if (!controller.IsConnected)
            {
                return 0;
            }

            UpdateControllerState();

            float ReturnValue = (float)controllerState.Gamepad.RightThumbX / 32768;
            if (ReturnValue < 0.0)
            {
                return 0;
            }
            else
            {
                return ReturnValue;
            }
        }

        public bool Button1()
        {
            if (!controller.IsConnected)
            {
                return false;
            }

            UpdateControllerState();

            return controllerState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.A);
        }

        public bool Button2()
        {
            if (!controller.IsConnected)
            {
                return false;
            }

            UpdateControllerState();

            return controllerState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.B);
        }

        public bool Button3()
        {
            if (!controller.IsConnected)
            {
                return false;
            }

            UpdateControllerState();

            return controllerState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.X);
        }

        public bool Button4()
        {
            if (!controller.IsConnected)
            {
                return false;
            }

            UpdateControllerState();

            return controllerState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Y);
        }
    }
}
