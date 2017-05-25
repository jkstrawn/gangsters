using System.Collections.Generic;

namespace Nez.Samples
{
    public static class BusinessTypes
    {

        // small
        public static BusinessType PerfumeShop = new BusinessType(478, "perfume shop");
        public static BusinessType Pawnbroker = new BusinessType(487, "pawnbroker");
        public static BusinessType ButcherShop = new BusinessType(568, "butcher shop");
        public static BusinessType GiftShop = new BusinessType(433, "gift shop");
        public static BusinessType Ladieswear = new BusinessType(442, "ladieswear");
        public static BusinessType CateringSupplier = new BusinessType(523, "catering suppliers");

        // medium
        public static BusinessType ShoeStore = new BusinessType(451, "shoe store");
        public static BusinessType HardwareStore = new BusinessType(460, "hardware store");
        public static BusinessType TelegraphOffice = new BusinessType(469, "telegraph office");
        public static BusinessType FuneralDirectors = new BusinessType(496, "funeral directors");
        public static BusinessType BridalParlor = new BusinessType(532, "bridal parlor");
        public static BusinessType CheeseStore = new BusinessType(586, "cheese store");

        //large 
        public static BusinessType DetectiveAgency = new BusinessType(514, "detective agency");
        public static BusinessType WindowCleaners = new BusinessType(595, "window cleaners");
        public static BusinessType GardeningSuppliers = new BusinessType(541, "gardening suppliers");
        public static BusinessType Barbers = new BusinessType(550, "barbers");
        public static BusinessType Laundromat = new BusinessType(559, "laundromat");
        public static BusinessType ChinaStore = new BusinessType(604, "china store");


        public static readonly List<BusinessType> SmallBusinesses = new List<BusinessType>
        {
            PerfumeShop,
            Pawnbroker,
            ButcherShop,
            GiftShop,
            Ladieswear,
            CateringSupplier
        };

        public static readonly List<BusinessType> MediumBusinesses = new List<BusinessType>
        {
            ShoeStore,
            HardwareStore,
            TelegraphOffice,
            FuneralDirectors,
            BridalParlor,
            CheeseStore
        };

        public static readonly List<BusinessType> LargeBusinesses = new List<BusinessType>
        {
            DetectiveAgency,
            WindowCleaners,
            GardeningSuppliers,
            Barbers,
            Laundromat,
            ChinaStore
        };
    }

    public class BusinessType
    {
        public int SpriteIndex { get; set; }
        public string Name { get; set; }

        public BusinessType(int sprite, string name)
        {
            SpriteIndex = sprite;
            Name = name;
        }
    }
}