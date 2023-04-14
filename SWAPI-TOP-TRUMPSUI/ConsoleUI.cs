using SWAPI_TOP_TRUMPSUI.Models;
using SWAPIels;

namespace SWAPI_TOP_TRUMPSUI
{
    public class ConsoleUI
    {
        public static void Welcome() 
        {
            Console.WriteLine("Welcome to SWAPI.dev TOP TRUMPS");
            Console.WriteLine("created by KrisHar29");
        }
        public static void StartUpUI()
        {
            bool cheatMode = false;
            Welcome();
            bool continueApp = true;
            int menuItem = 5;
            while (continueApp)
            {
                int userOption;
                userOption = AskUserOptionMainMenu(menuItem, true);
                if (userOption == 1)
                {
                    StartGame(cheatMode);
                }
                if (userOption == 2)
                {
                    bool cheatModeChange = ChooseCheatMode();
                    cheatMode = cheatModeChange;
                }
                if (userOption == 3)
                {
                    PrintRules();
                }
                if (userOption == 4) { continueApp = false; }
                if (userOption == 5) { continueApp = false; }
            }
        }
        public static void StartGame(bool cheatMode)
        {
            bool gameContinue = true;
            bool userTurn = true;
            PlayerModel player = new();
            PlayerModel computer = new();
            player.PlayerWonCards = new();
            computer.PlayerWonCards = new();
            List<PersonModelLinq> shuffleAllCards = MethodsLogic.Shuffle();
            player.AllCards = shuffleAllCards;

            (computer.PlayerCards, player.PlayerCards) = MethodsLogic.CreatePlayerHands(shuffleAllCards);

            while (player.CardCount() != 0 && computer.CardCount() != 0)
            {
                while (gameContinue)
                {
                    userTurn = MethodsLogic.TakeTurn(player, computer, userTurn, cheatMode);
                    gameContinue = MethodsLogic.GameContinue(player, computer);
                }
                //while (!userTurn && gameContinue)
                //{
                //    userTurn = TakeTurn(playerCards, playerWonCards, computerCards, computerWonCards, userTurn, cheatMode);
                //    gameContinue = GameContinue(playerCards, computerCards);
                //}
                MethodsLogic.GameWin(player.CardCount(), computer.CardCount());
                break;
            }

            //GameWin(TotalCardForPlayer(playerCards, playerWonCards), TotalCardForPlayer(computerCards, computerWonCards));
        }
        public static void PrintAskForCardSelection()
        {
            Console.Write("Enter your line selection: ");
        }
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
        public static void CardValues(List<PersonModelLinq> itemList)
        {
                //print all values
                Console.WriteLine($"  Name:   {itemList[0].Name}");
                Console.WriteLine($"1 Height: {itemList[0].Height}");
                Console.WriteLine($"2 Mass:   {itemList[0].Mass}");
                Console.WriteLine($"3 Films:  {itemList[0].Films?.Length ?? 0}");
        }
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
            if (userOptionCheatMode == 2) { return true; }
            else { return false; }
            

        }
        public static void PrintRules()
        {
            Console.Clear();
            Console.WriteLine("==Rules==");
            Console.WriteLine("==End==");
            Console.WriteLine("Press enter to return to menu");
            Console.ReadLine();
            Console.Clear();
        }
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
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("========================");
                Console.WriteLine("Invalid input try again!");
                Console.WriteLine("========================");
                Console.ResetColor();
                return 0;
            }
            
        }
        public static void MainMenu()
        {
            Console.WriteLine("=== Main Menu ===");
            Console.WriteLine("Please Make your selection (number).");
            Console.WriteLine("1 Play SWAPI");
            Console.WriteLine("2 Change Difficulty");
            Console.WriteLine("3 Rules");
            Console.WriteLine("4 Change Type (People/Planet/Vehicles) Not yet implemented(Will close APP).");
            Console.WriteLine("5 Close App");
            Console.Write("Enter your selection: ");
        }
    }
}