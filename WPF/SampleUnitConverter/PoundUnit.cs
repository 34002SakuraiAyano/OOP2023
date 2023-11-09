using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUnitConverter {
    //ポンド単位
    public class PoundUnit : DistanceUnit {
        private static List<PoundUnit> units = new List<PoundUnit> {
            new PoundUnit{Name = "oz" , Coefficient = 1, },//オンス
            new PoundUnit{Name = "lb" , Coefficient = 16, },//ポンド
        };
        public static ICollection<PoundUnit> Units { get { return units; } }


        /// <summary>
        /// <summer>グラム単位からポンド単位に変換
        /// </summary>
        /// <param name="unit">メートル単位</param>
        /// <param name="value">値</param>
        /// <returns>変換値</returns>
        public double FromGramUnit(GramUnit unit, double value) {
            return (value * unit.Coefficient) / 28.35 / this.Coefficient;
        }
    }
}
