using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace MazeGenerator
{
    public class Maze
    {
        private int height;
        private int width;
        private bool[,] northWall; 
        private bool[,] eastWall;
        private bool[,] southWall;
        private bool[,] westWall;
        private bool[,] map; // True:Visited False: Not Visited
        private readonly Random randomGenerator = new Random();

        public Maze(int height, int width)
        {
            this.height = height + 1;
            this.width  = width + 1;

            Intialize();
        }

        private void Intialize()
        {
            map = new bool[height + 1,width + 1];
            for (var i = 0; i < map.GetLength(0); i++)
            {
                for (var j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = false;
                }
            }
        }

        public void Generate(int x = 1, int y = 1)
        {
            map[x, y] = true;

            //while (!map[x-1,y] | !map[x+1,y] | !map[x,y+1] | !map[x,y-1])
            //{
            //    if()
            //}
        }

        internal void Display()
        {
            for (var x = 0; x < map.GetLength(0); x += 1)
            {
                for (var y = 0; y < map.GetLength(1); y += 1)
                {
                    // Draw borders around the outer layer of the maze 
                    if (x == 0 || x == width || y == 0 || y == width )
                    {
                        Console.Write("#");
                    }
                    else if (map[x, y])
                    {
                        Console.Write(" ");    
                    }
                    else
                    {
                        Console.Write("0");
                    }
                }
                Console.WriteLine();
            }
        }
    }

}