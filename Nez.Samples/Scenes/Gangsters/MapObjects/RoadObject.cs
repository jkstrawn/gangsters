namespace Nez.Samples
{
    public class RoadObject : MapObject
    {
        public RoadObject(int x, int y, RoadDirection dir) : base(x, y)
        {
            var tile = new ObjectTile(0, x, y);

            switch (dir)
            {
                case RoadDirection.Vertical:
                    tile.Id = 67;
                    break;
                case RoadDirection.Horizontal:
                    tile.Id = 68;
                    break;
                case RoadDirection.Center:
                    tile.Id = 77;
                    break;
            }

            Tiles.Add(tile);
        }
    }

    public enum RoadDirection
    {
        Horizontal,
        Vertical,
        Center
    }
}