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

            var pc = new Dictionary<string, CityInfo> ();
            string pf,city;
            int num;
            Console.WriteLine ( "県庁所在地の登録" );

            //重複の有無
            while (true) {
                Console.Write ( "県名：" );
                pf = Console.ReadLine ();
                if (pf == "999") break;

                Console.Write ( "所在地：" );
                city = Console.ReadLine ();

                Console.Write ( "人口：" );
                num = int.Parse ( Console.ReadLine () );

                if (pc.ContainsKey ( pf )) {
                    Console.WriteLine ( "すでに県名入力済み" );
                    Console.Write ( "県名入力上書きするか y/n：" );
                    if (Console.ReadLine () != "y") {
                        continue;
                    }
                }
                pc[pf] = new CityInfo(city,num);
            }

            Console.WriteLine ( "　" );
            Console.WriteLine ("１：一覧表示, ２：県名指定");
            Console.Write ( ">" );
            var select = Console.ReadLine ();

            if (select == "1" ) {
                //一覧表示
                foreach (var item in  pc.OrderByDescending(n=> n.Value.Population)) {
                    Console.WriteLine ( "{0}、{1}、人口：{2:#,0}人です　", item.Key,item.Value.City , item.Value.Population );
                }
            }else {
                //県名指定処置
                Console.Write ( "県名を入力：" );
                var input = Console.ReadLine ();
                Console.WriteLine( "{0}、所在地{1}、人口：{2:#,0}人です　", input, pc[input].City, pc[input].Population );
            }
        }
    }
}
