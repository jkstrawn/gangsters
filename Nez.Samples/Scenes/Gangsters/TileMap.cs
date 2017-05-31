namespace Nez.Samples
{
    public class TileMap
    {
        public Tile[][] Tiles { get; set; }

        public TileMap()
        {
            Tiles = new Tile[100][];
            for (var x = 0; x < 100; x++)
            {
                Tiles[x] = new Tile[100];
                for (var y = 0; y < 100; y++)
                {
                    Tiles[x][y] = new Tile(x, y, 1);
                }
            }
        }
    }
}