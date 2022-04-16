using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DomeTD.Logic.DomeLogic;

namespace DomeTD.Logic
{
    internal interface IGameControl
    {
        void Move(Directions direction);
        void Dig(Directions direction);
    }
}
