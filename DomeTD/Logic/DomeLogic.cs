using DomeTD.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomeTD.Logic
{
    public interface IGameModel
    {
        IGameItem[,] GameMatrix { get; set; }
    }

    public class DomeLogic:IGameModel,IGameControl
    {
        public enum Directions
        {
            up, down, left, right
        }
        public IGameItem[,] GameMatrix { get; set; }
        private Queue<string> levels;

        public DomeLogic()
        {
            levels = new Queue<string>();
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
            GameMatrix = new IGameItem[30,50];
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
                case 'k': return new BGround();
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
            return new int[] { -1, -1 };
        }

        public void Move(Directions direction)
        {
            throw new NotImplementedException();
        }
    }
}
