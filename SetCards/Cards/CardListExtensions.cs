using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetCards.Cards
{
    public static class CardListExtensions
    {
        //カードを文字列表記
        public static string DeckView(this List<Card> Deck)
        {
            string str = "";
            foreach (Card c in Deck)
            {
                str += c.ToString() + ",";
            }

            return str;
        }

    }
}
