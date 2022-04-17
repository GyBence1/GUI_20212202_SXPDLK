using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomeTD.Models
{
    public class Enemy : ObservableObject,IGameItem
    {
        private string type;

        public string Type
        {
            get { return "Enemy"; }
            set { SetProperty(ref type, value); }
        }

        private double health;

        public double Health
        {
            get { return 100; }
            set { SetProperty(ref health, value); }
        }

        private double attackDamage;

        public double AttackDamage
        {
            get { return attackDamage; }
            set { SetProperty(ref attackDamage, value); }
        }

        private int speed;

        public int Speed
        {
            get { return speed; }
            set { SetProperty(ref speed, value); }
        }

        

    }
}
