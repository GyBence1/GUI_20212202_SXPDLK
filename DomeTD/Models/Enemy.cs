using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DomeTD.Models
{
    public class Enemy : CanvasItem
    {

        private double health;

        public double Health
        {
            get { return health; }
            set { health = value; ; }
        }

        private double attackDamage;

        public double AttackDamage
        {
            get { return attackDamage; }
            set { attackDamage = value; ; }
        }
        public double posX { get; set; }
        public double posY { get; set; }

        public Enemy(double posX, double posY)
        {
            this.posX=posX;
            this.posY=posY;
            AttackDamage=10;
            Health=100;
        }

        private int speed;

        public int Speed
        {
            get { return speed; }
            set { speed = value; ; }
        }

        public override Geometry Area
        {
            get
            {
                return new RectangleGeometry(new Rect(posX-60, posY-50, 50, 50));
            }
        }
    }
}
