﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DomeTD.Models
{
    public class Laser:CanvasItem 
    {
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
        }

        public override Geometry Area
        {
            get
            {
                return new RectangleGeometry(new Rect(posX,posY, 20, 20));
            }
        }
    }
}
