using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomeTD.Models
{
    public class MainCharacter : ObservableObject, IGameItem
    {
        private string type;

        public string Type
        {
            get { return "Hero"; }
            set { type = value; }
        }
        private double drillingpower;

        public double DrillingPower
        {
            get { return drillingpower; }
            set
            {
                drillingpower = value;
                OnPropertyChanged("DrillingPower");
            }
        }
        private int speed;

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        private int drillingpowerupgCostInVib;

        public int DrillingpowerupgCostInVib
        {
            get { return drillingpowerupgCostInVib; }
            set { SetProperty(ref drillingpowerupgCostInVib, value); }
        }

        private int drillingpowerupgCost;

        public int DrillingpowerupgCost
        {
            get { return drillingpowerupgCost; }
            set { SetProperty( ref drillingpowerupgCost, value); }
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
