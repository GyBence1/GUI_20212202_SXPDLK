using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomeTD.Models
{
    public class MainCharacter : ObservableObject
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { SetProperty( ref name , value); }
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
