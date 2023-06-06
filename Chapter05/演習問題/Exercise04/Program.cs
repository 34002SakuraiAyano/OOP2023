#define Nonarray
#define StringArray
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise04 {
    class Program {
        static void Main(string[] args) {
            Stopwatch sw = new Stopwatch ();
            sw.Start ();

#if NonArray
            var line = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";
            foreach (var words in line.Split ( ';' )) {
                var words2 = words.Split ( '=' );
                Console.WriteLine ( "{0}：{1}", ToJapanese ( words2[0] ), words2[1] );
            }

#elif StringArray
            string[] lines = new string[] {
                "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886",
                "Novelist=cccc;BestWork=ぼっちゃん;Born=1990",
                "Novelist=eeeeeee;BestWork=走れメロス;Born=2000",

            };
            foreach (var line in lines) {
                foreach (var words in line.Split ( ';' )) {
                    var words2 = words.Split ( '=' );
                    Console.WriteLine ( "{0}：{1}", ToJapanese ( words2[0] ), words2[1] );
                }
            }

#endif
            Console.WriteLine ( "実行時間 = {0}", sw.Elapsed.ToString ( @"ss\.fffff" ) );
        }

        static string ToJapanese(string key) {
            switch (key) {
                case "Novelist":
                    return "作家";

                case "BestWork":
                    return "代表作";

                case "Born":
                    return "誕生年";
            }
            throw new ArgumentException ( "正しい引数ではない" );
        }
    }
}
