﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomeTD.Models
{
    public class Floor : IGameItem //Ezen tud sétálni a karakter, ha kiütsz egy blokkot akkor floorrá válik.
    {
        private string type;

        public string Type
        {
            get { return "Floor"; }
            set { type = value; }
        }

    }
}
