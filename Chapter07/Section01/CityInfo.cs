using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    public class CityInfo {
        //所在地
        public string City { get; set; }
        //人口
        public int Population { get; set; }

        //コンストラクタ
        public CityInfo(string city,int population) {
            this.City = city;
            this.Population = population;
        }
    }
}
