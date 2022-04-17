using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomeTD.Models
{
    public class Dome:IGameItem, INotifyPropertyChanged
    {
        private string type;

        public string Type
        {
            get { return "Dome"; }
            set { type = value; }
        }
        private double attackDamage;

        public double AttackDamage
        {
            get { return attackDamage; }
            set { 
                attackDamage = value;
                OnPropertyChanged("AttackDamage");
            }
        }

        private double attackSpeed;

        public double AttackSpeed
        {
            get { return attackSpeed; }
            set { attackSpeed = value; ; }
        }
        private int health;

        public int Health
        {
            get { return health; }
            set { health = value; }
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
