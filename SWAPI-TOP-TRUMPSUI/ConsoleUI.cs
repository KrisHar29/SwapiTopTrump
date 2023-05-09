using SWAPI_TOP_TRUMPSUI.Models;



namespace SWAPI_TOP_TRUMPSUI
{
    public class ConsoleUI
    {
        public static void Welcome()
        {
            Console.WriteLine("Welcome to SWAPI.dev TOP TRUMPS");
            Console.WriteLine("created by KrisHar29");
        }
        public static async void StartUpUI()
        {
            bool cheatMode = false;
            Welcome();
            bool continueApp = true;
            int menuItem = 6;
            while (continueApp)
            {
                int userOption;
                userOption = AskUserOptionMainMenu(menuItem, true);

                switch (userOption)
                {
                    case 1:
                        StartGame(cheatMode);
                        break;
                    case 2:
                        cheatMode = ChooseCheatMode();
                        break;
                    case 3:
                        PrintRules();
                        break;
                    case 4:
                        continueApp = false;
                        break;
                    case 5:
                        continueApp = false;
                        break;
                    case 6:
                        await DownloadDataMenu();
                        break;
                    default:
                        break;

                }
            }
        }
        //menu for selecting options to download card data to play
        public static async Task DownloadDataMenu()
        {
            Console.Clear();
            Console.WriteLine("=== Download Data Menu ===");
            Console.WriteLine("Please Make your selection (number).");
            Console.WriteLine("1 Download Card Data from SWAPI.dev and save to file. (This deletes any existing data)");
            Console.WriteLine("2 Delete Card Data files from system.");
            Console.WriteLine("3 Return to Main Menu");
            Console.Write("Enter your selection: ");

            int userOption = AskUserOptionMainMenu(3, false);
            Console.Clear();
            switch (userOption)
            {
                case 1:
                    File.Delete("playercarddata.json");
                    MethodsLogic logic = new MethodsLogic();
                    Console.WriteLine("=== Requesting Data ===");
                    await logic.DownloadDataFromApi();
                    break;
                case 2:
                    try
                    {
                        Console.WriteLine("Deleting...");
                        File.Delete("playercarddata.json");
                        Console.WriteLine("Deleted.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                    catch (System.IO.FileNotFoundException)
                    {
                        Console.WriteLine("No File Found");
                        Console.ReadLine();
                    }
                    Console.WriteLine("Deleted");
                    break;
                case 3:

                    break;
                default:
                    break;
            }

        }

        public static void StartGame(bool cheatMode)
        {
            bool cardDataAvailable = true;

            //checking if there is downloaded data available
            // if not while loop will not run ad the new precodition
            //if statement will not start.
            if (!File.Exists("playercarddata.json"))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have not downloaded any data to\n" +
                                    "play yet! Please select option 6 of\n" +
                                    "the menu. Press any key to continue.");
                Console.ResetColor();
                Console.ReadLine();
                Console.Clear();

                cardDataAvailable = false;

            }
            
            // added the if statement to bypass logic if no card data available
            if(cardDataAvailable)
            {
                bool gameContinue = true;
                bool userTurn = true;
                PlayerModel player = new();
                PlayerModel computer = new();
                player.PlayerWonCards = new();
                computer.PlayerWonCards = new();
                List<PersonModel> shuffleAllCards = MethodsLogic.Shuffle();
                player.AllCards = shuffleAllCards;

                (computer.PlayerCards, player.PlayerCards) = MethodsLogic.CreatePlayerHands(shuffleAllCards);

                while (player.CardCount() != 0 && computer.CardCount() != 0)
                {
                    while (gameContinue)
                    {
                        userTurn = MethodsLogic.TakeTurn(player, computer, userTurn, cheatMode);
                        gameContinue = MethodsLogic.GameContinue(player, computer);
                    }

                    MethodsLogic.GameWin(player.CardCount(), computer.CardCount());
                    break;
                }
            }
        }

        //asks for line selection
        public static void PrintAskForCardSelection()
        {
            Console.Write("Enter your line selection: ");
        }
        //displays first card in console
        public static void DisplayFirstCard(PlayerModel player, bool cheatMode)
        {
            Console.Clear();
            if (cheatMode)
            {
                MethodsLogic.CardWinAll(player.PlayerCards, player.AllCards);
            }
            else
            {
                CardValues(player.PlayerCards);
            }

        }
        //prints card values for first card
        public static void CardValues(List<PersonModel> itemList)
        {
            //print all values
            Console.WriteLine($"  Name:   {itemList[0].Name}");
            Console.WriteLine($"1 Height: {itemList[0].Height}");
            Console.WriteLine($"2 Mass:   {itemList[0].Mass}");
            Console.WriteLine($"3 Films:  {itemList[0].Films?.Length ?? 0}");
            Console.WriteLine($"4 Vehicles:  {itemList[0].Vehicles?.Length ?? 0}");
            Console.WriteLine($"5 Age:  {itemList[0].BirthYear?.Length ?? 0}")
        }
        //cheat menu selection
        public static bool ChooseCheatMode()
        {
            int menuItems = 2;
            Console.Clear();
            Console.WriteLine("=== Cheat Mode ===");
            Console.WriteLine("Cheat Mode Allows you to see,\nyour odds of beating opponents hand");
            Console.WriteLine("1 - No Cheat Mode");
            Console.WriteLine("2 - Cheat Mode");
            Console.Write("Selection: ");
            int userOptionCheatMode = AskUserOptionMainMenu(menuItems, false);
            Console.Clear();
            if (userOptionCheatMode == 1) { return false; }
            //if (userOptionCheatMode == 2) { return true; }
            else { return true; }


        }
        //prints games rules
        public static void PrintRules()
        {
            Console.Clear();
            Console.WriteLine("==Rules==");
            Console.WriteLine("==End==");
            Console.WriteLine("Press enter to return to menu");
            Console.ReadLine();
            Console.Clear();
        }
        //try parses to int user option on menu items for relevent switch/if statements
        public static int AskUserOptionMainMenu(int menuOptions, bool mainMenu)
        {
            if (mainMenu == true) { MainMenu(); }
            try
            {
                int input = int.Parse(Console.ReadLine());
                if (input <= 0 || input > menuOptions)
                { throw new Exception(); }
                return input;
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("========================");
                Console.WriteLine("Invalid input try again!");
                Console.WriteLine("========================");
                Console.ResetColor();
                return 0;
            }

        }
        //prints main menu
        public static void MainMenu()
        {
            Console.WriteLine("=== Main Menu ===");
            Console.WriteLine("Please Make your selection (number).");
            Console.WriteLine("1 Play SWAPI");
            Console.WriteLine("2 Change Difficulty");
            Console.WriteLine("3 Rules");
            Console.WriteLine("4 Change Type (People/Planet/Vehicles) Not yet implemented(Will close APP).");
            Console.WriteLine("5 Close App");
            Console.WriteLine("6 Download Card Data");
            Console.Write("Enter your selection: ");
        }
    }
}