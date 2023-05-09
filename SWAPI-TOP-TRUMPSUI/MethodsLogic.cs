using SWAPI_TOP_TRUMPSUI.Models;
using System.Reflection;
using System.Text.Json;

namespace SWAPI_TOP_TRUMPSUI
{
    public class MethodsLogic
    {
        public async Task DownloadDataFromApi()
        {
            RequestSWAPIToFile request = new RequestSWAPIToFile();
            await request.RequestAllPeople();
        }
        // CalculateWinheight not used but keeping as ref
        //public static double CalculateWinHeight(List<PersonModel> itemList, string itemValue)
        //{
        //    // get all heights from list sorted desc
        //    var createList = (from item in itemList select item.Height).OrderByDescending(h => h).ToList();
        //    // calculate win% based on number of items v itemValue
        //    // list.length - [i]/list.length = %
        //    // find [i] from itemValue
        //    int index = createList.IndexOf(itemValue);
        //    double listCount = createList.Count;
        //    Console.WriteLine(listCount);
        //    double output = (listCount - index) / listCount * 100;
        //    return output;
        //}
        // when passing through a string 'int'
        public static double CalculateWin(List<PersonModel> allCards, string itemValue, string propertyValue)
        {
            // get all heights from list sorted desc

            // ammending out below to make the win%  based on opponents hand only and not win% on what was the players hand only

            var createList = (from card in allCards
                              select double.Parse(card.GetType().GetProperty(propertyValue).GetValue(card).ToString()))
                              .OrderByDescending(h => h)
                              .ToList();

            double itemValueDouble = Convert.ToDouble(itemValue);
            int index = createList.IndexOf(itemValueDouble);
            double listCount = createList.Count;
            // If card is in last position display 0%
            if (listCount -1 == index)
            {
                double output = 0;
                return output;
            }
            else
            {
                double output = (listCount - index) / (listCount) * 100;
                return output;
            }
        }
        // when passing through a 'int' for array size
        public static double CalculateWin(List<PersonModel> allCards, int itemValue, string propertyValue)
        {
            // win based on array size of film / vehicles

            // win% based on unique?? NYI


            //creating distinct list of movies
            var createList = (from card in allCards
                              select card.GetType().GetProperty(propertyValue).GetValue(card) as Array into propertyArray
                              select propertyArray?.Length ?? 0)
                              .Distinct()
                              .OrderByDescending(h => h)
                              .ToList();

            //double itemValueDouble = Convert.ToDouble(itemValue);
            int index = createList.IndexOf(itemValue);
            int listCount = createList.Count;
            // If card is in last position display 0%
            if (listCount - 1 == index)
            {
                double output = 0;
                return output;
            }
            else
            {
                double output = (listCount - index) / (listCount) * 100;
                return output;
            }
        }
        public static bool GameContinue(PlayerModel player, PlayerModel computer)
        {
            if (player.CardCount() == 0 || computer.CardCount() == 0)
            {
                Console.WriteLine("Game is over if a player has 0 cards remaining.\n***** Calculating ******");
                return false;
            }
            else { return true; }
        }
        public static bool TakeTurn(PlayerModel player, PlayerModel computer, bool userTurn, bool cheatMode)
        {
            // check user turn, check cheat mode
            if (userTurn)
            {
                ConsoleUI.DisplayFirstCard(player, cheatMode);
                ConsoleUI.PrintAskForCardSelection();
                int userAttribute = ConsoleUI.AskUserOptionMainMenu(4, false);
                userTurn = CalculateRoundWinner(player, computer, userAttribute, userTurn);
                if (player.PlayerCards.Count == 0 || computer.PlayerCards.Count == 0)
                {
                    HandShuffle(player, computer);
                }
                return userTurn;
            }
            else
            {
                ConsoleUI.DisplayFirstCard(player, cheatMode);
                int userAttribute = AskComputerForCardSelection();
                userTurn = CalculateRoundWinner(player, computer, userAttribute, userTurn);

                if (player.PlayerCards.Count == 0 || computer.PlayerCards.Count == 0)
                {
                    HandShuffle(player, computer);
                }
                return userTurn;

            }
        }
        public static void HandShuffle(PlayerModel player, PlayerModel computer)
        {
            player.Shuffle();
            computer.Shuffle();
            Console.WriteLine("Each players hand cards and won cards combined and shuffled");
            Console.ReadLine();
        }
        public static int AskComputerForCardSelection()
        {
            Random random = new();
            int randomNumber = random.Next(1, 4);
            Console.WriteLine($"Computer selects {randomNumber}");
            return randomNumber;
        }
        public static bool CalculateRoundWinner(PlayerModel player, PlayerModel computer, int userAttribute, bool userTurn)
        {
            //if (userAttribute == 1)
            //{
            //    string attribute = "Height";
            //    userTurn = AssignCardsAttribute(player, computer, attribute, userTurn);
            //}
            //if (userAttribute == 2)
            //{
            //    string attribute = "Mass";
            //    userTurn = AssignCardsAttribute(player, computer, attribute, userTurn);
            //}
            //return userTurn;

            // update to switch statement

            string attribute = "";
            switch (userAttribute)
            {
                case 1:
                    attribute = "Height";
                    break;
                case 2:
                    attribute = "Mass";
                    break;
                case 3:
                    attribute = "Films";
                    break;
                case 4:
                    attribute = "Vehicles";
                    break;
                case 5:
                    attribute = "BirthYear";
                    break;
                default:
                    // Handle invalid user input
                    break;
            }
            userTurn = AssignCardsAttribute(player, computer, attribute, userTurn);
            return userTurn;
        }

