using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetCards.Cards
{
    /// <summary>
    /// f:{1,2,3,4,5}→{1,2,3,4,5} の写像を表すクラス。
    /// 始域は部分集合でもよい。
    /// </summary>
    class Map
    {
        // それぞれf(1),f(2),f(3),f(4),f(5)を表す
        private int _fOne;
        private int _fTwo;
        private int _fThree;
        private int _fFour;
        private int _fFive;

        //写像を文字列表示した変数
        private string _str;
        
        //カードの数字を代入する処理
        public string MapText
        {
            get { return _str; }
            set
            {
                if (value == null)
                {
                    this._fOne = 0;
                    this._fTwo = 0;
                    this._fThree = 0;
                    this._fFour = 0;
                    this._fFive = 0;
                    this._str = null;
                }
                else
                {
                    int intOut;
                    //文字列の長さが5のものしか受け入れない
                    if (value.Length != 5)
                    {
                        Console.Write("5文字でない文字列が入力されました");
                        throw new FormatException();
                    }
                    else if (!int.TryParse(value,out intOut))
                    {

                        Console.Write("数字でない文字列が入力されました");
                        throw new FormatException();
                    }

                    this._str = null;

                    for (int i = 1; i <= 5; i++)
                    {
                        //i文字目を配列に格納
                        fArray[i] = int.Parse(value.Substring(i - 1, 1));

                        if (fArray[i] >= 0 && fArray[i] <= 5) { this._str += fArray[i].ToString(); }
                        else { this._str += "0"; }
                    }
                }
            }
        }

        /// <summary>
        ///関数そのものを表す配列。
        /// </summary>
        public int[] fArray
        {
            get
            {
                int[] Array = new int[6];
                Array[0] = 0;
                Array[1] = _fOne;
                Array[2] = _fTwo;
                Array[3] = _fThree;
                Array[4] = _fFour;
                Array[5] = _fFive;
                return Array;
            }
        }

        //=====================================================
        //コンストラクタ（構築子）
        //=====================================================
        //写像作成(null)
        public Map()
        {
            this.MapText = null;
        }


        //カード作成
        public Map(string inputMapText)
        {
            this.MapText = inputMapText;
        }


        //=====================================================
        //メソッド
        //=====================================================

        //写像を文字列表記
        public override string ToString()
        {
            return this.MapText;
        }
    }
}
