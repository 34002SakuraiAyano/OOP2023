﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            var numbers = new List<int> { 12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48 };

            // 3.1.1
            Exercise1_1 ( numbers );
            Console.WriteLine ( "-----" );

            // 3.1.2
            Exercise1_2 ( numbers );
            Console.WriteLine ( "-----" );

            // 3.1.3
            Exercise1_3 ( numbers );
            Console.WriteLine ( "-----" );

            // 3.1.4
            Exercise1_4 ( numbers );
        }


        private static void Exercise1_1(List<int> numbers) {
            var exists = numbers.Exists ( n => n % 8 == 0 || n % 9 == 0 ); //8または9
            Console.WriteLine ( exists );

            if (exists) {
                Console.WriteLine ( "存在しています" );
            }
            else {
                Console.WriteLine ( "存在していません" );
            }
        }
        
        private static void Exercise1_2(List<int> numbers) {
            numbers.ForEach ( n => Console.WriteLine(n/2.0) ); // ForEach(2.0)で割る
        }
        
        private static void Exercise1_3(List<int> numbers) {
            numbers.Where ( n => n >= 50 ).ToList ().ForEach ( n => Console.WriteLine ( n + " " ) );

           // var num = numbers.Where ( n => n >= 50 );
           // foreach (var n in num) {
            //    Console.WriteLine ( n );
           // }
        }

        private static void Exercise1_4(List<int> numbers) {
            numbers.Where ( n => n >= 50 ).ToList ().ForEach ( Console.WriteLine );

            //List<int> query = (List<int>)numbers.Select ( n => n * 2).ToList ();
            //foreach (var n in query) {
           //     Console.WriteLine ( n );
           // }
        }
    }
}
