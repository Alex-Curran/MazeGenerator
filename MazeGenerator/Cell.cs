
namespace MazeGenerator
{
    class Cell
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public States State { get; set; }

        public Cell(int x, int y)
        {
            PositionX = x;
            PositionY = y; 
        }

    }
}
