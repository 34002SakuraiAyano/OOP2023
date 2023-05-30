using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    public class YearMonth {
        //4-1-1
        //年と月のプロパティ
        public int Year { get; private set; } 　//年
        public int Month { get; private set; }  //月

        //コンストラクタ
        public YearMonth(int year, int month) {
            Year = year;
            Month = month;
        }

        //4-1-2  21世紀
        public bool Is21Century {
            get {
                return 2001 <= Year && Year <= 2100; //&&はかつ
            }
        }

        public YearMonth AddOneMonth() {
            if (Month == 12) {
                return new YearMonth ( Year + 1, 1 );
            }
            else {
                return new YearMonth ( Year, Month + 1 );
            }
            // return new YearMonth ( Month == 12 ? Year + 1 : Year, Month == 12 ? 1 : Month + ! );
        }

        public override string ToString() {
            return Year + "年" + Month + "月";
        }
    }
}

