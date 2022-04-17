using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomeTD.Models
{
    public class MainCharacter : INotifyPropertyChanged, IGameItem
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
