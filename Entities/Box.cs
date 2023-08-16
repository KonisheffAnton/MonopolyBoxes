using MonopolyBoxes.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyBoxes.Entities
{
    public class Box : Container
    {
        public DateOnly? ExpirationDate { get; set; }
        public DateOnly? DateOfManufacture { get; set; }

        public DateOnly? CalculateExpirationDate()
        {
            if (DateOfManufacture is not null)
            {
                return DateOfManufacture.Value.AddDays(100);
            }
            return ExpirationDate;
        }

        public double CalculateVolume()
        {
            return Width * Height * Depth;
        }
    }
}
