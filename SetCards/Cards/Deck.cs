using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetCards.Cards
{
    public static class DeckFunc
    {


        //====================================
        //引数なし
        //====================================

        public static List<Card> MakeDeck()
        {
            List<Card> Deck = new List<Card>();
            string Number;
            for (int Suit = 1; Suit <= 2; Suit++)
            {
                if (Suit == 1) { Number = "B"; }
                else { Number = "R"; }

                for (int Exist1 = 0; Exist1 <= 1; Exist1++)
                {
                    if (Exist1 == 1) { Number += "1"; }

                    for (int Exist2 = 0; Exist2 <= 1; Exist2++)
                    {
                        if (Exist2 == 1) { Number += "2"; }

                        for (int Exist3 = 0; Exist3 <= 1; Exist3++)
                        {
                            if (Exist3 == 1) { Number += "3"; }

                            for (int Exist4 = 0; Exist4 <= 1; Exist4++)
                            {
                                if (Exist4 == 1) { Number += "4"; }

                                for (int Exist5 = 0; Exist5 <= 1; Exist5++)
                                {
                                    if (Exist5 == 1) { Number += "5"; }
                                    Deck.Add(new Card(Suit, Number));
                                }
                            }
                        }
                    }
                }
            }

            return Deck;
        }

    }
}