        private static bool RoundOutcome(PlayerModel player, PlayerModel computer, bool outcome, bool draw)
        {
            if (draw)
            {
                computer.PlayerWonCards.Add(computer.PlayerCards[0]);
                player.PlayerWonCards.Add(player.PlayerCards[0]);
                player.PlayerCards.RemoveAt(0);
                computer.PlayerCards.RemoveAt(0);
                return draw;
            }
            if (outcome)
            {
                player.PlayerWonCards.Add(computer.PlayerCards[0]);
                player.PlayerWonCards.Add(player.PlayerCards[0]);
                player.PlayerCards.RemoveAt(0);
                computer.PlayerCards.RemoveAt(0);
                Console.WriteLine("You won this round!");
                Console.ReadLine();
                return true;
            }

            computer.PlayerWonCards.Add(computer.PlayerCards[0]);
            computer.PlayerWonCards.Add(player.PlayerCards[0]);
            player.PlayerCards.RemoveAt(0);
            computer.PlayerCards.RemoveAt(0);
            Console.WriteLine("You lost this round!");
            Console.ReadLine();
            return false;
        }
        public static bool AssignCardsAttribute(PlayerModel player, PlayerModel computer, string attribute, bool userTurn)
        {
            PropertyInfo propInfo = typeof(PersonModel).GetProperty(attribute);
            if (attribute == "Films" || attribute == "Vehicles")
            {
                object playerValue = propInfo.GetValue(player.PlayerCards[0]);
                object computerValue = propInfo.GetValue(computer.PlayerCards[0]);

                int playerLength = (playerValue as Array)?.Length ?? 0;
                int computerLength = (computerValue as Array)?.Length ?? 0;

                if (playerLength > computerLength)
                {
                    return RoundOutcome(player, computer, true, false);
                }
                else if (playerLength < computerLength)
                {
                    return RoundOutcome(player, computer, false, false);
                }
                else
                {
                    RoundOutcome(player, computer, false, true);
                    if (userTurn)
                    {
                        Console.WriteLine("Draw, your turn again");
                    }
                    else { Console.WriteLine("Draw computer goes again"); }
                    Console.ReadLine();
                    return userTurn;
                }
            }
            else
            {
                if (Convert.ToDouble(propInfo.GetValue(player.PlayerCards[0])) >
                Convert.ToDouble(propInfo.GetValue(computer.PlayerCards[0])))
                {
                    return RoundOutcome(player, computer, true, false);
                }
                else if (Convert.ToDouble(propInfo.GetValue(player.PlayerCards[0])) <
                    Convert.ToDouble(propInfo.GetValue(computer.PlayerCards[0])))
                {
                    return RoundOutcome(player, computer, false, false);
                }
                else
                {
                    RoundOutcome(player, computer, false, true);
                    if (userTurn)
                    {
                        Console.WriteLine("Draw, your turn again");
                    }
                    else { Console.WriteLine("Draw computer goes again"); }
                    Console.ReadLine();
                    return userTurn;
                }
            }            
        }
        public static void CardWinAll(List<PersonModel> itemList, List<PersonModel> shuffleAllCards)
        {
            // based on index position of card call calculatewin() to display value + win%

            //double height = MethodsLogic.CalculateWin(itemList, itemList[index].Height, "Height");
            //double mass = MethodsLogic.CalculateWin(itemList, itemList[index].Mass, "Mass");

            Console.WriteLine($"  Name:  {itemList[0].Name}");
            Console.WriteLine($"1 Height:{itemList[0].Height}\tWin%: " +
                $"{MethodsLogic.CalculateWin(shuffleAllCards, itemList[0].Height, "Height")}");
            Console.WriteLine($"2 Mass:  {itemList[0].Mass}\tWin%: " +
                $"{MethodsLogic.CalculateWin(shuffleAllCards, itemList[0].Mass, "Mass")}");
            Console.WriteLine($"3 Films:  {itemList[0].Films?.Length ?? 0}\t " +
                $"Win%: " + $"{MethodsLogic.CalculateWin(shuffleAllCards, itemList[0].Films?.Length ?? 0, "Films")}");

            Console.WriteLine($"4 Vehicles:  {itemList[0].Vehicles?.Length ?? 0}\t " +
                $"Win%: " + $"{MethodsLogic.CalculateWin(shuffleAllCards, itemList[0].Vehicles?.Length ?? 0, "Vehicles")}");
        }
        public static void GameWin(int? playerTotalCard, int? computerTotalCard)
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
        public static (List<PersonModel> computerCards, List<PersonModel> playerCards) CreatePlayerHands(List<PersonModel> shuffledCardList)
        {
            //splitting already shuffled list into computer and user

            List<PersonModel> computerCards = new();
            List<PersonModel> playerCards = new();

            // Splitting the shuffled card list into computer and player hands
            bool isComputerTurn = true; // start with computer
            foreach (PersonModel card in shuffledCardList)
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

        //does the initial shuffling method now taking data from the playercarddata.json
        public static List<PersonModel> Shuffle()
        {
            List<PersonModel> cardList = new();

            // using existing data set that i just verified downloaded from API
            var jsonString = File.ReadAllText("playercarddata.json");
            var people = JsonSerializer.Deserialize<PersonModel[]>(jsonString);
            
            //clean data in memory so that height and mass are parseable
            foreach (PersonModel person in people)
            {
                if (person.Height == "unknown")
                {
                    person.Height = "0";
                }
                if (person.Mass == "unknown")
                {
                    person.Mass = "0";
                }
                cardList.Add(person);
            }
            

            var gameList = (from c in cardList select c).ToList();
            List<PersonModel> shuffledCards = cardList.OrderBy(x => Guid.NewGuid()).ToList();
            return shuffledCards;
        }
    }
}