using DomeTD.Models;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DomeTD.Logic
{
    public interface IGameModel
    {
        IGameItem[,] GameMatrix { get; set; }
    }

    public class DomeLogic:IGameModel, IGameControl
    {
        public MainCharacter Hero { get; set; }
        public Dome Dome { get; set; }
        public Inventory Inventory { get; set; }
        public int AttackDamage { get; set; }
        private Dirt dirt;
        private Vibranium vibranium;
        private Metal metal;
        public enum Directions
        {
            up, down, left, right
        }
        public IGameItem[,] GameMatrix { get; set; }
        private Queue<string> levels;

        public DomeLogic()
        {
            AttackDamage = 10;
            Inventory = new Inventory();
            levels = new Queue<string>();
            Hero = new MainCharacter();
            metal = new Metal();
            dirt = new Dirt();
            vibranium = new Vibranium();
            Hero.DrillingPower = 5;
            Hero.DrillingpowerupgCost = 1;
            Hero.DrillingpowerupgCostInVib = 1;
            Inventory.Metal = 500;
            Inventory.Vibranium = 500;
            var lvls = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Levels"),
                "*.lvl");
            foreach (var item in lvls)
            {
                levels.Enqueue(item);
            }
            LoadNext(levels.Dequeue());
        }
        private void LoadNext(string path)
        {
            string[] lines = File.ReadAllLines(path);
            GameMatrix = new IGameItem[19,50];
            for (int i = 0; i < GameMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < GameMatrix.GetLength(1); j++)
                {
                    GameMatrix[i, j] = lvlConvert(lines[i][j]);
                }
            }
            
        }
      
        public IGameItem lvlConvert(char v)
        {
            switch (v)
            {
                case 'x': return new Border();
                case 'd': return new Dirt();
                case 'f': return new Floor();
                case 'm': return new Metal();
                case 'v': return new Vibranium();
                //case 'k': return new BGround();
                case 'c': return Hero;
                //case 'e': return new Enemy();
                //case 'b': return Dome;
                default: return null;
            }
        }
        private int[] WhereAmI()
        {
            for (int i = 0; i < GameMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < GameMatrix.GetLength(1); j++)
                {
                    if (GameMatrix[i, j].Type == "Hero")
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return new int[] { 1, 1 };
        }

        public void Move(Directions direction)
        {
            var coords = WhereAmI();
            int i = coords[0];
            int j = coords[1];
            int old_i = i;
            int old_j = j;
            switch (direction)
            {
                case Directions.up:
                    if (i - 1 >= 0)
                    {
                        i--;
                    }
                    break;
                case Directions.down:
                    if (i + 1 < GameMatrix.GetLength(0))
                    {
                        i++;
                    }
                    break;
                case Directions.left:
                    if (j - 1 >= 0)
                    {
                        j--;
                    }
                    break;
                case Directions.right:
                    if (j + 1 < GameMatrix.GetLength(1))
                    {
                        j++;
                    }
                    break;
                default:
                    break;
            }
            if (GameMatrix[i, j].Type == "Floor")
            {
                GameMatrix[i, j] = Hero;
                GameMatrix[old_i, old_j] = new Floor();
            }
        }
        public async void Dig(Directions direction)
        {
            var coords = WhereAmI();
            int i = coords[0];
            int j = coords[1];
            double dirtDigTime = (dirt.Thoughness / Hero.DrillingPower) * 1000;
            int dgt = (int)dirtDigTime;
            double vibraniumDigTime = (vibranium.Thoughness / Hero.DrillingPower) * 1000;
            int vgt = (int)vibraniumDigTime;
            double metalDigTime = (metal.Thoughness / Hero.DrillingPower) * 1000;
            int mgt = (int)metalDigTime;
            switch (direction)
            {
                case Directions.up:
                    if (GameMatrix[i - 1, j].Type != "Border")
                    {
                        i--;
                        if (GameMatrix[i, j].Type == "Dirt")
                        {
                            await Task.Delay(dgt);
                            Inventory.Dirt++;
                            GameMatrix[i, j] = new Floor();

                        }
                        else if (GameMatrix[i, j].Type == "Metal")
                        {
                            await Task.Delay(mgt);
                            Inventory.Metal++;
                            GameMatrix[i, j] = new Floor();
                        }

                        else if (GameMatrix[i, j].Type == "Vibranium")
                        {
                            await Task.Delay(vgt);
                            Inventory.Vibranium++;
                            GameMatrix[i, j] = new Floor();
                        }
                    }
                    break;
                case Directions.down:
                    if (GameMatrix[i + 1, j].Type != "Border")
                    {
                        i++;
                        if (GameMatrix[i, j].Type == "Dirt")
                        {
                            await Task.Delay(dgt);
                            Inventory.Dirt++;
                            GameMatrix[i, j] = new Floor();

                        }
                        else if (GameMatrix[i, j].Type == "Metal")
                        {
                            await Task.Delay(mgt);
                            Inventory.Metal++;
                            GameMatrix[i, j] = new Floor();
                        }

                        else if (GameMatrix[i, j].Type == "Vibranium")
                        {
                            await Task.Delay(vgt);
                            Inventory.Vibranium++;
                            GameMatrix[i, j] = new Floor();
                        }
                    }
                    break;
                case Directions.left:
                    if (GameMatrix[i, j - 1].Type != "Border")
                    {
                        j--;
                        if (GameMatrix[i, j].Type == "Dirt")
                        {
                            await Task.Delay(dgt);
                            Inventory.Dirt++;
                            GameMatrix[i, j] = new Floor();

                        }
                        else if (GameMatrix[i, j].Type == "Metal")
                        {
                            await Task.Delay(mgt);
                            Inventory.Metal++;
                            GameMatrix[i, j] = new Floor();
                        }

                        else if (GameMatrix[i, j].Type == "Vibranium")
                        {
                            await Task.Delay(vgt);
                            Inventory.Vibranium++;
                            GameMatrix[i, j] = new Floor();
                        }
                    }
                    break;
                case Directions.right:
                    if (GameMatrix[i, j + 1].Type != "Border")
                    {
                        j++;
                        if (GameMatrix[i, j].Type == "Dirt")
                        {
                            await Task.Delay(dgt);
                            Inventory.Dirt++;
                            GameMatrix[i, j] = new Floor();
                        }
                        else if (GameMatrix[i, j].Type == "Metal")
                        {
                            await Task.Delay(mgt);
                            Inventory.Metal++;
                            GameMatrix[i, j] = new Floor();
                        }

                        else if (GameMatrix[i, j].Type == "Vibranium")
                        {
                            await Task.Delay(vgt);
                            Inventory.Vibranium++;
                            GameMatrix[i, j] = new Floor();
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
    }
