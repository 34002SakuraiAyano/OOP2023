using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            //コンストラクタ呼び出し
            var abbrs = new Abbreviations ();

            //ADD呼び出し
            abbrs.Add ( "IOC", "国際オリンピック委員会" );
            abbrs.Add ( "NPT", "核兵器不拡散条約" );

            //7-2-3
            //上のADDメソッドで、2つのオブジェクト

            int count = abbrs.Count;

        }
    }
}
