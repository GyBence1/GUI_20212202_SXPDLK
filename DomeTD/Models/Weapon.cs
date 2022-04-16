using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomeTD.Models
{
    public class Weapon : ObservableObject,IGameModel
    {
        private double attackDamage;

        public double AttackDamage
        {
            get { return attackDamage; }
            set { SetProperty(ref attackDamage, value); }
        }

        private double attackSpeed;

        public double AttackSpeed
        {
            get { return attackSpeed; }
            set { SetProperty(ref attackSpeed, value); }
        }

        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

    }
}
