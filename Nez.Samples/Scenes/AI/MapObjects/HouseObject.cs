using System.Collections.Generic;

namespace Nez.Samples
{
    public class HouseObject : MapObject
    {
        private static readonly List<int> SmallTileIndices = new List<int> { 250, 251, 252, 253, 254, 255};
        private static readonly List<int> LargeTileIndices = new List<int> { 256, 257, 258, 259, 260, 261 };

        public HouseObject(int x, int y) : base(x, y)
        {

        }
    }
}