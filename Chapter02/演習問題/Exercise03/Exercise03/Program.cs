using Excersise03;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    class Program {
        static void Main(string[] args) {
            var sales = new SalesCounter ( @"data\Sales.csv" );
            var amountPerStore = sales.GetPerProductCategory ();
            foreach (KeyValuePair<string, int> obj in amountPerStore) {
                Console.WriteLine ( "{0} {1:#,0}", obj.Key, obj.Value );
            }
        }
    }
}
