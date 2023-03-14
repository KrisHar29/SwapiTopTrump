using SWAPI_TOP_TRUMPSUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
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
                    StartGame(gameMode, cheatMode);
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
            bool gameContinue = true;
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
                while (gameContinue)
                {
                    userTurn = TakeTurn(playerCards, playerWonCards, computerCards, computerWonCards, userTurn, cheatMode);
                    gameContinue = GameContinue(playerCards, computerCards);
                }
                //while (!userTurn && gameContinue)
                //{
                //    userTurn = TakeTurn(playerCards, playerWonCards, computerCards, computerWonCards, userTurn, cheatMode);
                //    gameContinue = GameContinue(playerCards, computerCards);
                //}
                GameWin(TotalCardForPlayer(playerCards, playerWonCards), TotalCardForPlayer(computerCards, computerWonCards));
                break;
            }

            //GameWin(TotalCardForPlayer(playerCards, playerWonCards), TotalCardForPlayer(computerCards, computerWonCards));
        }

        private static bool GameContinue(List<PersonModelLinq> playerCards, List<PersonModelLinq> computerCards)
        {
            if (playerCards.Count == 0 || computerCards.Count == 0)
            {
                Console.WriteLine("Game is over a player has 0 cards reamining.\n***** Calculating ******");
                return false;
            } else { return true; }
        }

        private static bool TakeTurn(List<PersonModelLinq> playerCards, List<PersonModelLinq> playerWonCards, List<PersonModelLinq> computerCards, List<PersonModelLinq> computerWonCards, bool userTurn, bool cheatMode)
        {
            // check user turn, check cheat mode
            if (userTurn)
            {
                DisplayFirstCard(playerCards, cheatMode);
                PrintAskForCardSelection();
                int userAttribute = AskUserOptionMainMenu(2, false);
                userTurn = CalculateRoundWinner(playerCards, playerWonCards, computerCards, computerWonCards, userAttribute, userTurn);
                if (playerCards.Count == 0 || computerCards.Count == 0)
                {
                   AddWonCardsToHandShuffle(playerCards, playerWonCards, computerCards, computerWonCards);
                }
                return userTurn;
            }
            else
            {
                DisplayFirstCard(playerCards, cheatMode);
                int userAttribute = AskComputerForCardSelection();
                userTurn = CalculateRoundWinner(playerCards, playerWonCards, computerCards, computerWonCards, userAttribute, userTurn);

                if (playerCards.Count == 0 || computerCards.Count == 0)
                {
                    AddWonCardsToHandShuffle(playerCards, playerWonCards, computerCards, computerWonCards);
                }
                return userTurn;

            }

            // display 1st list item if cheatmode display win%

            // ask user for input

            // return input and calculate winner

            // decide round winner

            // move cards to winner

            // check user hand if 0 -> shuffle

            //return values?
        }

        private static int AskComputerForCardSelection()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 2);
            Console.WriteLine($"Computer selects {randomNumber}");
            return randomNumber;
        }

        private static void AddWonCardsToHandShuffle(List<PersonModelLinq> playerCards, List<PersonModelLinq> playerWonCards, List<PersonModelLinq> computerCards, List<PersonModelLinq> computerWonCards)
        {
            
            List<PersonModelLinq> playerCardsToShuffle = new();
            List<PersonModelLinq> computerCardsToShuffle = new();

            foreach (PersonModelLinq playerCard in playerCards) { playerCardsToShuffle.Add(playerCard); }
            foreach (PersonModelLinq playerCard in playerWonCards) { playerCardsToShuffle.Add(playerCard); }

            foreach (PersonModelLinq computerCard in computerCards) { computerCardsToShuffle.Add(computerCard); }
            foreach (PersonModelLinq computerCard in computerWonCards) { computerCardsToShuffle.Add(computerCard); }

            List<PersonModelLinq> playerCardsShuffled = Shuffle(playerCardsToShuffle);
            List<PersonModelLinq> computerCardsShuffled = Shuffle(computerCardsToShuffle);

            playerCards.Clear();
            computerCards.Clear();
            computerWonCards.Clear();
            playerWonCards.Clear();

            foreach (PersonModelLinq card in playerCardsShuffled) { playerCards.Add(card); }
            foreach (PersonModelLinq card in computerCardsShuffled) { computerCards.Add(card); }
            playerCardsToShuffle.Clear();
            computerCardsShuffled.Clear();
            playerCardsShuffled.Clear();
            computerCardsToShuffle.Clear();
            
            Console.WriteLine("Each players hand cards and won cards combined and shuffled");
            Console.ReadLine();
        }

        private static bool CalculateRoundWinner(List<PersonModelLinq> playerCards, List<PersonModelLinq> playerWonCards, List<PersonModelLinq> computerCards, List<PersonModelLinq> computerWonCards, int userAttribute, bool userTurn)
        {
            if (userAttribute ==1)
            {
                string attribute = "Height";
                userTurn = AssignCardsAttribute(playerCards, playerWonCards, computerCards, computerWonCards, attribute, userTurn);
            }
            if (userAttribute ==2)
            {
                string attribute = "Mass";
                userTurn = AssignCardsAttribute(playerCards, playerWonCards, computerCards, computerWonCards, attribute, userTurn);
            }
            return userTurn;
        }

        private static bool AssignCardsAttribute(List<PersonModelLinq> playerCards, List<PersonModelLinq> playerWonCards, List<PersonModelLinq> computerCards, List<PersonModelLinq> computerWonCards, string attribute, bool userTurn)
        {
            PropertyInfo propInfo = typeof(PersonModelLinq).GetProperty(attribute);

            if (Convert.ToDouble(propInfo.GetValue(playerCards[0], null)) > Convert.ToDouble(propInfo.GetValue(computerCards[0], null)))
            {
                playerWonCards.Add(computerCards[0]);
                playerWonCards.Add(playerCards[0]);
                playerCards.RemoveAt(0);
                computerCards.RemoveAt(0);
                Console.WriteLine("You won this round!");
                Console.ReadLine();
                return true;
            }
            else if (Convert.ToDouble(propInfo.GetValue(playerCards[0], null)) < Convert.ToDouble(propInfo.GetValue(computerCards[0], null)))
            {
                computerWonCards.Add(computerCards[0]);
                computerWonCards.Add(playerCards[0]);
                playerCards.RemoveAt(0);
                computerCards.RemoveAt(0);
                Console.WriteLine("You lost this round!");
                Console.ReadLine();
                return false;
            }
            else
            {
                computerWonCards.Add(computerCards[0]);
                playerWonCards.Add(playerCards[0]);
                playerCards.RemoveAt(0);
                computerCards.RemoveAt(0);
                if (userTurn)
                {
                    Console.WriteLine("Draw, your turn again");
                } else { Console.WriteLine("Draw computer goes again"); }
                Console.ReadLine();
                return userTurn;
            }
        }

        private static void PrintAskForCardSelection()
        {
            Console.Write("Enter your line selection: ");
        }

        private static void DisplayFirstCard(List<PersonModelLinq> playerCards, bool cheatMode)
        {
            Console.Clear();
            if (cheatMode)
            {
                CardWinAll(playerCards, 0);
            }
            else
            {
                CardValues(playerCards, 0);
            }
            
        }

        public static void CardValues(List<PersonModelLinq> itemList, int index)
        {
                //print all values
                Console.WriteLine($"  Name:   {itemList[index].Name}");
                Console.WriteLine($"1 Height: {itemList[index].Name}");
                Console.WriteLine($"2 Mass:   {itemList[index].Name}");
        }
        public static void CardWinAll(List<PersonModelLinq> itemList, int index)
        {
                // based on index position of card call calculatewin() to display value + win%

                //double height = MethodsLogic.CalculateWin(itemList, itemList[index].Height, "Height");
                //double mass = MethodsLogic.CalculateWin(itemList, itemList[index].Mass, "Mass");

                Console.WriteLine($"  Name:  {itemList[index].Name}");
                Console.WriteLine($"1 Height:{itemList[index].Height}\tWin%: {MethodsLogic.CalculateWin(itemList, itemList[index].Height, "Height")}");
                Console.WriteLine($"2 Mass:  {itemList[index].Mass}\tWin%: {MethodsLogic.CalculateWin(itemList, itemList[index].Mass, "Mass")}");
        }

        private static void GameWin(int? playerTotalCard, int? computerTotalCard)
        {
            if (playerTotalCard != 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("=== WINNER ===");
                Console.ResetColor();
                Console.ReadLine();
                Console.Clear();

            }
            if (computerTotalCard != 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=== LOSER ===");
                Console.ResetColor();
                Console.ReadLine();
                Console.Clear();
            }
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
