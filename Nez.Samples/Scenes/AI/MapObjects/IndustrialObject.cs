using System;
using System.Collections.Generic;

namespace Nez.Samples
{
    public class IndustrialObject : MapObject
    {
        private static readonly List<int> SmallTileIndices = new List<int> { 622, 631, 640, 649, 658, 667, 676, 685 };
        private static readonly List<int> MediumTileIndices = new List<int> { 271, 379, 280, 307, 316 };
        private static readonly List<int> LargeTileIndices = new List<int> { 325, 352, 361, 397, 289 };

        public IndustrialObject(int x, int y, int id) : base(x, y)
        {
            TileId = 624;

            var tileIndex = GetRandomTileIndex(id);

            GenerateNineTiles(tileIndex);
        }

        private int GetRandomTileIndex(int id)
        {
            return SmallTileIndices[Math.Min(id, SmallTileIndices.Count - 1)];
        }
    }
}