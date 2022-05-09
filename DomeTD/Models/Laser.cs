using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DomeTD.Models
{
    public class Laser:CanvasItem , INotifyPropertyChanged
    {
        private double attackDamage;

        public double AttackDamage
        {
            get { return attackDamage; }
            set { attackDamage = value; OnPropertyChanged("AttackDamage"); }
        }



        private double attackSpeed;

        public double AttackSpeed
        {
            get { return attackSpeed; }
            set { attackSpeed = value; }
        }
        public double posX { get; set; }
        public double posY { get; set; }

        public Laser(double posX, double posY)
        {
            this.posX=posX;
            this.posY=posY;
            this.AttackSpeed=1;
            this.AttackDamage=5;
        }

        public override Geometry Area
        {
            get
            {
                return new RectangleGeometry(new Rect(posX,posY, 20, 20));
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
