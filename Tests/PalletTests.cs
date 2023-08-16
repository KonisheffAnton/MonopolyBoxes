using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class PalletTests
    {
        [Fact]
        public void Pallet_CalculateExpiryDate_NoBoxes()
        {
            var pallet = new Pallet();

            var expiryDate = pallet.CalculateExpirationDate();

            Assert.Null(expiryDate);
        }

        [Fact]
        public void Pallet_CalculateExpiryDate_SingleBox()
        {
            var box = new Box { ExpirationDate = new DateOnly(2023, 6, 1) };
            var pallet = new Pallet();
            pallet.Boxes.Add(box);

            var expiryDate = pallet.CalculateExpirationDate();

            Assert.Equal(new DateOnly(2023, 6, 1), expiryDate);
        }

        [Fact]
        public void Pallet_CalculateWeight()
        {
            var box1 = new Box { Weight = 10 };
            var box2 = new Box { Weight = 15 };
            var pallet = new Pallet();
            pallet.Boxes.Add(box1);
            pallet.Boxes.Add(box2);

            var weight = pallet.CalculateWeight();

            Assert.Equal(55, weight);
        }

        [Fact]
        public void Pallet_Volume_NoBoxes()
        {
            var pallet = new Pallet { Width = 100, Height = 100, Depth = 100 };

            var volume = pallet.CalculateVolume();

            Assert.Equal(1000000, volume);
        }

        [Fact]
        public void Pallet_Volume_WithBoxes()
        {
            var box1 = new Box { Width = 10, Height = 10, Depth = 10 };
            var box2 = new Box { Width = 20, Height = 20, Depth = 20 };
            var pallet = new Pallet { Width = 100, Height = 100, Depth = 100 };
            pallet.Boxes.Add(box1);
            pallet.Boxes.Add(box2);

            var volume = pallet.CalculateVolume();

            Assert.Equal(1009000, volume);
        }
    }
}
