using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            Exercise1_1 ( "employee.xml" );

            //これは確認用
            Console.WriteLine ( File.ReadAllText ( "employee.xml" ) );
            Console.WriteLine ();

            Exercise1_2 ( "employees.xml" );
            Exercise1_3 ( "employees.xml" );
            Console.WriteLine ();

            Exercise1_4 ( "employees.json" );

            //これは確認用
            Console.WriteLine ( File.ReadAllText ( "employees.json" ) );
        }

        private static void Exercise1_1(string v) {
            var employees = new Employee {
                Id = 1001,        //int
                Name = "佐藤",　//string
                HireDate = new DateTime ( 2005, 2, 24 ),//Datetime
            };

            //シリアル化
            using (var writer = XmlWriter.Create( "employee.xml" )) {
                var serializer = new XmlSerializer (employees.GetType());
                serializer.Serialize ( writer, employees );
            }


            //逆シリアル化
            using (var reader = XmlReader.Create ( "employee.xml" )) {
                var serializer = new XmlSerializer ( typeof(Employee) );
                var eemployees = serializer.Deserialize ( reader ) as Employee;
                Console.WriteLine ( employees );
            }
        }
    

        private static void Exercise1_2(string v) {
            var employees = new Employee[] {
                new Employee {
                    Id = 1001,        //int
                    Name = "佐藤",　//string
                    HireDate = new DateTime ( 2005, 2, 24 ),//Datetime
                },
                new Employee {
                    Id = 1002,  
                    Name = "西田", 
                    HireDate = new DateTime ( 2006, 12, 25 ), 
                },
            };
    

          //オブジェクトの内容をXMLファイルに保存（シリアル化）
            using (var writer = XmlWriter.Create ( "employee.xml" )) {
                var serializer = new DataContractSerializer ( employees.GetType () );
                serializer.WriteObject ( writer, employees );
            }
        }

        private static void Exercise1_3(string v) {
            //XMLファイルの内容をオブジェクトに復元（逆シリアル化）
            using (XmlReader reader = XmlReader.Create ( "employee.xml" )) {
                var serializer = new DataContractSerializer ( typeof ( Employee[] ) );
                var eemployees = serializer.ReadObject ( reader ) as Employee[];
                foreach (var item in eemployees) {
                    Console.WriteLine ( item );
                }
            }
        }
    

        private static void Exercise1_4(string v) {
            var employees = new Employee[] {
                new Employee {
                    Id = 1034,   //int
                    Name = "田中",　//string
                    HireDate = new DateTime ( 20010, 6, 6 ),//Datetime
                },
                new Employee {
                    Id = 1056,
                    Name = "鈴木",
                    HireDate = new DateTime ( 2003, 8, 31 ),
                },
            };
            using (var stream = new FileStream( "employees.json", FileMode.Create, FileAccess.Write )) {
                var serializer = new DataContractJsonSerializer ( employees.GetType () );
                serializer.WriteObject ( stream, employees );
            }
        }
    }
}


