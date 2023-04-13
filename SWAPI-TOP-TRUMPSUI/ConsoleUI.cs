using SWAPI_TOP_TRUMPSUI.Models;
using SWAPIels;
using System.Reflection;

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

        private static void StartGame(bool cheatMode)
        {
            bool gameContinue = true;
            bool userTurn = true;
            PlayerModel player = new();
            PlayerModel computer = new();
            player.PlayerWonCards = new();
            computer.PlayerWonCards = new();
            List<PersonModelLinq> shuffleAllCards = Shuffle();
            player.AllCards = shuffleAllCards;

            (computer.PlayerCards, player.PlayerCards) = CreatePlayerHands(shuffleAllCards);

            while (player.CardCount() != 0 && computer.CardCount() != 0)
            {
                while (gameContinue)
                {
                    userTurn = TakeTurn(player, computer, userTurn, cheatMode);
                    gameContinue = GameContinue(player, computer);
                }
                //while (!userTurn && gameContinue)
                //{
                //    userTurn = TakeTurn(playerCards, playerWonCards, computerCards, computerWonCards, userTurn, cheatMode);
                //    gameContinue = GameContinue(playerCards, computerCards);
                //}
                GameWin(player.CardCount(), computer.CardCount());
                break;
            }

            //GameWin(TotalCardForPlayer(playerCards, playerWonCards), TotalCardForPlayer(computerCards, computerWonCards));
        }

        //private static bool GameContinue(List<PersonModelLinq> playerCards, List<PersonModelLinq> computerCards)
        //{
        //    if (playerCards.Count == 0 || computerCards.Count == 0)
        //    {
        //        Console.WriteLine("Game is over if a player has 0 cards remaining.\n***** Calculating ******");
        //        return false;
        //    } else { return true; }
        //}

        private static bool GameContinue(PlayerModel player, PlayerModel computer)
        {
            if (player.CardCount() == 0 || computer.CardCount() == 0)
            {
                Console.WriteLine("Game is over if a player has 0 cards remaining.\n***** Calculating ******");
                return false;
            }
            else { return true; }
        }

        private static bool TakeTurn(PlayerModel player, PlayerModel computer, bool userTurn, bool cheatMode)
        {
            // check user turn, check cheat mode
            if (userTurn)
            {
                DisplayFirstCard(player, cheatMode);
                PrintAskForCardSelection();
                int userAttribute = AskUserOptionMainMenu(2, false);
                userTurn = CalculateRoundWinner(player, computer, userAttribute, userTurn);
                if (player.PlayerCards.Count == 0 || computer.PlayerCards.Count == 0)
                {
                    HandShuffle(player, computer);
                }
                return userTurn;
            }
            else
            {
                DisplayFirstCard(player, cheatMode);
                int userAttribute = AskComputerForCardSelection();
                userTurn = CalculateRoundWinner(player, computer, userAttribute, userTurn);

                if (player.CardCount() == 0 || computer.CardCount() == 0)
                {
                    HandShuffle(player, computer);
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

        private static void HandShuffle(PlayerModel player, PlayerModel computer)
        {
            player.Shuffle();
            computer.Shuffle();
            Console.WriteLine("Each players hand cards and won cards combined and shuffled");
            Console.ReadLine();
        }

        private static int AskComputerForCardSelection()
        {
            Random random = new();
            int randomNumber = random.Next(1, 2);
            Console.WriteLine($"Computer selects {randomNumber}");
            return randomNumber;
        }

        //private static void AddWonCardsToHandShuffle(PlayerModel player, PlayerModel computer)
        //{
            
            //List<PersonModelLinq> playerCardsToShuffle = new();
            //List<PersonModelLinq> computerCardsToShuffle = new();



            //foreach (PersonModelLinq playerCard in player.PlayerCards) { playerCardsToShuffle.Add(playerCard); }
            //foreach (PersonModelLinq playerCard in player.PlayerWonCards) { playerCardsToShuffle.Add(playerCard); }

            //foreach (PersonModelLinq computerCard in computer.PlayerCards) { computerCardsToShuffle.Add(computerCard); }
            //foreach (PersonModelLinq computerCard in computer.PlayerWonCards) { computerCardsToShuffle.Add(computerCard); }

            //List<PersonModelLinq> playerCardsShuffled = Shuffle(playerCardsToShuffle);
            //List<PersonModelLinq> computerCardsShuffled = Shuffle(computerCardsToShuffle);

            //player.PlayerCards.Clear();
            //computer.PlayerCards.Clear();
            //computer.PlayerWonCards.Clear();
            //player.PlayerWonCards.Clear();

            //foreach (PersonModelLinq card in playerCardsShuffled) { player.PlayerCards.Add(card); }
            //foreach (PersonModelLinq card in computerCardsShuffled) { computer.PlayerCards.Add(card); }
            //playerCardsToShuffle.Clear();
            //computerCardsShuffled.Clear();
            //playerCardsShuffled.Clear();
            //computerCardsToShuffle.Clear();
            
            //Console.WriteLine("Each players hand cards and won cards combined and shuffled");
            //Console.ReadLine();
        //}

        private static bool CalculateRoundWinner(PlayerModel player, PlayerModel computer, int userAttribute, bool userTurn)
        {
            if (userAttribute ==1)
            {
                string attribute = "Height";
                userTurn = AssignCardsAttribute(player, computer, attribute, userTurn);
            }
            if (userAttribute ==2)
            {
                string attribute = "Mass";
                userTurn = AssignCardsAttribute(player, computer, attribute, userTurn);
            }
            return userTurn;
        }

        private static bool AssignCardsAttribute(PlayerModel player, PlayerModel computer, string attribute, bool userTurn)
        {
            PropertyInfo propInfo = typeof(PersonModelLinq).GetProperty(attribute);

            if (Convert.ToDouble(propInfo.GetValue(player.PlayerCards[0], null)) > 
                Convert.ToDouble(propInfo.GetValue(computer.PlayerCards[0], null)))
            {
                player.PlayerWonCards.Add(computer.PlayerCards[0]);
                player.PlayerWonCards.Add(player.PlayerCards[0]);
                player.PlayerCards.RemoveAt(0);
                computer.PlayerCards.RemoveAt(0);
                Console.WriteLine("You won this round!");
                Console.ReadLine();
                return true;
            }
            else if (Convert.ToDouble(propInfo.GetValue(player.PlayerCards[0], null)) < 
                Convert.ToDouble(propInfo.GetValue(computer.PlayerCards[0], null)))
            {
                computer.PlayerWonCards.Add(computer.PlayerCards[0]);
                computer.PlayerWonCards.Add(player.PlayerCards[0]);
                player.PlayerCards.RemoveAt(0);
                computer.PlayerCards.RemoveAt(0);
                Console.WriteLine("You lost this round!");
                Console.ReadLine();
                return false;
            }
            else
            {
                computer.PlayerWonCards.Add(computer.PlayerCards[0]);
                player.PlayerWonCards.Add(player.PlayerCards[0]);
                player.PlayerCards.RemoveAt(0);
                computer.PlayerCards.RemoveAt(0);
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

        private static void DisplayFirstCard(PlayerModel player, bool cheatMode)
        {
            Console.Clear();
            if (cheatMode)
            {
                CardWinAll(player.PlayerCards, player.AllCards);
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
                Console.WriteLine($"1 Height: {itemList[0].Name}");
                Console.WriteLine($"2 Mass:   {itemList[0].Name}");
        }
        public static void CardWinAll(List<PersonModelLinq> itemList, List<PersonModelLinq> shuffleAllCards)
        {
                // based on index position of card call calculatewin() to display value + win%

                //double height = MethodsLogic.CalculateWin(itemList, itemList[index].Height, "Height");
                //double mass = MethodsLogic.CalculateWin(itemList, itemList[index].Mass, "Mass");

                Console.WriteLine($"  Name:  {itemList[0].Name}");
                Console.WriteLine($"1 Height:{itemList[0].Height}\tWin%: " +
                    $"{MethodsLogic.CalculateWin(shuffleAllCards, itemList[0].Height, "Height")}");
                Console.WriteLine($"2 Mass:  {itemList[0].Mass}\tWin%: " +
                    $"{MethodsLogic.CalculateWin(shuffleAllCards, itemList[0].Mass, "Mass")}");
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
        // Commenting out TotalCardForPlayer as can call the CardCount method from the PlayerModel

        //public static int TotalCardForPlayer(List<PersonModelLinq> handCards, List<PersonModelLinq> WonCards) 
        //{
        //    int output = handCards.Count + WonCards.Count;
        //    return output;
        //}
        public static (List<PersonModelLinq> computerCards, List<PersonModelLinq> playerCards) CreatePlayerHands(List<PersonModelLinq> shuffledCardList)
        {
            //splitting already shuffled list into computer and user

            List<PersonModelLinq> computerCards = new();
            List<PersonModelLinq> playerCards = new();

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

        public static List<PersonModelLinq> Shuffle()
        {
            List<PersonModelLinq> cardList = PeopleRepository.GetAll();
            var gameList = (from c in cardList select c).ToList();
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
