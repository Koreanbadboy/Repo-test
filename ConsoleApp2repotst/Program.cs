using System;
using System.Collections.Generic;

public class BjjInventoryItem
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice {get; set; }
    public decimal TotalValue => Quantity * UnitPrice;
}

class Program
{
    static void Main(string[] args)
    {

        var bjjinventory = new List<BjjInventoryItem>
       {
           new BjjInventoryItem { Name = "Gi", Quantity = 10, UnitPrice = 1200m },
           new BjjInventoryItem { Name = "Bälte", Quantity = 10, UnitPrice = 99m },
           new BjjInventoryItem { Name = "Tandskydd", Quantity = 20, UnitPrice = 49m },
           new BjjInventoryItem { Name = "Rash Guard", Quantity = 15, UnitPrice = 299m },
           new BjjInventoryItem { Name = "Shorts", Quantity = 25, UnitPrice = 399m },
           new BjjInventoryItem { Name = "Finger Tejp", Quantity = 50, UnitPrice = 69m },
           new BjjInventoryItem { Name = "Gym Påse", Quantity = 2, UnitPrice = 149m },
           new BjjInventoryItem { Name = "Vattenflaska", Quantity = 30, UnitPrice = 89m },
           new BjjInventoryItem { Name = "Knäskydd", Quantity = 12, UnitPrice = 199m },
           new BjjInventoryItem { Name = "Handduk", Quantity = 10, UnitPrice = 99m }

       };
        // Topp 3 varor med hösta priset
        var top3ByPrice = bjjinventory.OrderByDescending(item => item.UnitPrice).Take(3);
        Console.WriteLine("Topp 3 varor med högsta priset:");
        foreach (var item in top3ByPrice)
        {
            Console.WriteLine($"{item.Name} - Pris: {item.UnitPrice} SEK");
        }

        // Alla varor under tre antal
        var underThree = bjjinventory.Where(item => item.Quantity < 3);
        Console.WriteLine("\nVaror med antal under tre:");
        foreach (var item in underThree)
        {
            Console.WriteLine($"{item.Name} - Antal: {item.Quantity}");
        }

        // Sammanställnings per bokstav: antal artiklar & totalsumma per bokstav
        var summaryByLetter = bjjinventory
            .GroupBy(item => item.Name[0])
            .Select(g => new
            {
                Letter = g.Key,
                TotalItems = g.Count(),
                TotalValue = g.Sum(item => item.TotalValue)
            });
        Console.WriteLine("\nSammanställning per bokstav:");
        foreach (var group in summaryByLetter)
        {
            Console.WriteLine($"Bokstav: {group.Letter} - Antal artiklar: {group.TotalItems} - Totalsumma: {group.TotalValue} SEK");
        }

        // Sök efter artikel och lista alla varors vars namn innehåller order case-insensitivt
        Console.WriteLine("\nSök efter artikel (ange sökterm):");
        string searchTerm = Console.ReadLine();
        var searchResults = bjjinventory

            .Where(item => item.Name.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0);
        Console.WriteLine($"\nSökresultat för '{searchTerm}':");
        foreach (var item in searchResults)
        {
            Console.WriteLine($"{item.Name} - Antal: {item.Quantity} - Pris: {item.UnitPrice} SEK");
        }

        // Prisintervall: visa min-,max- och medelpris (UnitPrice)
        var minPrice = bjjinventory.Min(item => item.UnitPrice);
        var maxPrice = bjjinventory.Max(item => item.UnitPrice);
        var avgPrice = bjjinventory.Average(item => item.UnitPrice);
        Console.WriteLine($"\nPrisintervall:");
        Console.WriteLine($"Min pris: {minPrice} SEK");
        Console.WriteLine($"Max pris: {maxPrice} SEK");
        Console.WriteLine($"Medelpris: {avgPrice} SEK");

        // (Bonus) Gruppintervaller: gruppera prisintervaller (0-99, 100-199, 200-299, etc.) och lista antal per intervall
        var priceIntervals = bjjinventory
            .GroupBy(item => (int)(item.UnitPrice / 100))
            .Select(g => new
            {
                Interval = $"{g.Key * 100}-{(g.Key + 1) * 100 - 1}",
                Count = g.Count()
            });
        Console.WriteLine("\nPrisintervaller:");
        foreach (var interval in priceIntervals)
        {
            Console.WriteLine($"Intervall: {interval.Interval} SEK - Antal artikel: {interval.Count}");
        }
    
    }
}

