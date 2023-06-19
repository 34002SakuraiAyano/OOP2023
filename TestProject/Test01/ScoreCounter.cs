using System.Collections.Generic;
using System.IO;

namespace Test01 {
    class ScoreCounter {
        private IEnumerable<Student> _students;

        // コンストラクタ
        public ScoreCounter(string filePath) {
            _students = ReadScore ( filePath );
        }

        //メソッドの概要： テストデータを読み込み、Studentオブジェクトのリストを返す
        private static IEnumerable<Student> ReadScore(string filePath) {
            var dict = new SortedDictionary<string, int> ();
            var students = new List<Student> (); //テストデータを格納
            var lines = File.ReadAllLines ( filePath ); //ファイルからすべてのデータを読み込む

            foreach (var Line in lines) {　//全ての行から1行ずつ取り出す
                var items = Line.Split ( ',' ); //カンマ区切りで項目別に分ける
                var student = new Student { //Studentインスタンスを生成
                    Name = items[0],
                    Subject = items[1],
                    Score = int.Parse ( items[2] ), //文字から数値
                };
                students.Add ( student );　//StudentインスタンスをコレクションにAdd追加
            }
            return students;
        }

        //メソッドの概要：科目別に点数集計 
        public IDictionary<string, int> GetPerStudentScore() {
            var dict = new SortedDictionary<string, int> ();
            foreach (var student in _students) {
                if (dict.ContainsKey ( student.Subject )) {
                    dict[student.Subject] += student.Score; //科目が既に存在する（点数加算）
                }else {
                    dict[student.Subject] = student.Score;  //科目が存在しない（新規格納）
                }
            }
            return dict;
        }
    }
}
