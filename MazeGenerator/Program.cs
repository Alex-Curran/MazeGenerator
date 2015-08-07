using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace MazeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var maze = new Maze(50,50);
           
            maze.Generate();
            maze.Display();

        }
    }
}
