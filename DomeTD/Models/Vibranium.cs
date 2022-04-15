using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomeTD.Models
{
    public class Vibranium : IMaterials
    {
        public string Type
        {
            get
            {
                return "vibranium";
            }
        }

        public double Thoughness
        {
            get
            {
                return 10;
            }
        }
    }
}
