using SWAPI_TOP_TRUMPSUI;
using SWAPIels;


// Trying to make a Top Trumps app using information from SWAPI.dev
// WORK IN PROGRESS

ConsoleUI.StartUpUI();
Console.ReadLine();

try
{
    ConsoleUI.StartUpUI();
    Console.ReadLine();
}
catch (Exception ex)
{
    Console.WriteLine($"  is out of range.");
    Console.WriteLine( ex.Message );
}
