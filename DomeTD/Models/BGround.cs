using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomeTD.Models
{
    public class BGround : IGameItem
    {
        private string type;

        public string Type
        {
            get { return "Background"; }
            set { type = value; }
        }

    }
}
