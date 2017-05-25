namespace Nez.Samples
{
    public class BusinessObject : MapObject
    {
        public BusinessType BusinessType { get; set; }

        public BusinessObject(int x, int y, BuildingSize size) : base(x, y)
        {
            TileId = 1;
            BusinessType = GetRandomBusiness(size);

            GenerateNineTiles(BusinessType.SpriteIndex);
        }

        private BusinessType GetRandomBusiness(BuildingSize size)
        {
            switch (size)
            {
                case BuildingSize.Small:
                    return BusinessTypes.SmallBusinesses.randomItem();
                case BuildingSize.Medium:
                    return BusinessTypes.MediumBusinesses.randomItem();
                case BuildingSize.Large:
                    return BusinessTypes.LargeBusinesses.randomItem();
            }

            return BusinessTypes.SmallBusinesses[0];
        }
    }
}