﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            var numbers = new int[] { 5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35 };

            Exercise1_1 ( numbers );
            Console.WriteLine ( "-----" );

            Exercise1_2 ( numbers );
            Console.WriteLine ( "-----" );

            Exercise1_3 ( numbers );
            Console.WriteLine ( "-----" );

            Exercise1_4 ( numbers );
            Console.WriteLine ( "-----" );

            Exercise1_5 ( numbers );
        }

        private static void Exercise1_1(int[] numbers) {
          //  var max = numbers.Max ();
            Console.WriteLine ( numbers.Max ());
        }

        private static void Exercise1_2(int[] numbers) {
            var result = numbers.Skip ( numbers.Length - 2 );
            foreach (var item in result) {
                Console.WriteLine ( item );
            }
        }

        private static void Exercise1_3(int[] numbers) {
            var strArray = numbers.Select (s=> s.ToString());
            foreach (var str in strArray) {
                Console.WriteLine( str + " " );
            }
        }

        private static void Exercise1_4(int[] numbers) {
            var value = numbers.OrderBy ( x => x ).Select ( x => x ).Take ( 3 );
            foreach (var num in value) {
                Console.WriteLine ( num );
            }
        }

        private static void Exercise1_5(int[] numbers) {
            var num = numbers.Distinct ().Count ( n => n > 10 );
            Console.WriteLine ( num );
        }
    }
}
