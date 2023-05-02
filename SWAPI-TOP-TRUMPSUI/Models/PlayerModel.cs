using SWAPI_TOP_TRUMPSUI.Models;

namespace SWAPIels
{
    public class PlayerModel
    {
        public List<PersonModelLinq>? PlayerCards { get; set; }
        public List<PersonModelLinq>? PlayerWonCards { get; set; }
        public List<PersonModelLinq>? PlayerCardsToShuffle { get; set; }
        public List<PersonModelLinq>? AllCards { get; set; }
        public int CardCount()
        {
            if (PlayerCards.Count == 0 && PlayerWonCards.Count == 0) { return 0; }
            if (PlayerCards.Count == 0) { return PlayerWonCards.Count; }
            else { return PlayerCards.Count; }
        }
        public void Shuffle()
        {
            List<PersonModelLinq> allCards = new List<PersonModelLinq>();
            allCards.AddRange(PlayerCards);
            allCards.AddRange(PlayerWonCards);

            Random rng = new Random();
            int n = allCards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                PersonModelLinq card = allCards[k];
                allCards[k] = allCards[n];
                allCards[n] = card;
            }
            PlayerCards = allCards;
            PlayerWonCards.Clear();
        }
    }
}
