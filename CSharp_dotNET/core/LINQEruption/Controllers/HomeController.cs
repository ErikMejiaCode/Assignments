using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LINQEruption.Models;

namespace LINQEruption.Controllers;

public class HomeController : Controller
{
    List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
    // Example Query - Prints all Stratovolcano eruptions
    // IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
    // PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
    // Execute Assignment Tasks here!

    // Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
    static void PrintEach(IEnumerable<Eruption> items, string msg = "")
    {
        Console.WriteLine("\n" + msg);
        foreach (Eruption item in items)
        {
            Console.WriteLine(item.ToString());
        }
    }
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        //Use LINQ to find the first eruption that is in Chile and print the result.
        Eruption? FirstChiliEruption = eruptions.FirstOrDefault(c => c.Location == "Chile");
        ViewBag.FirstChiliEruption = FirstChiliEruption;


        //Find the first eruption from the "Hawaiian Is" location and print it. If none is found, print "No Hawaiian Is Eruption found."
        Eruption? FirstHawaiianEruption = eruptions.FirstOrDefault(c => c.Location == "Hawaiian Is");

        if (FirstHawaiianEruption == null)
        {
            ViewBag.FirstHawaiianEruption = "No Greenland Eruption found.";
        } else 
        {
            ViewBag.FirstHawaiianEruption = FirstHawaiianEruption;
        }


        //Find the first eruption from the "Greenland" location and print it. If none is found, print "No Greenland Eruption found."
        Eruption? FirstGreenlandEruption = eruptions.FirstOrDefault(c => c.Location == "Greenland");

        if (FirstGreenlandEruption == null)
        {
            ViewBag.FirstGreenlandEruption = "No Greenland Eruption found.";
        } else 
        {
            ViewBag.FirstGreenlandEruption = FirstGreenlandEruption;
        }


        //Find the first eruption that is after the year 1900 AND in "New Zealand", then print it.
        Eruption? FirstNewZealandEruption = eruptions.Where(n => n.Year > 1900).FirstOrDefault(c => c.Location == "New Zealand");
        ViewBag.FirstNewZealandEruption = FirstNewZealandEruption;

        //Find all eruptions where the volcano's elevation is over 2000m and print them.
        List<Eruption> ElevationOver2000 = eruptions.Where(e => e.ElevationInMeters > 2000).ToList();
        ViewBag.ElevationOver2000 = ElevationOver2000;

        //Find all eruptions where the volcano's name starts with "L" and print them. Also print the number of eruptions found.
        List<Eruption> LNames = eruptions.Where(e => e.Volcano.StartsWith("L")).ToList();
        int Count = LNames.Count();
        ViewBag.LNames = LNames;
        ViewBag.Count = Count;


        //Find the highest elevation, and print only that integer (Hint: Look up how to use LINQ to find the max!)
        int Highest = eruptions.Max(h => h.ElevationInMeters);
        ViewBag.Highest = Highest;


        //Use the highest elevation variable to find a print the name of the Volcano with that elevation.
        Eruption? HighestVol = eruptions.FirstOrDefault(a => a.ElevationInMeters == Highest);
        ViewBag.HighestVol = HighestVol;

        //Print all Volcano names alphabetically.
        List<Eruption> OrderByAlpha = eruptions.OrderBy(e => e.Volcano).ToList();
        ViewBag.OrderByAlpha = OrderByAlpha;

        //Print the sum of all the elevations of the volcanoes combined.
        double Total = eruptions.Sum(e => e.ElevationInMeters);
        ViewBag.Total = Total;


        //Print whether any volcanoes erupted in the year 2000 (Hint: look up the Any query)
        List<Eruption> Volcano2000 = eruptions.Where(y => y.Year == 2000).ToList();
        ViewBag.Volcano2000 = Volcano2000;


        //Find all stratovolcanoes and print just the first three (Hint: look up Take)
        List<Eruption> StratoVolcanoes = eruptions.Where(y => y.Type == "Stratovolcano").Take(3).ToList();
        ViewBag.StratoVolcanoes = StratoVolcanoes;


        //Print all the eruptions that happened before the year 1000 CE alphabetically according to Volcano name.
        List<Eruption> BeforeYear1000 = eruptions.OrderBy(e => e.Volcano).Where(y => y.Year < 1000).ToList();
        ViewBag.BeforeYear1000 = BeforeYear1000;


        //Redo the last query, but this time use LINQ to only select the volcano's name so that only the names are printed.
        IEnumerable<string> NameOnly = eruptions.Where(e => e.Year < 1000).OrderBy(v => v.Volcano).Select(n => n.Volcano).ToArray();
        ViewBag.NameOnly = NameOnly;








        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
