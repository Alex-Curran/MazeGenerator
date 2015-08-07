
namespace MazeGenerator
{
    class Cell
    {
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
        public bool NorthBorder { get; set; }
        public bool SouthBorder { get; set; }
        public bool EastBorder { get; set; }
        public bool WestBorder { get; set; }
        public States State { get; set; }
        
        public Cell(int x, int y)
        {
            PositionX = x;
            PositionY = y;

            NorthBorder = true;
            SouthBorder = true;
            EastBorder = true;
            WestBorder = true;
        }

        void Print()
        {
            
        }

    }
}
