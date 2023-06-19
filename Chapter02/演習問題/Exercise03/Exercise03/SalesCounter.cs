using Execeise03;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excersise03 {
    //売り上げ集計クラス
    public class SalesCounter {
        private IEnumerable<Sale> _sales;

        //コンストラクタ
        public SalesCounter(string filePath) {
            _sales = ReadSales ( filePath );
        }

        //店舗別に売上を求める
        public IDictionary<string, int> GetPerStoreSales() {
            var dict = new SortedDictionary<string, int> ();
            foreach (var sale in _sales) {
                if (dict.ContainsKey ( sale.ShopName )) {
                    dict[sale.ShopName] += sale.Amount; //店名が既に存在する（売り上げ加算）
                }
                else {
                    dict[sale.ShopName] = sale.Amount;  //店名が存在しない（新規格納）
                }
            }
            return dict;
        }

        //商品カテゴリー別に売上を求める
        public IDictionary<string, int> GetPerProductCategory() {
            var dict = new SortedDictionary<string, int> ();
            foreach (var sale in _sales) {
                if (dict.ContainsKey ( sale.ProductCategory )) {
                    dict[sale.ProductCategory] += sale.Amount; //カテゴリーが既に存在する（売り上げ加算）
                }
                else {
                    dict[sale.ProductCategory] = sale.Amount;  //カテゴリーが存在しない（新規格納）
                }
            }
            return dict;
        }
       

        //売り上げデータを読み込み、Saleオブジェクトのリストを返す
        private IEnumerable<Sale> ReadSales(string filePath) {
            var sales = new List<Sale> (); //売り上げデータを格納
            var lines = File.ReadAllLines ( filePath ); //ファイルからすべてのデータを読み込む

            foreach (var Line in lines) {　//全ての行から1行ずつ取り出す
                var items = Line.Split ( ',' ); //カンマ区切りで項目別に分ける
                var sale = new Sale { //Salesインスタンスを生成
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
