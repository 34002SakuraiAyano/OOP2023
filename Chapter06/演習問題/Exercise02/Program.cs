﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            var books = new List<Book> {
               new Book { Title = "C#プログラミングの新常識", Price = 3800, Pages = 378 },
               new Book { Title = "ラムダ式とLINQの極意", Price = 2500, Pages = 312 },
               new Book { Title = "ワンダフル・C#ライフ", Price = 2900, Pages = 385 },
               new Book { Title = "一人で学ぶ並列処理プログラミング", Price = 4800, Pages = 464 },
               new Book { Title = "フレーズで覚えるC#入門", Price = 5300, Pages = 604 },
               new Book { Title = "私でも分かったASP.NET MVC", Price = 3200, Pages = 453 },
               new Book { Title = "楽しいC#プログラミング教室", Price = 2540, Pages = 348 },
            };

            Exercise2_1 ( books );
            Console.WriteLine ( "-----" );

            Exercise2_2 ( books );

            Console.WriteLine ( "-----" );

            Exercise2_3 ( books );
            Console.WriteLine ( "-----" );

            Exercise2_4 ( books );
            Console.WriteLine ( "-----" );

            Exercise2_5 ( books );
            Console.WriteLine ( "-----" );

            Exercise2_6 ( books );

            Console.WriteLine ( "-----" );

            Exercise2_7 ( books );
        }

        private static void Exercise2_1(List<Book> books) {
            var code = books.Where ( x => x.Title.Contains ( "ワンダフル・C#ライフ" ) );
            foreach (var book in code) {
                Console.WriteLine ( "{0}円：{1}ページ", book.Price, book.Pages );
            }
        }

        private static void Exercise2_2(List<Book> books) {
            var count = books.Count ( n => n.Title.Contains ( "C#" ) );
            Console.WriteLine ( count );
        }

        private static void Exercise2_3(List<Book> books) {
            double avgPage = books.Where ( x => x.Title.Contains ( "C#" ) ).Average ( x => x.Pages );
            Console.WriteLine ( "{0}ページ", avgPage );
        }

        private static void Exercise2_4(List<Book> books) {
            var code = books.FirstOrDefault ( x => x.Price >= 4000 );
            Console.WriteLine ( "{0}", code.Title );
        }

        private static void Exercise2_5(List<Book> books) {
            var maxBooks = books.Where ( x => x.Price < 4000 ).Max ( x => x.Pages );
            Console.WriteLine ( "{0}ページ", maxBooks );
        }

        private static void Exercise2_6(List<Book> books) {
            var value = books.Where ( x => x.Pages >= 400 ).OrderByDescending ( x => x.Price );
            foreach (var book in value) {
                Console.WriteLine ( "{0}：{1}円", book.Title , book.Price);
            }
        }

        private static void Exercise2_7(List<Book> books) {
            var booksName = books.Where ( n => n.Title.Contains ( "C#" ) && n.Pages <= 500 );
            foreach (var book in booksName) {
                Console.WriteLine ( "{0}", book.Title );
            }
        }
    }

    class Book {
        public string Title { get; set; }
        public int Price { get; set; }
        public int Pages { get; set; }
    }
}
