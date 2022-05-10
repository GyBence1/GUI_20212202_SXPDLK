using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.ComponentModel;

namespace DomeTD.Models
{
    public class Dome:CanvasItem,INotifyPropertyChanged
    {
        private int health;

        public int Health
        {
            get { return health; }
            set { health = value; OnPropertyChanged("Health"); }
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
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
