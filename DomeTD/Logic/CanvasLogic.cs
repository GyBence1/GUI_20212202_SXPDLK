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
        private double areaHeight;
        private double areaWidth;
        public Dome Dome { get; set; }
        public List<Laser> Lasers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Enemy> Enemies { get; set; }
        public CanvasLogic(double areaWidth,double areaHeight)
        {
            this.areaWidth=areaWidth;
            this.areaHeight=areaHeight;
            Dome=new Dome(0,areaHeight);
            Enemies=new List<Enemy>();
            Enemies.Add(new Enemy(areaWidth, areaHeight));
        }
        public void NewEnemy()
        {
            Enemies.Add(new Enemy(areaWidth,areaHeight));
        }
    }
}
