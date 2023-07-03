using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        public static object NextDay { get; private set; }

        static void Main(string[] args) {
            //var dateTime = new DateTime ( 2019, 1, 15, 19, 48, 32 );
            var dateTime = DateTime.Now ;
            DisplayDatePattern1 ( dateTime );
            DisplayDatePattern2 ( dateTime );
            DisplayDatePattern3 ( dateTime );
            DisplayDatePattern3_2 ( dateTime );
        }

        private static void DisplayDatePattern1(DateTime dateTime) {
            //2019/1/15 19:48
            var str = string.Format ( "{0}/{1}/{2,2} {3}:{4}" , dateTime.Year , dateTime.Month ,
                                                         dateTime.Day, dateTime.Hour, dateTime.Minute );

            Console.WriteLine ( str );
        }

        private static void DisplayDatePattern2(DateTime dateTime) {
            //2019年01月15日 19時48分32秒
            var str = string.Format ( "{0}年{1}月{2,2}日 {3}時{4}分{5}秒", dateTime.Year, dateTime.Month,
                                              dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second );
            
            Console.WriteLine ( str );
        }

        private static void DisplayDatePattern3(DateTime dateTime) {
            //平成31年 1月15日(火曜日)和暦
            var culture = new CultureInfo ( "ja-jp" );
            culture.DateTimeFormat.Calendar = new JapaneseCalendar ();
            var dayOfWeek = culture.DateTimeFormat.GetDayName ( dateTime.DayOfWeek );
            var str = dateTime.ToString ( "ggy年M月d日(ddd曜日)", culture  ) ;       
            Console.WriteLine ( str );
        }

        private static void DisplayDatePattern3_2(DateTime dateTime) {
            var culture = new CultureInfo ( "ja-jp" );
            culture.DateTimeFormat.Calendar = new JapaneseCalendar ();

            var str = dateTime.ToString ( "gy年M月d日(ddd曜日)", culture );
            //ゼロサプレス
           var zero = Regex.Replace ( str, @"0(\d)", " $1" );
            Console.WriteLine (str);
        }
    }
}
