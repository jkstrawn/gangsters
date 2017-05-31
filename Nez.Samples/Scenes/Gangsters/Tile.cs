namespace Nez.Samples
{
    public class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Type { get; set; }

        public Tile(int x, int y, int type)
        {
            X = x;
            Y = y;
            Type = type;
        }
    }
}