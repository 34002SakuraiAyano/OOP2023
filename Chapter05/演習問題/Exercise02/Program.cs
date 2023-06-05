using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            //5.2
            Console.Write ( "数字文字列：" );
            var line = Console.ReadLine ();

            int num;
            if (int.TryParse ( line, out num )) {
                Console.WriteLine ( "{0:#,0}" , num );
            }else {
                Console.WriteLine ( "数値文字列でない" );
            }
        }
    }
}
