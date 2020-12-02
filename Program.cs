using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Player dave = new Player("Dave");
            dave.Draw(deck);
            dave.Discard(53);
            Console.WriteLine(dave);
        }
        class Card
        {
            public string StringVal;
            public string Suit;
            public int Val;
            public Card(string stringVal, string suit, int val)
            {
                this.StringVal = stringVal;
                this.Suit = suit;
                this.Val = val;
            }
        }
        class Deck
        {
            public List<Card> Cards;
            private void Initialize()
            {
                this.Cards = new List<Card>();
                int count = 4;
                while (count > 0)
                {
                    for (int i = 1; i <= 13; i++)
                    {
                        string stringVal, suit = "";
                        if (i == 1) { stringVal = "Ace"; }
                        else if (i == 11) { stringVal = "Jack"; }
                        else if (i == 12) { stringVal = "Queen"; }
                        else if (i == 13) { stringVal = "King"; }
                        else { stringVal = i.ToString(); }
                        if (count == 4) { suit = "Diamonds"; }
                        if (count == 3) { suit = "Spades"; }
                        if (count == 2) { suit = "Hearts"; }
                        if (count == 1) { suit = "Clubs"; }
                        this.Cards.Add(new Card(stringVal, suit, i));
                        count--;
                    }
                }
            }
            public Deck()
            {
                Initialize();
            }
            public void Reset()
            {
                Initialize();
            }
            public Card Deal()
            {
                Card dealt = this.Cards[this.Cards.Count - 1];
                this.Cards.Remove(dealt);
                return dealt;
            }
            public void Shuffl()
            {
                var random = new Random();
                this.Cards = this.Cards.OrderBy(item => random.Next()).ToList();
            }
        }
        class Player
        {
            public string Name;
            public Player(string name)
            {
                this.Name = name;
                this.Hand = new List<Card>();
            }
            public List<Card> Hand;
            public Card Discard(int index)
            {
                if (index > this.Hand.Count - 1)
                {
                    return null;
                }
                Card discarded = this.Hand[index];
                this.Hand.Remove(discarded);
                return discarded;
            }
            public Card Draw(Deck deck)
            {
                var random = new Random();
                Card drawn = deck.Cards[random.Next(0, deck.Cards.Count - 1)];
                deck.Cards.Remove(drawn);
                this.Hand.Add(drawn);
                return drawn;
            }

        }
    }
}
