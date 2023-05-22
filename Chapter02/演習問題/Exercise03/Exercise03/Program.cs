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
            Console.WriteLine ( "**売上集計**" );
            Console.WriteLine ( "１：店舗別売り上げ" );
            Console.WriteLine ( "２：商品カテゴリー別売り上げ" );
            int num = int.Parse ( Console.ReadLine () );

            switch (num) {
                case 1:
                    var amountPerStore = sales.GetPerStoreSales ();
                    foreach (KeyValuePair<string, int> obj in amountPerStore) {
                        Console.WriteLine ( "{0} {1:#,0}", obj.Key, obj.Value );
                    }
                    break;

                case 2:
                    var amountPerCategory = sales.GetPerProductCategory ();

                    foreach (KeyValuePair<string, int> obj in amountPerCategory) {
                        Console.WriteLine ( "{0} {1:#,0}", obj.Key, obj.Value );
                    }
                    break;
            }
        }
    }
}
