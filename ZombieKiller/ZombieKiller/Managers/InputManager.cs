using EZInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieKiller.Managers
{
    internal class InputManager
    {
        public bool MoveLeft()
        {
            return Keyboard.IsKeyPressed(Key.LeftArrow);
        }

        public bool MoveRight()
        {
            return Keyboard.IsKeyPressed(Key.RightArrow);
        }

        public bool MoveUp()
        {
            return Keyboard.IsKeyPressed(Key.UpArrow);
        }

        public bool MoveDown()
        {
            return Keyboard.IsKeyPressed(Key.DownArrow);
        }

        public bool Fire()
        {
            return Keyboard.IsKeyPressed(Key.Space);
        }
    }
}