using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DomeTD.Models
{
    public class Dome:CanvasItem
    {
        private int health;

        public int Health
        {
            get { return 100; }
            set { health = value; }
        }
        public override Geometry Area
        {
            get
            {
                return new RectangleGeometry(new Rect(0,0, 50, 50));
            }
        }
    }
}
