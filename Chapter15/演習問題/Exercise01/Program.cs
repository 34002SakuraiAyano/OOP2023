using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {

            //Exercise1_2 ();
            //Console.WriteLine ();

            //Exercise1_3 ();
            //Console.WriteLine ();

            //Exercise1_4 ();
            //Console.WriteLine ();

            //Exercise1_5 ();
            //Console.WriteLine ();

            //Exercise1_6 ();
            //Console.WriteLine ();

            //Exercise1_7 ();
            //Console.WriteLine ();

            Exercise1_8 ();

            Console.ReadLine ();
        }

        private static void Exercise1_2() {
            var max = Library.Books.Max ( b => b.Price );
            var book = Library.Books.First (x => x.Price == max);
            Console.WriteLine ( book );
        }

        private static void Exercise1_3() {
            var groups = Library.Books
                                .GroupBy ( b => b.PublishedYear )
                                .OrderBy ( g => g.Key );
            foreach (var g in groups) {
                Console.WriteLine ( "{0}年 : {1}冊 " ,g.Key  ,g.Count() );
            }

            //var groups = Library.Books.GroupBy ( b => b.PublishedYear )
            //        .Select(s => new { PublishedYear = s.Key, Count = s.Count () } )
            //        .OrderBy ( g => g.PublishedYear );
            //foreach (var item in groups) {
            //    Console.WriteLine ( "{0}年 : {1}冊 " , item.PublishedYear , item.Count );
            //}
        }

        private static void Exercise1_4() {
            var selected = Library.Books.OrderByDescending ( b => b.PublishedYear )
                .ThenByDescending ( b => b.Price )
                .Join ( Library.Categories,
                    book => book.CategoryId,
                    category => category.Id,
                    (book, category) => new {
                        Title = book.Title,
                        Category = category.Name,
                        PublishedYear = book.PublishedYear,
                        Price = book.Price,
                    } );
            foreach (var book in selected) {
                Console.WriteLine ( $"{book.PublishedYear}年 {book.Price} {book.Title}({book.Category})" );
            }
        }

        private static void Exercise1_5() {
            var books = Library.Books.Where ( b => b.PublishedYear == 2016 )
                .Join ( Library.Categories,
                    book => book.CategoryId,
                    category => category.Id,
                    (book, category) => category.Name ).Distinct ();

            foreach (var name in books) {
                Console.WriteLine ( name );
            }
        }

        private static void Exercise1_6() {
            var groups = Library.Categories.OrderBy( c=> c.Name).GroupJoin ( Library.Books,
                    c => c.Id,
                    b => b.CategoryId,
                    (c, books) => new {
                        Category = c.Name, Books = books} );
            foreach (var group in groups) {
                Console.WriteLine ( group.Category );
                foreach (var item in group.Books) {
                    Console.WriteLine ( $"　{item.Title}" );
                }
            }
        }

        private static void Exercise1_7() {
            var catied = Library.Categories.Single ( c => c.Name == "Development" ).Id;
            var groups = Library.Books.Where ( b => b.CategoryId == catied )
                                        .GroupBy ( b => b.PublishedYear )
                                        .OrderBy ( b => b.Key );
            foreach (var group in groups) {
                Console.WriteLine ( "#{0}年" , group.Key );
                foreach (var item in group) {
                    Console.WriteLine ( "　{0}", item.Title );
                }
            }
        }

        private static void Exercise1_8() {
            var groups = Library.Categories.GroupJoin ( Library.Books,
                   c => c.Id,
                   b => b.CategoryId,
                   (c, b) => new {
                       CategoryName = c.Name,
                       Count = b.Count ()
                   } ).Where(x => x.Count>=4);
            foreach (var item in groups) {
                Console.WriteLine ( item.CategoryName );
            }
        }
    }
}
