using MonopolyBoxes.Helpers;

DataInItializer dataInitializer = new DataInItializer();
GroupManager groupManager = new GroupManager();

var pallets = dataInitializer.GeneratePalletsAndBoxes(5, 10);

var groupedPallets = groupManager.GroupPalletsByExpirationDate(pallets);

groupedPallets.Sort((list1, list2) =>
{
    var expiryDate1 = list1[0].ExpirationDate;
    var expiryDate2 = list2[0].ExpirationDate;
    return expiryDate1.GetValueOrDefault().CompareTo(expiryDate2.GetValueOrDefault());
});


foreach (var group in groupedPallets)
{
    Console.WriteLine($"Паллеты со сроком годности: {group[0].ExpirationDate}");
    foreach (var pallet in group)
    {
        Console.WriteLine($" Вес паллеты : {pallet.CalculateWeight()}");
    }
    Console.WriteLine();
}

pallets.Sort((pallet1, pallet2) =>
{
    var expiryDate1 = pallet1.ExpirationDate;
    var expiryDate2 = pallet2.ExpirationDate;
    return expiryDate1.GetValueOrDefault().CompareTo(expiryDate2.GetValueOrDefault());
});

var topPallets = pallets.Take(3).OrderBy(pallet => pallet.CalculateVolume()).ToList();


Console.WriteLine("\n Паллеты с наибольшим сроком годности:");
foreach (var pallet in topPallets)
{
    Console.WriteLine($"Объем паллеты: {pallet.CalculateVolume()}");
}

