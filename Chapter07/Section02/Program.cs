using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section02 {
    class Program {
        static void Main(string[] args) {
            var dict = new Dictionary<string, List<CityInfo>> ();
            string pref, city;
            int population;
            Console.WriteLine ( "市町村名の登録" );

            //重複の有無
            while (true) {
                Console.Write ( "県名：" );
                pref = Console.ReadLine ();
                if (pref == "999") break;

                Console.Write ( "市町村名：" );
                city = Console.ReadLine ();
                Console.Write ( "人口：" );
                population = int.Parse ( Console.ReadLine () );

                //市町村情報インスタンス生成
                var cityInfo = new CityInfo {
                    City = city,
                    Population = population ,
                };

                if (dict.ContainsKey ( pref )) {
                    //List<CityInfo>が存在するためADDで市町村データを追加：登録済み
                    dict[pref].Add ( cityInfo );
                }else {
                    dict[pref] = new List<CityInfo> { cityInfo };  //未登録（リスト作成）
                }
            }

            Console.WriteLine ( "　" );
            Console.WriteLine ( "１：一覧表示, ２：県名指定" );
            Console.Write ( ">" );
            var select = Console.ReadLine ();

            if (select == "1") {
                //一覧表示
                foreach (var item in dict) {
                    foreach (var term in item.Value) {
                        Console.WriteLine ( "{0}、{1}、人口：{2:#,0}人です　", item.Key, term.City, term.Population );
                    }
                }
            }else {
                //市町村定処置
                Console.Write ( "県名を入力：" );
                var input = Console.ReadLine ();
                foreach (var words in dict[input]) {
                    Console.WriteLine ( "市町村：{0}、人口：{1:#,0}人です　", words.City, words.Population );
                }
            }
        }
    }
}



