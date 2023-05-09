using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSample {

    class Program {
        static void Main(string[] args) {

            #region P24
            //インスタンスの生成
            Product karinto = new Product(123, "かりんとう", 180);
            Product daifuku = new Product(235, "大福もち", 160);


            Console.WriteLine("かりんとうの税込み価格:" + karinto.GetPriceIncludingTax());
            Console.WriteLine("大福もちの税込み価格:" + daifuku.GetPriceIncludingTax());
            #endregion


           // # region 演習１,２

            //DateTime today = new DateTime(2023, 5, 8) ;
            DateTime today = DateTime.Today;

            Console.WriteLine("今日の日付は" + today + "日です");

            //10日後
            DateTime daysAfter10 = today.AddDays(10);
            Console.WriteLine("今日の１０日後は" + daysAfter10 + "日です");

            //10日前
            DateTime daysBefore10 = today.AddDays(-10);
            Console.WriteLine("今日の１０日前は" + daysBefore10 + "日です");
            
            //生まれてから今日までの経過日数（TimeSpan）
            Console.WriteLine("誕生日を入力");
            Console.Write("西暦：");
            int year = int.Parse(Console.ReadLine());
            Console.Write("月：");
            int month = int.Parse(Console.ReadLine());
            Console.Write("日：");
            int date = int.Parse(Console.ReadLine());

            DateTime birth = new DateTime (year, month, date);
            TimeSpan ts2 = today - birth;
            Console.WriteLine("あなたは生まれてから今日まで" + ts2.Days + "日目です");

            //#endregion

        }
    }
}