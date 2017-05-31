using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Nez.Tiled;

namespace Nez.Samples
{
    public class CustomMapComponent : RenderableComponent, IUpdatable
    {
        private TiledTileLayer Layer { get; set; }
        private TiledMap Map { get; set; }
        private List<MapObject> GameObjects { get; set; } = new List<MapObject>();

        public override float width => Map.width * Map.tileWidth;
        public override float height => Map.height * Map.tileHeight;

        public CustomMapComponent(Texture2D texture)
        {
            var tileSize = 16;
            var mapWidth = 48;
            var mapHeight = 28;
            var numTiles = mapWidth * mapHeight;

            Map = new TiledMap(1, mapWidth, mapHeight, tileSize, tileSize);
            Map.createTileset(texture, 1, tileSize, tileSize, true, 0, 0);


            var tiles = new TiledTile[numTiles];
            Layer = new TiledTileLayer(Map, "", mapWidth, mapHeight, tiles);

            for (var i = 0; i < numTiles; i++)
            {
                var tile = new TiledTile(i);
                tile.x = i % mapWidth;
                tile.y = i / mapWidth;
                tile.id = 1;
                Layer.setTile(tile);
            }

            CreateObjects(mapWidth, mapHeight);

            foreach (var obj in GameObjects)
            {
                foreach (var tile in obj.Tiles)
                {
                    var objectTile = Layer.getTile(tile.X, tile.Y);
                    objectTile.id = tile.Id;
                }
            }
        }

        private void CreateObjects(int mapWidth, int mapHeight)
        {
            var roadOffsetX = 0;

            for (var x = 0; x < mapWidth; x++)
            {
                var roadOffsetY = 0;
                if ((x + 1) % 7 == 0)
                {
                    roadOffsetX++;
                }

                for (var y = 0; y < mapHeight; y++)
                {

                    if ((y + 1) % 7 == 0)
                    {
                        roadOffsetY++;
                    }

                    if ((x + 1) % 7 == 0 && (y + 1) % 7 == 0)
                    {
                        var obj = new RoadObject(x, y, RoadDirection.Center);
                        GameObjects.Add(obj);
                        continue;
                    }
                    if ((x + 1) % 7 == 0)
                    {
                        var obj = new RoadObject(x, y, RoadDirection.Horizontal);
                        GameObjects.Add(obj);
                        continue;
                    }
                    if ((y + 1) % 7 == 0)
                    {
                        var obj = new RoadObject(x, y, RoadDirection.Vertical);
                        GameObjects.Add(obj);
                        continue;
                    }

                    if (IsABuilding(x, roadOffsetX, y, roadOffsetY))
                    {
                        CreateBuildingObject(mapWidth, mapHeight, x, y);
                    }
                }
            }
        }

        private void CreateBuildingObject(int mapWidth, int mapHeight, int x, int y)
        {
            var size = GetSize(mapWidth, mapHeight, x, y);
            var isResidential = Random.nextInt(2) > 0;

            if (isResidential)
            {
                var obj = new ResidentialObject(x, y, size);
                GameObjects.Add(obj);
            }
            else
            {
                var obj = new BusinessObject(x, y, size);
                GameObjects.Add(obj);
            }
        }

        private BuildingSize GetSize(int mapWidth, int mapHeight, int x, int y)
        {
            if (x < 6 || x > mapWidth - 7 || y < 3 || y > mapHeight - 5)
            {
                return BuildingSize.Small;
            }

            if (x < 13 || x > mapWidth - 14 || y < 7 || y > mapHeight - 9)
            {
                return BuildingSize.Medium;
            }

            return BuildingSize.Large;
        }

        private static bool IsABuilding(int x, int roadOffsetX, int y, int roadOffsetY)
        {
            return (x - roadOffsetX + 3) % 3 == 0 && (y - roadOffsetY + 3) % 3 == 0;
        }

        public override void render(Graphics graphics, Camera camera)
        {
            Layer.draw(graphics.batcher, entity.transform.position + _localOffset, layerDepth, camera.bounds);
        }

        void IUpdatable.update()
        {
            //tiledMap.update();
        }
    }
}