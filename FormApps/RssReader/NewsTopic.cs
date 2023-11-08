using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader {
    public class NewsTopic {
        [System.ComponentModel.DisplayName ( "トピックス" )]

        internal class TopicGroup {
        }
    }

    //トピック一覧【列挙型】
    public enum TopicGroup {
        主要,
        国際,
        エンタメ,
        スポーツ,
    }
}
