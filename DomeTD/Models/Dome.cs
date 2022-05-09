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
        public double canvaswidth { get; set; }
        public double canvasheight { get; set; }

        public Dome(double canvaswidth, double canvasheight)
        {
            this.canvaswidth=canvaswidth;
            this.canvasheight=canvasheight;
        }

        public override Geometry Area
        {
            get
            {
                return new RectangleGeometry(new Rect(0,canvasheight-163,200,200));
            }
        }
    }
}
