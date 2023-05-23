using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section03 {
    class Program {
        static void Main(string[] args) {
            var list = new List<string> {
               "Tokyo", "New Delhi", "Bangkok", "London",
                "Paris", "Berlin", "Canberra", "Hong Kong",
            };
            var exists = list.Exists ( s => s[0] == 'B' );
            Console.WriteLine (exists);

            //var name = list.Find ( s => s.Length == 5 );
            //Console.WriteLine (name);

            //var index = list.FindIndex ( s => s == "London" );
            //Console.WriteLine ( index );

            //var names = list.ConvertAll ( s => s.ToLower() );
            //names.ForEach ( s => Console.WriteLine(s) );
        
        }
    }
}
