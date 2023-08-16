using MonopolyBoxes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyBoxes.Helpers
{
    public class GroupManager
    {
        public List<List<Pallet>> GroupPalletsByExpirationDate(List<Pallet> pallets)
        {
            var groupedPallets = new List<List<Pallet>>();
            foreach (var pallet in pallets)
            {
                bool added = false;
                foreach (var group in groupedPallets)
                {
                    if (group.Count > 0 && pallet.CalculateExpirationDate() == group[0].CalculateExpirationDate())
                    {
                        group.Add(pallet);
                        added = true;
                        break;
                    }
                }
                if (!added)
                {
                    var newGroup = new List<Pallet>();
                    newGroup.Add(pallet);
                    groupedPallets.Add(newGroup);
                }
            }
            return groupedPallets;
        }
    }
}
