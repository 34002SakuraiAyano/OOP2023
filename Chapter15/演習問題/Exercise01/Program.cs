using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {

            //Exercise1_2 ();
            //Console.WriteLine ();

            Exercise1_3 ();
            Console.WriteLine ();
            
            //Exercise1_4 ();
            //Console.WriteLine ();
            
            //Exercise1_5 ();
            //Console.WriteLine ();
            
            //Exercise1_6 ();
            //Console.WriteLine ();
            
            //Exercise1_7 ();
            //Console.WriteLine ();
            
            //Exercise1_8 ();

            Console.ReadLine ();
        }

        private static void Exercise1_2() {
            var max = Library.Books.Max ( b => b.Price );
            var book = Library.Books.First (x => x.Price == max);
            Console.WriteLine ( book );
        }

        private static void Exercise1_3() {
            var groups = Library.Books
                                .GroupBy ( b => b.PublishedYear )
                                .OrderBy ( g => g.Key );
            foreach (var g in groups) {
                Console.Write ( $"{g.Key}年 : " );
                Console.WriteLine ( g.Count() );
            }
        }

        private static void Exercise1_4() {
        }

        private static void Exercise1_5() {
        }

        private static void Exercise1_6() {
            throw new NotImplementedException ();
        }

        private static void Exercise1_7() {
            throw new NotImplementedException ();
        }

        private static void Exercise1_8() {
            throw new NotImplementedException ();
        }
    }
}
