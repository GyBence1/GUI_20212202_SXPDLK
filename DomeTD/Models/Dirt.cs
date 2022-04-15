using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomeTD.Models
{
    public class Dirt : IMaterials
    {
        public string Type
        {
            get 
            { 
                return "dirt"; 
            }
        }            

        public double Thoughness
        {
            get
            {
                return 1;
            }
        }
    }
}
