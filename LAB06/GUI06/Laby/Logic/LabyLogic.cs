using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laby.Logic
{
    public class LabyLogic : IGameModel, IGameControl
    {
        public enum LabyItem
        {
            player, wall, floor, door
        } 

        public enum Direction
        {
            up, down, left, right
        }

        public LabyItem[,] GameMatrix { get; set; }

        private Queue<string> levels;

        public LabyLogic()
        {
            levels = new Queue<string>();
            var lvls = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Levels"), "*.lvl");

            foreach (var item in lvls)
            {
                levels.Enqueue(item);
            }
            LoadNext(levels.Dequeue());
        }

        public void Move(Direction direction)
        {
            var coords = WhereAmI();
            int i = coords[0];
            int j = coords[1];
            int old_i = i;
            int old_j = j;

            switch (direction)
            {
                case Direction.up:
                    if (i - 1 >= 0)
                    {
                        i--;
                    }
                    break;
                case Direction.down:
                    if (i + 1 < GameMatrix.GetLength(0))
                    {
                        i++;
                    }
                    break;
                case Direction.left:
                    if (j - 1 >= 0)
                    {
                        j--;
                    }
                    break;
                case Direction.right:
                    if (j + 1 < GameMatrix.GetLength(1))
                    {
                        j++;
                    }
                    break;
                default:
                    break;
            }

            if (GameMatrix[i, j] == LabyItem.floor)
            {
                GameMatrix[i, j] = LabyItem.player;
                GameMatrix[old_i, old_j] = LabyItem.floor;
            }
            else if (GameMatrix[i, j] == LabyItem.door)
            {
                if (levels.Count > 0)
                    LoadNext(levels.Dequeue());
            }
        }

        private int[] WhereAmI()
        {
            for (int i = 0; i < GameMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < GameMatrix.GetLength(1); j++)
                {
                    if (GameMatrix[i, j] == LabyItem.player)
                    {
                        return new int[] { i, j };
                    }
                }
            }

            return new int[] { -1, -1 };
        }

        private void LoadNext(string path)
        {
            string[] lines = File.ReadAllLines(path);
            GameMatrix = new LabyItem[int.Parse(lines[1]), int.Parse(lines[0])];
            for (int i = 0; i < GameMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < GameMatrix.GetLength(1); j++)
                {
                    GameMatrix[i, j] = ConvertToEnum(lines[i + 2][j]);
                }
            }
        }

        private LabyItem ConvertToEnum(char v)
        {
            return v switch
            {
                'e' => LabyItem.wall,
                'S' => LabyItem.player,
                'F' => LabyItem.door,
                _ => LabyItem.floor,
            };
        }
    }
}
