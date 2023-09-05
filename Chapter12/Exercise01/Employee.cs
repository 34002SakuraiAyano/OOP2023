using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Exercise01 {
   /* [XmlRoot ( "employee" )] //tag名の小文字化
    public class Employee {
        [XmlElement ( ElementName = "id" )]
        public int Id { get; set; }

        [XmlElement ( ElementName = "name" )]
        public string Name { get; set; }

        [XmlElement ( ElementName = "hiredate" )]
        public DateTime HireDate { get; set; }

    }
   */
    [DataContract ( Name ="employee" )] //tag名の小文字化
    public class Employee {
        [DataMember ( Name = "id" )]
        public int Id { get; set; }

        [DataMember ( Name = "name" )]
        public string Name { get; set; }

        [DataMember ( Name = "hiredate" )]
        public DateTime HireDate { get; set; }
    }
}
