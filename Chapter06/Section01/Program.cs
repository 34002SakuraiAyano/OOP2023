using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    class Program {
        static void Main(string[] args) {
            var numbers = new List<int> {9,7,5,3,4,5,8,7,8,5,9, };
            Console.WriteLine (numbers.Average());

            var books = Books.GetBooks ();

            var sortbooks = books.Where( x=> x.Title.Contains( "物語" )).OrderByDescending(x=> x.Price) ;
            foreach (var book in sortbooks) {
                Console.WriteLine ( "{0}:{1}円",book.Title ,book.Price);
            }
        }
    }
}
