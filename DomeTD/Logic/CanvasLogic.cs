using DomeTD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class CanvasLogic : ICanvasItem, INotifyPropertyChanged
    {
        private double areaHeight;
        private double areaWidth;
        public Dome Dome { get; set; }
        public List<Laser> Lasers { get; set; }
        public List<Enemy> Enemies { get; set; }
        private double currentDMG;

        public double CurrentDMG
        {
            get { return currentDMG; }
            set { currentDMG = value; OnPropertyChanged("currentDMG"); }
        }

        private int weaponUpgradeCost;

        public int WeaponUpgradeCost
        {
            get { return weaponUpgradeCost; }
            set { weaponUpgradeCost = value; OnPropertyChanged("WeaponUpgradeCost"); }
        }
        public CanvasLogic(double areaWidth,double areaHeight)
        {
            this.areaWidth=areaWidth;
            this.areaHeight=areaHeight;
            Dome=new Dome(0,areaHeight);
            Enemies=new List<Enemy>();
            Lasers=new List<Laser>();
            currentDMG = 5;
            weaponUpgradeCost = 1;
            
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }

        public void NewEnemy()
        {
            Enemies.Add(new Enemy(areaWidth,areaHeight));
        }
        public async void SpawnEnemies()
        {
            for (int i = 0; i < 5; i++)
            {
                await Task.Delay(1000);
                NewEnemy();
            }
        }

        public void MoveEnemy()
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                if (!Enemies[i].IsCollision(Dome))
                {
                    Enemies[i].posX-=10;
                }
                else
                {
                    Enemies.Remove(Enemies[i]);
                }
            }
        }
        public void AddLaser()
        {
            if (Enemies.Count>0)
            {
                Lasers.Add(new Laser(Dome.Area.Bounds.Right, Dome.Area.Bounds.Bottom-(Dome.Area.Bounds.Size.Height/2)+15));
            }
        }
        public void Shoot()
        {
            if (Enemies.Count>0)
            {
                for (int i = 0; i < Lasers.Count; i++)
                {
                    Lasers[i].posX+=Lasers[i].AttackSpeed;
                    for (int j = 0; j < Enemies.Count; j++)
                    {
                        if (Lasers[i].IsCollision(Enemies[j]))
                        {
                            if (Enemies[j].Health>0)
                            {
                                Enemies[j].Health-=Lasers[i].AttackDamage*10;
                                ;
                            }
                            else
                            {
                                Enemies.RemoveAt(j);
                            }
                            Lasers.RemoveAt(i);
                        }
                    }
                }
            }
           
        }
    }
}
