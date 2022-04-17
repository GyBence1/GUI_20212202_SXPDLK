using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomeTD.Models
{
    public class Dome:IGameItem
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
            set { attackDamage = value; ; }
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

    }
}
