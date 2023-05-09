﻿namespace SWAPI_TOP_TRUMPSUI.Models
{
    public class PlayerModel
    {
        public List<PersonModel>? PlayerCards { get; set; }
        public List<PersonModel>? PlayerWonCards { get; set; }
        public List<PersonModel>? PlayerCardsToShuffle { get; set; }
        public List<PersonModel>? AllCards { get; set; }
        public int CardCount()
        {
            return PlayerCards.Count + PlayerWonCards.Count;
            //if (PlayerCards.Count == 0 && PlayerWonCards.Count == 0) { return 0; }
            //if (PlayerCards.Count == 0) { return PlayerWonCards.Count; }
            //else { return PlayerCards.Count; }
        }
        public void Shuffle()
        {
            List<PersonModel> allCards = new ();
            
            // add won cards and any left in players hand to allCards
            allCards.AddRange(PlayerCards);
            allCards.AddRange(PlayerWonCards);
            

            // shuffling the list order of allCards by swapping them
            // between [k] and [n]
            Random rng = new Random();
            int n = allCards.Count;
            while (n >= 1)
            {
                n--;
                int k = rng.Next(n + 1);
                PersonModel card = allCards[k];
                allCards[k] = allCards[n];
                allCards[n] = card;
            }
            PlayerCards = allCards;
            PlayerWonCards.Clear();
        }
    }
}
