using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SetCards.Cards;

namespace SetCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Card c = new Card(2, "245");
            Card c2 = new Card(1, "25");
            Console.WriteLine(c);
            Console.WriteLine(c.Cardinality());
            Console.WriteLine(c.NOT());
            Console.WriteLine(c2.Contained(c));
            var Deck = DeckFunc.MakeDeck();
            Deck.Sort(DeckFunc.CompareByContain);
            Console.WriteLine(Deck.DeckView());
            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
