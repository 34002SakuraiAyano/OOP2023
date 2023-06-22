using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    class Program {
        static void Main(string[] args) {
            /*
            var flowerDict = new Dictionary<string, int> () {
                ["sunflower"] = 400,
                ["pansy"] = 300,
                ["tulip"] = 350,
                ["rose"] = 500,
                ["dahlia"] = 450,
            };

            //morning glory(あさがお)【250円】を追加
            flowerDict["morning glory"] = 250;
            Console.WriteLine ( "ひまわりの価格は{0}円です。", flowerDict["sunflower"] );
            Console.WriteLine ( "チューリップの価格は{0}円です。", flowerDict["tulip"] );
            Console.WriteLine ( "あさがおの価格は{0}円です。", flowerDict["morning glory"] );
            */

            var pc = new Dictionary<string, string> ();
            string pf,city;

            Console.WriteLine ( "県庁所在地の登録" );

            //重複の有無
            while (true) {
                Console.Write ( "県名：" );
                pf = Console.ReadLine ();
                if (pf == "999") break;

                Console.Write ( "所在地：" );
                city = Console.ReadLine ();

                if (pc.ContainsKey ( pf )) {
                    Console.WriteLine ( "すでに県名入力済み" );
                    Console.Write ( "県名入力上書きするか y/n：" );
                    if (Console.ReadLine () != "y") {
                        continue;
                    }
                }
                pc[pf] = city;
            }
            //県名出力処置
             Console.Write ( "県名：" );
             var intput = Console.ReadLine();
             Console.WriteLine ( pc[intput] + "です" );
        }
    }
}
