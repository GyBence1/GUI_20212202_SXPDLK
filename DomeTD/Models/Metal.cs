using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomeTD.Models
{
    public class Metal : IGameModel
    {
        private string myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }


        public double Thoughness
        {
            get
            {
                return 5;
            }
        }

        
    }
}
