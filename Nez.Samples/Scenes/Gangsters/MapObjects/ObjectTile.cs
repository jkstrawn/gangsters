namespace Nez.Samples
{
    public class ObjectTile
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public ObjectTile(int id, int x, int y)
        {
            Id = id;
            X = x;
            Y = y;
        }
    }
}