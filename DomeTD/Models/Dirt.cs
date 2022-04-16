﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomeTD.Models
{
    public class Dirt : IGameModel
    {
        private string type;

        public string Type
        {
            get { return "Dirt"; }
            set { type = value; }
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
