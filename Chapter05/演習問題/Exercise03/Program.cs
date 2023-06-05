using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";

            Exercise3_1 ( text );
            Console.WriteLine ( "-----" );

            Exercise3_2 ( text );
            Console.WriteLine ( "-----" );

            Exercise3_3 ( text );
            Console.WriteLine ( "-----" );

            Exercise3_4 ( text );
            Console.WriteLine ( "-----" );

            Exercise3_5 ( text );
         //   {\rtf1};
        }


        private static void Exercise3_1(string text) {
            var count = text.Count ( s => s.ToString().Contains ( " " ) );
            Console.WriteLine ( "空白数: " + count );
        }

        private static void Exercise3_2(string text) {
            var replased = text.Replace ( "big", "small" );
            Console.WriteLine ( replased );
        }

        private static void Exercise3_3(string text) {
            string[] words = text.Split ( ' ' );
            Console.WriteLine ("単語数：" +  words.Length );
        }

        private static void Exercise3_4(string text) {
            var words = text.Split ( ' ' ).Where ( s => s.Length <= 4 );
            foreach (var names in words) {
                Console.WriteLine ( names );
            }
        }

        private static void Exercise3_5(string text) {
        }
    }
}
