using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercis01 {
    class Program {
        static void Main(string[] args) {
            var text = "Cozy lummox gives smart squid who asks for job pen".ToUpper ();

            Exercise1_1 ( text );
            Console.WriteLine ();
            //Exercise1_2 ( text );

        }

        private static void Exercise1_1(string text) {
            var dict = new Dictionary<Char, int> ();
            int count = 0;
            foreach (var c in text) {
                if ('A' <= c && c <= 'Z') {
                    if (dict.ContainsKey ( c )) {
                        dict[c]++;     //既に存在する文字ADD
                    }
                    else {
                        dict[c] = 1;  //未登録（新規格納）
                    }
                }
                else {
                    //空白の処理
                }
            }
            foreach (var item in dict.OrderBy( s => s.Key )) {
                Console.WriteLine ("{0}：{1}" , item.Key,item.Value);
            }
        }
    }
}
       // private static void Exercise1_2(string text) {

       // }

