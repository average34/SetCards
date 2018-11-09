

namespace SetCards.Cards
{
    /// <summary>
    /// 1枚の集合トランプのカードそのものを表すクラス。
    /// 標準的な環境では、{1,2,3,4,5}の部分集合32種×2色、という構成になる。
    /// </summary>
    public class Card
    {

        //=====================================================
        //プロパティ
        //=====================================================
        //自動プロパティにしても良い
        private int _suit;
        /// <summary>
        /// カードのマーク(スート)を保持
        /// 0:スートなし扱い(N) 1:黒(B) 2:赤(R)
        /// </summary>
        public int Suit
        {
            get { return _suit; }
            set { this._suit = value; }
        }

        /// <summary>
        /// カードの数字
        /// null:エラー, "":空集合, "12345":全体集合
        /// </summary>
        private string _number;
        // カードの数字が含まれているかどうか
        public bool ExistOne { get; private set; }
        public bool ExistTwo { get; private set; }
        public bool ExistThree { get; private set; }
        public bool ExistFour { get; private set; }
        public bool ExistFive { get; private set; }

        //カードの数字を代入する処理
        public string Number
        {
            get { return _number; }
            set
            {
                this.ExistOne = value.Contains("1");
                this.ExistTwo = value.Contains("2");
                this.ExistThree = value.Contains("3");
                this.ExistFour = value.Contains("4");
                this.ExistFive = value.Contains("5");
                this._number = null;
                if (ExistOne) { this._number += "1"; }
                if (ExistTwo) { this._number += "2"; }
                if (ExistThree) { this._number += "3"; }
                if (ExistFour) { this._number += "4"; }
                if (ExistFive) { this._number += "5"; }

            }
        }

        /// <summary>
        ///カードの数字が含まれているかどうかの変数を配列に入れたもの
        /// </summary>
        public bool[] ExistArray
        {
            get
            {
                bool[] Array = new bool[5];
                Array[0] = ExistOne;
                Array[1] = ExistTwo;
                Array[2] = ExistThree;
                Array[3] = ExistFour;
                Array[4] = ExistFive;
                return Array;
            }
        }

        //=====================================================
        //初期化子
        //=====================================================
        //カード作成
        public Card(int inputSuit, string inputNumber)
        {
            this.Suit = inputSuit;
            this.Number = inputNumber;
        }

        //カード作成(スートに文字列を入れた場合)
        public Card(string inputStrSuit, string inputNumber)
        {
            if (inputStrSuit == "N") { this.Suit = 0; }
            else if (inputStrSuit == "B") { this.Suit = 1; }
            else if (inputStrSuit == "R") { this.Suit = 2; }
            else { this.Suit = 0; }
            this.Number = inputNumber;
        }


        //=====================================================
        //メソッド
        //=====================================================

        //カードを文字列表記
        public override string ToString()
        {
            string str;
            if (Suit == 0) { str = "N"; }
            else if (Suit == 1) { str = "B"; }
            else if (Suit == 2) { str = "R"; }
            else { return null; }

            str += this.Number;

            return str;
        }
    }
}
