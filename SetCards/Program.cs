using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SetCards.Cards;

using System.Runtime.Serialization.Json;
using System.IO;

namespace SetCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Card c = new Card(2, "245");
            Card c2 = new Card(1, "25");
            //Console.WriteLine(c);
            //Console.WriteLine(c.Cardinality());
            //Console.WriteLine(c.NOT());
            //Console.WriteLine(c2.Contained(c));
            //var Deck = DeckFunc.MakeDeck();
            //Deck.Sort(DeckFunc.CompareBy);
            //Console.WriteLine(Deck.DeckView());
            //Console.WriteLine(Topology.PowerSet(c).DeckView());
            // Keep the console window open in debug mode.
            var TList = Topology.MakeTopologyDeck(1);
            Console.WriteLine(TList.TopologiesView());

            //保存先のファイル名
            string fileName = @"C:\Users\dream\Dropbox\SetCards\xml\sample.xml";
            //XmlSerializerオブジェクトを作成
            //オブジェクトの型を指定する
            System.Xml.Serialization.XmlSerializer serializer =
                new System.Xml.Serialization.XmlSerializer(typeof(List<List<Card>>));
            //書き込むファイルを開く（UTF-8 BOM無し）
            System.IO.StreamWriter sw = new System.IO.StreamWriter(
                fileName, false, new System.Text.UTF8Encoding(false));
            //シリアル化し、XMLファイルに保存する
            serializer.Serialize(sw, TList);
            //ファイルを閉じる
            sw.Close();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
        

    }
}
