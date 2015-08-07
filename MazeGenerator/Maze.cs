using System;
using System.Collections.Generic;
using System.IO;

namespace MazeGenerator
{
    public class Maze
    {
        private readonly int height;
        private readonly int width;
        private Cell[,] mazeMap;
        private Stack<Cell> stack;
        private readonly Random randomGenerator = new Random();

        public Maze(int height, int width)
        {
            this.height = height + 1;
            this.width = width + 1;

            Intialize();
        }

        private void Intialize()
        {
            mazeMap = new Cell[height, width];
            stack = new Stack<Cell>();
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    mazeMap[i, j] = new Cell(i, j);
                    if (i == 0 || i == width - 1 || j == 0 || j == width - 1)
                    {
                        mazeMap[i, j].State = States.Border;
                    }
                    else
                    {
                        mazeMap[i, j].State = States.NotVisited;
                    }
                }
            }
        }

        public void Generate(int x = 1, int y = 1)
        {
            do
            {
                var currentCell = mazeMap[x, y];
                currentCell.State = States.Visited;
             
                // This cell has four neighbors, find its unvisited neighbors
                var unvisitedNeighbors = new List<Cell>();
                unvisitedNeighbors = CheckNeighbors(currentCell, unvisitedNeighbors);

                // Choose one of the unvisited neighbors and mark it as visited, then start over with it as the current cell
                if (unvisitedNeighbors.Count != 0)
                {
                    var random = randomGenerator.Next(unvisitedNeighbors.Count);
                    var selectedNeighbor = unvisitedNeighbors[random];
                    CarveMap(currentCell, selectedNeighbor);
                    selectedNeighbor.State = States.Visited;
                    stack.Push(currentCell);
                    x = selectedNeighbor.PositionX;
                    y = selectedNeighbor.PositionY;
                }
                else
                {
                    var previousCell = stack.Pop();
                    x = previousCell.PositionX;
                    y = previousCell.PositionY;
                }

                PrintMazeToFile(mazeMap, currentCell);
            } while (stack.Count != 0);
        }

        private void CarveMap(Cell currentCell, Cell selectedNeighbor)
        {
            var xDifference = currentCell.PositionX - selectedNeighbor.PositionX;
            var yDifference = currentCell.PositionY - selectedNeighbor.PositionY;
            Direction direction;

            if (xDifference != 0)
            {
                direction = xDifference > 0 ? Direction.Up : Direction.Down;
            }
            else
            {
                direction = yDifference > 0 ? Direction.Left : Direction.Right;
            }

            switch (direction)
            {
                case Direction.Up:
                {
                    selectedNeighbor.NorthBorder = false;
                    break;
                }
                case Direction.Down:
                {
                    selectedNeighbor.SouthBorder = false;
                    break;
                }
                case Direction.Left:
                {
                    selectedNeighbor.EastBorder = false;
                    break;
                }
                case Direction.Right:
                {
                    selectedNeighbor.WestBorder = false;
                    break;
                }
            }
        }

        private void PrintMazeToFile(Cell[,] map, Cell currentCell)
        {
            var path = @"maze.txt";

            // Create a file to write to. 
            using (var sw = File.AppendText(path))
            {
                for (var i = 0; i < height; i += 1)
                {
                    for (var j = 0; j < width; j += 1)
                    {
                        if (map[currentCell.PositionX, currentCell.PositionY] == map[i, j])
                        {
                            sw.Write("*");
                        }
                        else if (currentCell.State == States.Border)
                        {
                            sw.Write("#");
                        }
                        else
                        {
                            currentCell.Print();
                        }
                        //else if (map[i, j].State == States.NotVisited)
                        //{
                        //    sw.Write("#");
                        //}
                        //else if (map[i, j].State == States.Visited)
                        //{
                        //    sw.Write(" ");
                        //}
                    }
                    sw.WriteLine();
                }
                sw.WriteLine();
            }
        }

        /* *
         * Returns a List of neighboring cells 
         * 
         * */

        private List<Cell> CheckNeighbors(Cell currentCell, List<Cell> unvisitedNeighbors)
        {
            if (mazeMap[currentCell.PositionX + 1, currentCell.PositionY].State == States.NotVisited)
            {
                unvisitedNeighbors.Add(mazeMap[currentCell.PositionX + 1, currentCell.PositionY]);
            }
            if (mazeMap[currentCell.PositionX - 1, currentCell.PositionY].State == States.NotVisited)
            {
                unvisitedNeighbors.Add(mazeMap[currentCell.PositionX - 1, currentCell.PositionY]);
            }
            if (mazeMap[currentCell.PositionX, currentCell.PositionY + 1].State == States.NotVisited)
            {
                unvisitedNeighbors.Add(mazeMap[currentCell.PositionX, currentCell.PositionY + 1]);
            }
            if (mazeMap[currentCell.PositionX, currentCell.PositionY - 1].State == States.NotVisited)
            {
                unvisitedNeighbors.Add(mazeMap[currentCell.PositionX, currentCell.PositionY - 1]);
            }

            return unvisitedNeighbors;
        }

        //internal void DisplayMaze()
        //{
        //    for (var i = 0; i < height; i += 1)
        //    {
        //        for (var j = 0; j < width; j += 1)
        //        {
        //            if (mazeMap[i, j].State == States.Border)
        //            {
        //                Console.Write("#");
        //            }
        //            else if (mazeMap[i, j].State == States.NotVisited)
        //            {
        //                Console.Write("#");
        //            }
        //            else if (mazeMap[i, j].State == States.Visited)
        //            {
        //                Console.Write(" ");
        //            }
        //        }
        //        Console.WriteLine();
        //    }
        //}
    }
}