using MonopolyBoxes.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyBoxes.Entities
{
    public class Pallet : Container
    {
        public DateOnly? ExpirationDate { get => this.CalculateExpirationDate(); }

        public List<Box> Boxes { get; set; } = new List<Box>();

        public DateOnly? CalculateExpirationDate()
        {
            DateOnly? earliestExpiry = null;
            foreach (var box in Boxes)
            {
                if (box.ExpirationDate is not null)
                {
                    if ((earliestExpiry is null) || box.ExpirationDate < earliestExpiry) earliestExpiry = box.ExpirationDate;
                }
                if (box.DateOfManufacture is not null)
                {
                    if ((earliestExpiry is null) || box.CalculateExpirationDate() < earliestExpiry) earliestExpiry = box.CalculateExpirationDate();
                }
            }
            return earliestExpiry;
        }

        public double CalculateWeight()
        {
            double totalPalettWeight = 30;
            foreach (var box in Boxes)
            {
                totalPalettWeight += box.Weight;
            }
            return totalPalettWeight;
        }

        public double CalculateVolume()
        {
            double totalPalletVolume = Width * Height * Depth;
            foreach (var box in Boxes)
            {
                totalPalletVolume += box.CalculateVolume();
            }
            return totalPalletVolume;
        }

    }
}
