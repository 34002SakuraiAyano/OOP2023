using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0411 {
    class Program {
        static void Main(string[] args) {

            /*  int count = int.Parse(Console.ReadLine());

              for (int i = 0; i < count; i++) {
                  //空白を出力
                  for (int j = 0; j <i; j++) {
                      Console.Write(" ");
                  }
                  //1つずつ*増やす
                  for (int k = 0; k < count-i; k++) { 
                      Console.Write(" *");
                  }
                  Console.WriteLine();
              } */

            //金額入力
            int change = 0;
            Console.Write("金額：");
            int money = int.Parse(Console.ReadLine());

            //支払い金額入力
            Console.Write("支払：");
            int pay = int.Parse(Console.ReadLine());

            //お釣りの計算
            change = pay - money;
            Console.WriteLine("お釣り：" + change + "円");


            int[] moneyint = { 10000, 5000, 2000, 1000, 500, 100, 50, 10, 5, 1 };
            int[] cnt = new int[moneyint.Length];
            String[] monystr = { "一万円札:", "五千円札:", "二千円札:", "千円札:", "五百円玉:", "百円玉:", "五十円玉:", "十円玉:", "五円玉:", "一円玉:" };

            for (int i = 0; i < moneyint.Length; i++)
            {

                cnt[i] = change / moneyint[i];
                change = change % moneyint[i];
            }

            //金額枚数出力
            for (int j = 0; j < moneyint.Length; j++)
            {
                Console.Write(monystr[j] );
                astOut(cnt[j]);
            }
        }

            //指定した個数の"*"を出力
            private static void astOut(int count) {
                for (int i = 0; i < count; i++) {
                    Console.Write("*");
                }
                Console.WriteLine();//改行
            }

           // Console.WriteLine("一万円札" + change / 10000);のやり方で一番初めにやる

        }
    }





