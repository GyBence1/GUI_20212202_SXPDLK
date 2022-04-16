using DomeTD.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DomeTD.Controller
{
    internal class GameController
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
                case Key.W:
                    control.Move(DomeLogic.Directions.up);
                    break;
                case Key.S:
                    control.Move(DomeLogic.Directions.down);
                    break;
                case Key.A:
                    control.Move(DomeLogic.Directions.left);
                    break;
                case Key.D:
                    control.Move(DomeLogic.Directions.right);
                    break;
            }
        }
    }
}
