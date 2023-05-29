using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section07 {
    class Program {
        static void Main(string[] args) {
            var str = "166";

            int height;
            if (int.TryParse ( str, out height )) {
                //変換に成功
                Console.WriteLine ( height );
            }else {
                //変換に失敗
                Console.WriteLine ( "変換できません" );
            }
        }
    }
}
