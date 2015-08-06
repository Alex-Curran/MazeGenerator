using System;
using System.Runtime.InteropServices;

namespace MazeGenerator
{
    public class Maze
    {
        private char[,] _grid;
        private int _height;
        private int _width;

        public Maze(int height, int width)
        {
            _height = height;
            _width = width;
            _grid = new char[height, width];

            Intialize();
        }

        private void Intialize()
        {
            for (var i = 0; i < _grid.GetLength(0); i++)
            {
                for (var j = 0; j < _grid.GetLength(1); j++)
                {
                    _grid[i, j] = 'X';
                    Console.Write(_grid[i, j]);
                }
                Console.Write('\n');
            }
        }

        public void Generate(int x, int y)
        {

        }
    }

}