using Laby.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Laby.Controller
{
    public class GameController
    {
        IGameControl control;

        public GameController(IGameControl control)
        {
            this.control = control;
        }

        public void KeyPressed(Key key)
        {
            switch (key)
            {
                case Key.Up:
                    control.Move(LabyLogic.Direction.up);
                    break;
                case Key.Down:
                    control.Move(LabyLogic.Direction.down);
                    break;
                case Key.Left:
                    control.Move(LabyLogic.Direction.left);
                    break;
                case Key.Right:
                    control.Move(LabyLogic.Direction.right);
                    break;
                default:
                    break;
            }
        }
    }
}
