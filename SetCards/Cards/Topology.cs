using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetCards.Cards
{
    /// <summary>
    /// 位相空間関連のメソッドを扱うクラス。
    /// </summary>
    public static class Topology
    {
        /// <summary>
        /// カードの集合が位相空間（の開集合系）を成すかどうかを判定する関数。
        /// 要素同士が重複しても良い。例えば赤の{1,4}と黒の{1,4}が同居しても良い。
        /// </summary>
        /// <param name="CardList">カードの集合</param>
        /// <returns>true:CardListは開集合系となる</returns>
        public static bool IsTopological(IEnumerable<Card> CardList)
        {
            //第一の条件、開集合が存在するかどうか
            bool ExistEmpty = false;
            //第二の条件、どの2つの要素どうしの積集合も開集合に含まれているかどうか
            bool IntersectionMembership = true;
            //第三の条件、どの2つの要素どうしの和集合も開集合に含まれているかどうか
            bool UnionMembership = true;

            //スートを抜いたカードリスト
            List<Card> NSuitCardList = new List<Card>();

            //NSuitCardListの作成
            foreach (Card c in CardList)
            {
                NSuitCardList.Add(new Card(0, c.Number));
            }

            //判定
            foreach (Card c1 in NSuitCardList)
            {

                //空集合のとき
                if (c1.Number == "")
                {
                    ExistEmpty = true;
                    continue;
                }
                else
                {
                    //c2カードを用意
                    foreach (Card c2 in NSuitCardList)
                    {

                        //空集合のとき
                        if (c2.Number == "")
                        {
                            ExistEmpty = true;
                            continue;
                        }
                        //積集合が含まれていないとき
                        else if(!NSuitCardList.Contains(c1.AND(c2)))
                        {
                            IntersectionMembership = false;
                            return false;
                        }
                        //和集合が含まれていないとき
                        else if (!NSuitCardList.Contains(c1.OR(c2)))
                        {
                            UnionMembership = false;
                            return false;
                        }

                    }

                }

            }


            return ExistEmpty && IntersectionMembership && UnionMembership;
        }
    }
}
