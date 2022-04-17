using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomeTD.Models
{
    public class Laser:IGameItem
    {
        private string type;

        public string Type
        {
            get { return "Laser"; }
            set { type = value; }
        }
        private double attackDamage;

        public double AttackDamage
        {
            get { return attackDamage; }
            set { attackDamage = value; }
        }
        private double attackSpeed;

        public double AttackSpeed
        {
            get { return attackSpeed; }
            set { attackSpeed = value; }
        }
        public int J { get; set; }

    }
}
