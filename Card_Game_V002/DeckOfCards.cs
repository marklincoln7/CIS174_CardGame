using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardGame
{
    /*
        This is just my interpretation of how we could implement a deck of playing cards. Let me know what you guys think.

        I decided to use both a List and Queue for the following reasons:
            1. You can shuffle a List very quickly, but it takes awhile to remove a card from a List.
            2. You can remove or add cards from a Queue very quickly, but it takes awhile to shuffle a Queue.
        The class populates the deck (Queue) as it shuffles the list of cards.
    */
    public class DeckOfCards
    {
        private static int CARDS_IN_DECK = 52;
        private List<Card> masterList = new List<Card>(CARDS_IN_DECK);
        public Queue<Card> deck = new Queue<Card>(CARDS_IN_DECK);
        /*
            Populates the list of cards and calls the method to shuffle the deck.
        */
        public DeckOfCards()
        {
            int imgIdx = 0; //The index of the Card's corresponding image in the imageList.

            foreach (SuitType tempSuit in Enum.GetValues(typeof(SuitType)))
            {
                foreach (PipType tempPip in Enum.GetValues(typeof(PipType)))
                {
                    Card newCard = new Card(tempSuit, tempPip, imgIdx);
                    masterList.Add(newCard);
                    imgIdx++;
                }
            }

            ShuffleDeck();
        }
        /*
            Performs a Fisher-Yates shuffle on the list of cards and adds each card to the deck as it goes.
            Time complexity is probably O(n) or O(2n).
        */
        public void ShuffleDeck()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            deck.Clear();

            for (int i = masterList.Count - 1; i > 0; i--)
            {
                int j = rand.Next(0, i);
                Card tempCard = masterList[i];
                masterList[i] = masterList[j];
                masterList[j] = tempCard;
                deck.Enqueue(masterList[i]);
            }
            deck.Enqueue(masterList[0]);
        }
        /*
            Removes and returns the card at the top of the deck. Time complexity is O(1).
        */
        public Card DealCard()
        {
            if (deck.Count > 0)
                return deck.Dequeue();
            else
                throw new ArgumentNullException();
        }
        /*
            If the deck isn't full, puts a card at the bottom of the deck. Time complexity is O(1).
        */
        public void ReturnCard(Card usedCard)
        {
            if (deck.Count < CARDS_IN_DECK)
                deck.Enqueue(usedCard);
        }
        /*
            Returns true if the deck is empty, false if otherwise. Time complexity is O(1).
        */
        public bool isEmpty()
        {
            return (deck.Count == 0) ? true : false;
        }
        /*
            Returns a string implementation describing all of the cards in the master list.
        */
        public override String ToString()
        {
            String listOfCards = "";
            for (int i = 0; i < masterList.Count; i++)
                listOfCards += masterList[i].ToString() + " / ";
            return listOfCards + "End of list.";
        }
    }
}