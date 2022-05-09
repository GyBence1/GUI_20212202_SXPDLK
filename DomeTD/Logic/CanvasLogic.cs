using DomeTD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomeTD.Logic
{
    public interface ICanvasItem
    {
        Dome Dome { get; set; } 
        List<Laser> Lasers { get; set; }
        List<Enemy> Enemies { get; set; }
    }
    public class CanvasLogic : ICanvasItem
    {
        public Dome Dome { get; set; }
        public List<Laser> Lasers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Enemy> Enemies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public CanvasLogic()
        {
            Dome=new Dome();
        }
    }
}
