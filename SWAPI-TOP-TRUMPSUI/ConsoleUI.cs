using SWAPI_TOP_TRUMPSUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            int gameMode = 1;
            while (continueApp)
            {
                int userOption = 0;
                userOption = AskUserOptionMainMenu(menuItem, true);
                if (userOption == 1)
                {
                    //StartGame(gameMode, cheatMode);
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

        private static void StartGame(int gameMode, bool cheatMode)
        {

            bool userTurn = true;
            if (gameMode == 1) { Console.WriteLine(); }

            List<PersonModelLinq> cardList = PeopleRepository.GetAll();
            var gameList = (from c in cardList select c).ToList();
            List<PersonModelLinq> playerWonCards = new List<PersonModelLinq>();
            List<PersonModelLinq> computerWonCards = new List<PersonModelLinq>();
            List<PersonModelLinq> shuffleAllCards = Shuffle(cardList);

            (List<PersonModelLinq> computerCards, List<PersonModelLinq> playerCards) = CreatePlayerHands(shuffleAllCards);

            while (TotalCardForPlayer(playerCards, playerWonCards) != 0 || TotalCardForPlayer(computerCards, computerWonCards) != 0)
            {
                while (userTurn)
                {
                    UserTakeTurn();
                }
                while (!userTurn)
                {
                    AITakeTurn();
                }
            }

            GameWin(playerTotalCard, computerTotalCard);

            if (playerTotalCard != 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("=== WINNER ===");
                Console.ResetColor();
                Console.ReadLine();

            }
            if (computerTotalCard != 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=== LOSER ===");
                Console.ResetColor();
                Console.ReadLine();
            }


            // clear list before exiting to menu.

        }
        public static int TotalCardForPlayer(List<PersonModelLinq> handCards, List<PersonModelLinq> WonCards) 
        {
            int output = handCards.Count + WonCards.Count;
            return output;
        }
        public static (List<PersonModelLinq> computerCards, List<PersonModelLinq> playerCards) CreatePlayerHands(List<PersonModelLinq> shuffledCardList)
        {
            //splitting already shuffled list into computer and user

            List<PersonModelLinq> computerCards = new List<PersonModelLinq>();
            List<PersonModelLinq> playerCards = new List<PersonModelLinq>();

            // Splitting the shuffled card list into computer and player hands
            bool isComputerTurn = true; // start with computer
            foreach (PersonModelLinq card in shuffledCardList)
            {
                if (isComputerTurn)
                {
                    computerCards.Add(card);
                    isComputerTurn = false;
                }
                else
                {
                    playerCards.Add(card);
                    isComputerTurn = true;
                }
            }
            return (computerCards, playerCards);
        }

        public static List<PersonModelLinq> Shuffle(List<PersonModelLinq> cardList)
        {
            List<PersonModelLinq> shuffledCards = cardList.OrderBy(x => Guid.NewGuid()).ToList();
            return shuffledCards;
        }

        private static bool ChooseCheatMode()
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

        private static void PrintRules()
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
