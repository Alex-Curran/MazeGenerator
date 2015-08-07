using System;
using System.Runtime.InteropServices;

namespace MazeGenerator
{
    public class Maze
    {
        private char[,] _grid;
        private int _height;
        private int _width;
        private bool[,] _visited;
        private Random randomGenerator = new Random();

        public Maze(int height, int width)
        {
            _height = height;
            _width = width;
            _grid = new char[height, width];

            Intialize();
        }

        private void Intialize()
        {
            _visited = new bool[_height,_width];
            for (var i = 0; i < _grid.GetLength(0); i++)
            {
                for (var j = 0; j < _grid.GetLength(1); j++)
                {
                    _visited[i, j] = false;
                    //Console.Write(_grid[i, j]);
                }
            }
        }

        public void Generate(int x = 5, int y = 5)
        {
            _visited[x, y] = true;
            if (x == 0 || y == 0)
            {
                x = 5;
                y = 5; 
            }
            // Check up, down, left, right if it was visited (Randomly)
            while(!_visited[x+1,y] | !_visited[x-1,y] |!_visited[x,y-1]| !_visited[x,y+1])
            {
                var random = randomGenerator.Next(0, 4);
                if (random == 0 && !_visited[x + 1, y])
                {
                    _visited[x + 1, y] = true;
                    _grid[x + 1, y] = ' ';
                    Generate(x+1,y);
                    break;
                }
                else if (random == 1 && !_visited[x - 1, y])
                {
                    _visited[x - 1, y] = true;
                    _grid[x - 1, y] = ' ';
                    Generate(x - 1, y);
                    break;
                } 
                else if (random == 2 &&!_visited[x, y-1])
                {
                    _visited[x, y - 1] = true;
                    _grid[x, y - 1 ] = ' ';
                    Generate(x, y - 1);
                    break;

                } 
                else if (random == 3 &&!_visited[x, y+1])
                {
                    _visited[x, y + 1] = true;
                    _grid[x, y + 1] = ' ';
                    Generate(x, y + 1);
                    break;
                }
            }
        }

        internal void Display()
        {
            for (var x = 0; x < _grid.GetLength(0); x += 1)
            {
                for (var y = 0; y < _grid.GetLength(1); y += 1)
                {
                    Console.Write(_visited[x, y] == false ? "X" : " ");
                }
                Console.WriteLine();
            }
        }
    }

}