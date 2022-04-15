using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomeTD.Models
{
    public class Metal : IMaterials
    {
        public string Type
        { 
            get 
            {
                return "metal";
            }
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
