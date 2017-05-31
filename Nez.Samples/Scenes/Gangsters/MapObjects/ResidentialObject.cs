using System.Collections.Generic;

namespace Nez.Samples
{
    public class ResidentialObject : MapObject
    {
        private static readonly List<int> SmallTileIndices = new List<int> { 262, 388, 298, 334, /*343,*/ 370 };
        private static readonly List<int> MediumTileIndices = new List<int> { 271, 379, 280, 307, 316 };
        private static readonly List<int> LargeTileIndices = new List<int> { 325, 352, 361, 397, 289 };

        public ResidentialObject(int x, int y, BuildingSize size) : base(x, y)
        {
            TileId = 624;

            var tileIndex = GetRandomTileIndex(size);

            GenerateNineTiles(tileIndex);
        }

        private int GetRandomTileIndex(BuildingSize size)
        {
            switch (size)
            {
                case BuildingSize.Small:
                    return SmallTileIndices.randomItem();
                case BuildingSize.Medium:
                    return MediumTileIndices.randomItem();
                case BuildingSize.Large:
                    return LargeTileIndices.randomItem();
            }

            return 1;
        }
    }
}