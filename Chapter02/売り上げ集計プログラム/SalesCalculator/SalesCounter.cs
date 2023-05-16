using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCalculator {
    //売り上げ集計クラス
    public class SalesCounter {
        private List<Sale> _sales;

        //コンストラクタ
        public SalesCounter(List<Sale> sales) {
            _sales = sales;
        }

        //店舗別に売上を求める
        public Dictionary<string ,int> GetPerStoreSales() {
            Dictionary<string, int> dict = new Dictionary<string, int> ();
            foreach (Sale sale in _sales) {
                if (dict.ContainsKey(sale.ShopName)){
                    dict[sale.ShopName] += sale.Amount; //店名が既に存在する（売り上げ加算）
                }else {
                    dict[sale.ShopName] = sale.Amount;  //店名が存在しない（新規格納）
                }             
            }
            return dict;
        }
        //売り上げデータを読み込み、Saleオブジェクトのリストを返す
        public static List<Sale> ReadSales(string filePath) {
            List<Sale> sales = new List<Sale> (); //売り上げデータを格納
            string[] lines = File.ReadAllLines ( filePath ); //ファイルからすべてのデータを読み込む

            foreach (string Line in lines) {　//全ての行から1行ずつ取り出す
                string[] items = Line.Split ( ',' ); //カンマ区切りで項目別に分ける
                Sale sale = new Sale { //Salesインスタンスを生成
                    ShopName = items[0],
                    ProductCategory = items[1],
                    Amount = int.Parse ( items[2] ), //文字から数値
                };
                sales.Add ( sale );　//SalesインスタンスをコレクションにAdd追加
            }
            return sales;
        }

    }
}
