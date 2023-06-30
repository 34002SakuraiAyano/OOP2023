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

            //ADDメソッド呼び出し
            abbrs.Add ( "IOC", "国際オリンピック委員会" );
            abbrs.Add ( "NPT", "核兵器不拡散条約" );

            //7-2-3
            //上のADDメソッドで、2つのオブジェクトを追加しているので、
            //読み込んだ単語数が+2が、Countの値になる
            Console.WriteLine ( abbrs.Count );
            Console.WriteLine ();


            //7-2-3(Removeの呼び出し)
            if (abbrs.Remove("NPT"))
                Console.WriteLine ( abbrs.Count );          
            if(!abbrs.Remove("NPT")) 
                Console.WriteLine ( "削除できません" );
            
            Console.WriteLine ();

            //7-2-4
            //IEnumerable()を実装したのでLINQが使える
           // var target = abbrs.Where ( abb => abb.Key.Length == 3 );
            foreach (var item in abbrs.Where( abb => abb.Key.Length == 3 )) {
                Console.WriteLine ( "{0}：{1}" ,item.Key , item.Value );
            }
        }
    }
}
