﻿using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomeTD.Models
{
    public class MainCharacter : ObservableObject,IGameModel
    {
        private string type;

        public string Type
        {
            get { return "Hero"; }
            set { SetProperty( ref type, value); }
        }
        private double drillingpower;

        public double Drillingpower
        {
            get { return drillingpower; }
            set { SetProperty( ref drillingpower , value); }
        }
        private int speed;

        public int Speed
        {
            get { return speed; }
            set { SetProperty( ref speed ,value); }
        }

    }
}
