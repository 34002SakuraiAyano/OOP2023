using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {

            var dt = DateTime.Now;

            foreach (var dayofweek in Enum.GetValues(typeof(DayOfWeek))) {
                Console.Write ( "{0:yyyy/MM/dd}の次週の曜日は、{1}", dt, dayofweek );
                Console.WriteLine ( "{0:yyyy/MM/dd}",NextWeek(dt,(DayOfWeek)dayofweek ) );
            }
        }

        public static DateTime NextWeek(DateTime date, DayOfWeek dayOfWeek) {
            var nextweek = date.AddDays ( 7 );
            var days = (int)dayOfWeek - (int)(date.DayOfWeek);
            return nextweek.AddDays ( days );
        }
    }
}