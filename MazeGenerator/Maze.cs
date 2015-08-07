using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace MazeGenerator
{
    public class Maze
    {
        private int height;
        private int width;
        private Cell[,] map; 
        private readonly Random randomGenerator = new Random();

        public Maze(int height, int width)
        {
            this.height = height + 1;
            this.width  = width + 1;

            Intialize();
        }

        private void Intialize()
        {
            map = new Cell[height,width];
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    map[i, j] = new Cell(i, j);
                    if (i == 0 || i == width - 1 || j == 0 || j == width - 1)
                    {
                        map[i, j].State = States.Border;
                    }
                    else
                    {
                        map[i, j].State = States.NotVisited;
                    }
                }
            }
        }

        public void Generate(int x = 1, int y = 1)
        {
            // Select the current cell map[x,y] is the current cell
            Cell currentCell = map[x, y];
          
            // This cell has four neighbors, find its unvisited neighbors
            List<Cell> unvisitedNeighbors = new List<Cell>();
            unvisitedNeighbors = CheckNeighbors(currentCell,unvisitedNeighbors);

            // Choose one of the unvisited neighbors and mark it as visited, then start over with as the current cell
            if (unvisitedNeighbors.Count != 0)
            {
                var random = randomGenerator.Next(unvisitedNeighbors.Count);
                var selectedNeighbor = unvisitedNeighbors[random];
                selectedNeighbor.State = States.Visited;
                Generate(selectedNeighbor.PositionX, selectedNeighbor.PositionY);
            }

        }

        /* *
         * Returns a List of neighboring cells 
         * 
         * */
        private List<Cell> CheckNeighbors(Cell currentCell, List<Cell> unvisitedNeighbors )
        {
           
            if (map[currentCell.PositionX + 1, currentCell.PositionY].State == States.NotVisited)
            {
                unvisitedNeighbors.Add(map[currentCell.PositionX + 1, currentCell.PositionY]);
            }
            if (map[currentCell.PositionX - 1, currentCell.PositionY].State == States.NotVisited)
            {
                unvisitedNeighbors.Add(map[currentCell.PositionX - 1, currentCell.PositionY]);
            }
            if (map[currentCell.PositionX ,currentCell.PositionY + 1].State == States.NotVisited)
            {
                unvisitedNeighbors.Add(map[currentCell.PositionX, currentCell.PositionY + 1]);
            }
            if (map[currentCell.PositionX, currentCell.PositionY - 1].State == States.NotVisited)
            {
                unvisitedNeighbors.Add(map[currentCell.PositionX, currentCell.PositionY - 1]);
            }

            return unvisitedNeighbors;
        }

        internal void DisplayMaze()
        {
            for (var i = 0; i < height; i += 1)
            {
                for (var j = 0; j < width; j += 1)
                {
                    if (map[i, j].State == States.Border)
                    {
                        Console.Write("#");
                    }
                    else if(map[i,j].State == States.NotVisited)
                    {
                        Console.Write("#");
                    }
                    else if (map[i, j].State == States.Visited)
                    {
                        Console.Write(" ");
                    }
                }
               Console.WriteLine();
            }
        }
    }

}