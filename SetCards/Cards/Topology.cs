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
                if (c1.Number == "" || c1.Number == null)
                {
                    ExistEmpty = true;
                    continue;
                }
                else
                {
                    //c2カードを用意
                    foreach (Card c2 in NSuitCardList)
                    {
                        Card AND = c1.AND(c2);
                        Card OR = c1.OR(c2);
                        //空集合のとき
                        if (c2.Number == "" || c2.Number == null)
                        {
                            ExistEmpty = true;
                            continue;
                        }
                        //積集合が含まれていないとき
                        else if(NSuitCardList.Any(x => x.ToString() == AND.ToString()) == false)
                        {
                            IntersectionMembership = false;
                            return false;
                        }
                        //和集合が含まれていないとき
                        else if (NSuitCardList.Any(x => x.ToString() == OR.ToString()) == false)
                        {
                            UnionMembership = false;
                            return false;
                        }

                    }

                }

            }


            return ExistEmpty && IntersectionMembership && UnionMembership;
        }


        /// <summary>
        /// カードの集合がT0空間（コルモゴロフ空間）を成すかどうかを判定する関数。
        /// </summary>
        /// <param name="CardList">カードの集合</param>
        /// <returns>true:CardListはT0空間となる</returns>
        public static bool IsT0(IEnumerable<Card> CardList)
        {
            //まず位相空間か判定
            if (!IsTopological(CardList)){ return false; }

            bool IsT0 = true;
            //x, y が T0-空間 X の相異なる二点ならば、x または y の一方を含む開集合で、他方を含まないようなものが存在する。
            for (int x = 1; x <= 5; x++)
            {

                //そもそもないものは除外
                if (!CardList.Any(c => c.ExistArray[x - 1])) { continue; }

                for (int y = 1; y <= 5; y++)
                {
                    //x,yは異なるので除外
                    if (x == y) { continue; }

                    //そもそもないものは除外
                    if (!CardList.Any(c => c.ExistArray[y - 1])) { continue; }

                    if (!CardList.Any(c => 
                    (c.ExistArray[x - 1] == true && c.ExistArray[y - 1] == false) || 
                    (c.ExistArray[x - 1] == false && c.ExistArray[y - 1] == true))
                    ) { return false; }

                }
            }

            return IsT0;
        }

        /// <summary>
        /// カードの集合が離散空間を成すかどうかを判定する関数。
        /// 全体集合はU={1,2,3,4,5}ではなく、その集合における最大の開集合。
        /// </summary>
        /// <param name="CardList">カードの集合</param>
        /// <returns>true:CardListは離散空間となる</returns>
        public static bool IsDiscrete(IEnumerable<Card> CardList)
        {
            //まず位相空間か判定
            if (!IsTopological(CardList)) { return false; }
            
            //x, y が T1-空間 X の相異なる二点ならば、x を含み y を含まない開集合と、x を含まず y を含む開集合が同時に存在する。
            //有限位相空間において、T1空間は離散空間である。
            for (int x = 1; x <= 5; x++)
            {
                //そもそもないものは除外
                if (!CardList.Any(c => c.ExistArray[x - 1])) { continue; }
                for (int y = 1; y <= 5; y++)
                {

                    //そもそもないものは除外
                    if (!CardList.Any(c => c.ExistArray[y - 1])) { continue; }

                    //x,yは異なるので除外
                    if (x == y) { continue; }

                    bool x1y0 = CardList.Any(c => c.ExistArray[x - 1] == true && c.ExistArray[y - 1] == false);
                    bool x0y1 = CardList.Any(c => c.ExistArray[x - 1] == false && c.ExistArray[y - 1] == true);
                    if(!x1y0 || !x0y1) { return false; }

                }
            }
            return true;

        }



            /// <summary>
            /// カードから冪集合(離散位相)を生成する関数。スートなし。
            /// </summary>
            /// <param name="c">台集合</param>
            /// <returns>冪集合(離散位相)</returns>
            public static List<Card> PowerSet(Card c)
        {
            List<Card> PowerSet = new List<Card>();
            int Suit = 0;
            string Number;

            for (int Exist1 = 0; Exist1 <= 1; Exist1++)
            {

                for (int Exist2 = 0; Exist2 <= 1; Exist2++)
                {

                    for (int Exist3 = 0; Exist3 <= 1; Exist3++)
                    {

                        for (int Exist4 = 0; Exist4 <= 1; Exist4++)
                        {

                            for (int Exist5 = 0; Exist5 <= 1; Exist5++)
                            {
                                if (Suit == 1) { Number = "B"; }
                                else if (Suit == 2) { Number = "R"; }
                                else { Number = "N"; }

                                if (Exist1 == 1 & c.ExistArray[0]) { Number += "1"; }
                                if (Exist2 == 1 & c.ExistArray[1]) { Number += "2"; }
                                if (Exist3 == 1 & c.ExistArray[2]) { Number += "3"; }
                                if (Exist4 == 1 & c.ExistArray[3]) { Number += "4"; }
                                if (Exist5 == 1 & c.ExistArray[4]) { Number += "5"; }

                                //要素になければ追加
                                if (!PowerSet.Any(x => x.ToString() == Number))
                                {
                                    PowerSet.Add(new Card(Suit, Number));
                                }
                                Number = "";
                            }
                        }
                    }
                }
            }
            PowerSet.Sort(DeckFunc.CompareBy);
            
            return PowerSet;
        }



        /// <summary>
        /// n=5の5点集合からなる有限位相空間9053種を生成する関数。
        /// 生成にはとても時間がかかる（10時間程度）ため、このオブジェクトを別途jsonやxmlに保存したほうがよい。
        /// </summary>
        /// <param name="Suit">スート。0:色なし 1:黒 2:赤</param>
        /// <returns></returns>
        public static List<List<Card>> MakeTopologyDeck(int Suit)
        {

            //全体集合の冪集合
            List<Card> P_U;

            //有限位相空間9053種を格納するリスト（入れ子）
            List<List<Card>> TopologyDeck = new List<List<Card>>();
            //上記リストに入れる位相空間
            List<Card> TopologySpace;

            //2^(2^5 - 1) / 2 = 2^30 = 1073741824 パターンを試すハメになる。かなり時間がかかる。
            //要素を特定するだけならもっと良いアルゴリズムがあるはず。改善求む

            //全体集合の冪集合を作成
            P_U = DeckFunc.MakeHalfDeck(Suit);
            P_U.Sort(DeckFunc.CompareByCardinality);

            
            uint b = 4;
            bool DisNext = false;

            for (uint bit31 = 0; bit31 < Math.Pow(2,31) ; bit31++)
            {
                //離散空間の次の位相空間のナンバーを記録する
                //この位相空間は密着位相である
                if (DisNext)
                {
                    b = bit31;
                    DisNext = false;
                }

                    //位相空間を初期化
                    TopologySpace = new List<Card>();

                //空集合を入れる。これは必ず入れる
                TopologySpace.Add(new Card(Suit, "0"));

                //ビット演算によって要素の有無を判定。
                for (int j = 1; j < 32; j++)
                {
                    if ((bit31 & (uint)Math.Pow(2,j-1)) == (uint)Math.Pow(2, j - 1))
                    {
                        TopologySpace.Add(P_U[j]);
                    }
                }

                //位相空間かどうか判定を行う。位相空間でなければ何もしない
                if (Topology.IsTopological(TopologySpace))
                {
                    TopologyDeck.Add(TopologySpace);

                    bool T0 = IsT0(TopologySpace);
                    bool Dis = IsDiscrete(TopologySpace);


                    System.IO.StreamWriter sw = new System.IO.StreamWriter(
                      "test.txt", // 出力先ファイル名
                      true, // 追加書き込み
                      System.Text.Encoding.GetEncoding("Shift_JIS"));

                    //Console.SetOut(sw); // 出力先（Outプロパティ）を設定

                    Console.WriteLine(bit31.ToString("x4") + ":" +
                        TopologyDeck.Count + ":" + Dis + ":" +
                        TopologySpace.DeckView());

                    //離散空間の場合、しばらくの間は位相空間となる数字が出てこないので、
                    //bit31の値を倍にする
                    if (Dis && bit31 >= 4)
                    {
                        DisNext = true;
                        bit31 = b * 2 - 1;
                    }


                    sw.Dispose(); // ファイルを閉じてオブジェクトを破棄

                }
                TopologySpace = null;
            }
            return TopologyDeck;
        }




    }
}
