using System.Collections.Generic;

namespace Nez.Samples
{
    public abstract class MapObject
    {
        public int TileId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public List<ObjectTile> Tiles { get; set; } = new List<ObjectTile>();

        public MapObject(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void GenerateNineTiles(int index)
        {
            for (var _x = 0; _x < 3; _x++)
            {
                for (var _y = 0; _y < 3; _y++)
                {
                    var i = _x + _y * 3;
                    var tile = new ObjectTile(i + index, X + _x, Y + _y);
                    Tiles.Add(tile);
                }
            }
        }
    }

    public enum BuildingSize
    {
        Small,
        Medium,
        Large
    }
}