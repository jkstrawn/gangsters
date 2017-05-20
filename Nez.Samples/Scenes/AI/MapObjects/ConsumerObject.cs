using System;
using System.Collections.Generic;

namespace Nez.Samples
{
    public class ConsumerObject : MapObject
    {
        private static readonly List<int> SmallTileIndices = new List<int> { 478, 487, 568, 433, 442, 523 /*505*/ };
        private static readonly List<int> MediumTileIndices = new List<int> { 451, 460, 469, 496, 532, 586 };
        private static readonly List<int> LargeTileIndices = new List<int> { 514, 595, 541, 550, 559, 604 };

        public ConsumerObject(int x, int y, BuildingSize size) : base(x, y)
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