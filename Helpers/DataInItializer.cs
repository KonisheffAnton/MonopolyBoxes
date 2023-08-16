using MonopolyBoxes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyBoxes.Helpers
{
    public class DataInItializer
    {
        private Random random = new Random();

        public List<Pallet> GeneratePalletsAndBoxes(int numberOfPallets, int maxNumberOfBoxes)
        {
            var pallets = new List<Pallet>();

            for (int i = 0; i < numberOfPallets; i++)
            {
                var pallet = new Pallet
                {
                    Width = random.Next(80, 100),
                    Height = random.Next(100, 120),
                    Depth = random.Next(10, 12)
                };

                int numberOfBoxes = random.Next(1, maxNumberOfBoxes + 1);
                for (int j = 0; j < numberOfBoxes; j++)
                {
                    var box = new Box
                    {
                        Width = random.Next(10, 50),
                        Height = random.Next(10, 50),
                        Depth = random.Next(10, 50),
                        Weight = random.Next(1, 20),
                        ExpirationDate = DateOnly.FromDateTime(DateTime.Today).AddDays(random.Next(1, 100)),
                        DateOfManufacture = DateOnly.FromDateTime(DateTime.Today).AddDays(-random.Next(1, 50))
                    };
                    pallet.Boxes.Add(box);
                }
                pallets.Add(pallet);
            }

            return pallets;
        }
    }
}
