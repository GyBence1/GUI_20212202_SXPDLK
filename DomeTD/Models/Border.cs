using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomeTD.Models
{
    public class Border:IGameItem
    {
        private string type;

        public string Type
        {
            get { return "Border"; }
            set { type = value; }
        }

    }
}
