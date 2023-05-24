using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            var names = new List<string> {
                 "Tokyo", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong",
            };
            Exercise2_1 ( names );
            Console.WriteLine ("----");

            Exercise2_2 ( names );
            Console.WriteLine ("-----");

            Exercise2_3 ( names );
            Console.WriteLine ( "-----" );

            Exercise2_4 ( names );
        }

        private static void Exercise2_1(List<string> names) {
            Console.WriteLine ( "都市名を入力。空行で終了" );
            var line = Console.ReadLine ();
            var index = names.FindIndex ( s => s == line );
            Console.WriteLine ( index );

            do {
                line = Console.ReadLine ();
                if (string.IsNullOrEmpty ( line ))
                    break;
                else {
                    index = names.FindIndex ( s => s == line );
                    Console.WriteLine ( index );
                }
            } while (true);
        }

        private static void Exercise2_2(List<string> names) {
            //var 
            var count = names.Count ( s => s.Contains ( "o" ) ) ;
            Console.WriteLine ( count );
        }

        private static void Exercise2_3(List<string> names) {
            //    names.Where ( s => s.Contains ( "o" ).ToArray ().ForEach ( Console.WriteLine ));

            var selected = names.Where ( s => s.Contains ( "o" ) ).ToArray();
             foreach (var name in selected) {
                Console.WriteLine ( name );
             }
        }

        private static void Exercise2_4(List<string> names) {
            var selected = names.Where ( s => s.StartsWith("B") ).Select ( s => new { s,s.Length} );


             foreach (var item in selected) {
                Console.WriteLine ( "「{0}」は {1}文字 です", item.s , item.Length );
             }
        }
    }
}
