using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomeTD.Models
{
    public class Enemy : IGameItem
    {
        private string type;

        public string Type
        {
            get { return "Enemy"; }
            set { type = value; }
        }

        private double health;

        public double Health
        {
            get { return 100; }
            set { health = value; ; }
        }

        private double attackDamage;

        public double AttackDamage
        {
            get { return attackDamage; }
            set { attackDamage = value; ; }
        }

        private int speed;

        public int Speed
        {
            get { return speed; }
            set { speed = value; ; }
        }

        private int j;

        public int J
        {
            get { return j; }
            set { j = value; }
        }


    }
}
