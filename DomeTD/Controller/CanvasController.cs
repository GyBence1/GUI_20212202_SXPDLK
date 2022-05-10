using DomeTD.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DomeTD.Controller
{
    public class CanvasController
    {
        ICanvasControl controller;

        public CanvasController(ICanvasControl controller)
        {
            this.controller=controller;
        }
        public void KeyPressed(Key e)
        {
            switch (e)
            {
               
                case Key.Space:
                    controller.Shoot();
                    break;
                default:
                    break;
            }
        }
    }
}
