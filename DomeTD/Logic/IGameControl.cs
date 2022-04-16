using DomeTD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DomeTD.Logic.DomeLogic;

namespace DomeTD.Logic
{
    public interface IGameControl
    {
        void Move(Directions direction);
        void Dig(Directions direction);
        Inventory Inventory{get;set;}
    }
}
