using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {
        //取得データ保存用
        List<ItemData> itemdDatas = new List<ItemData> ();
        List<ItemData> favoriteDatas = new List<ItemData> ();

        public Form1() {
            InitializeComponent ();
        }

        //取得ボタン
        private void btGet_Click(object sender, EventArgs e) {
            if (tbUrl.Text == "") {
                return;
            }
            lbRssTitle.Items.Clear ();

            GetItems();
        }

        private void GetItems() {
            using (var wc = new WebClient ()) {
                var url = wc.OpenRead ( tbUrl.Text );
                XDocument xdoc = XDocument.Load ( url );
                itemdDatas = xdoc.Root.Descendants ( "item" )
                                .Select ( x => new ItemData {
                                    Title = (string)x.Element ( "title" ),
                                    Link = (string)x.Element ( "link" )
                                } ).ToList ();

                foreach (var node in itemdDatas) {
                    lbRssTitle.Items.Add ( node.Title );
                }
            }
        }

        // @"https://news.yahoo.co.jp/rss/topics/entertainment.xml", cityCode );


        //タイトル押したらウェブサイト行き
        private void lbRssTitle_SelectedIndexChanged_1(object sender, EventArgs e) {
            //インデックス番号を取得
            if (lbRssTitle.SelectedIndex == -1)
                return;
            var item = lbRssTitle.SelectedIndex;
            wbBrowser.Navigate ( itemdDatas[item].Link );
            tbUrl.Text = itemdDatas[item].Link;
        }

        //主要ボタン
        private void rbMain_CheckedChanged(object sender, EventArgs e) {
            lbRssTitle.Items.Clear ();

            using (var wc = new WebClient ()) {
                var url = wc.OpenRead ( @"https://news.yahoo.co.jp/rss/topics/top-picks.xml" );
                XDocument xdoc = XDocument.Load ( url );
                itemdDatas = xdoc.Root.Descendants ( "item" )
                                .Select ( x => new ItemData {
                                    Title = (string)x.Element ( "title" ),
                                    Link = (string)x.Element ( "link" )
                                } ).ToList ();

                foreach (var node in itemdDatas) {
                    lbRssTitle.Items.Add ( node.Title );
                }
            }
        }

        //国際ボタン
        private void rbGrobal_CheckedChanged(object sender, EventArgs e) {
            lbRssTitle.Items.Clear ();

            using (var wc = new WebClient ()) {
                var url = wc.OpenRead ( @"https://news.yahoo.co.jp/rss/topics/world.xml" );
                XDocument xdoc = XDocument.Load ( url );
                itemdDatas = xdoc.Root.Descendants ( "item" )
                                .Select ( x => new ItemData {
                                    Title = (string)x.Element ( "title" ),
                                    Link = (string)x.Element ( "link" )
                                } ).ToList ();

                foreach (var node in itemdDatas) {
                    lbRssTitle.Items.Add ( node.Title );
                }
            }
        }
        //スポーツ
        private void rbSports_CheckedChanged(object sender, EventArgs e) {
            lbRssTitle.Items.Clear ();

            using (var wc = new WebClient ()) {
                var url = wc.OpenRead ( @"https://news.yahoo.co.jp/rss/topics/sports.xml" );
                XDocument xdoc = XDocument.Load ( url );
                itemdDatas = xdoc.Root.Descendants ( "item" )
                                .Select ( x => new ItemData {
                                    Title = (string)x.Element ( "title" ),
                                    Link = (string)x.Element ( "link" )
                                } ).ToList ();

                foreach (var node in itemdDatas) {
                    lbRssTitle.Items.Add ( node.Title );
                }
            }
        }

        //エンタメ
        private void rbEnter_CheckedChanged(object sender, EventArgs e) {
            lbRssTitle.Items.Clear ();

            using (var wc = new WebClient ()) {
                var url = wc.OpenRead ( @"https://news.yahoo.co.jp/rss/topics/entertainment.xml" );
                XDocument xdoc = XDocument.Load ( url );
                itemdDatas = xdoc.Root.Descendants ( "item" )
                                .Select ( x => new ItemData {
                                    Title = (string)x.Element ( "title" ),
                                    Link = (string)x.Element ( "link" )
                                } ).ToList ();

                foreach (var node in itemdDatas) {
                    lbRssTitle.Items.Add ( node.Title );
                }
            }
        }


        //お気に入りボタン
        private void button1_Click(object sender, EventArgs e) {
            //var item = lbRssTitle.SelectedIndex;
            favoritetListBox.Items.Add ( itemdDatas[lbRssTitle.SelectedIndex].Title );
            foreach (var item in itemdDatas) {
                if (item.Title == (string)lbRssTitle.SelectedItem) {
                    favoriteDatas.Add ( new ItemData {
                        Title = item.Title,
                        Link = item.Link
                    } );
                }
            }
        }

        //リストのタイトルクリックで画面表示
        private void favoritetListBox_SelectedIndexChanged_1(object sender, EventArgs e) {
            if (favoritetListBox.SelectedIndex == -1)
                return;
                wbBrowser.Navigate ( favoriteDatas[favoritetListBox.SelectedIndex].Link);
            tbUrl.Text = favoriteDatas[favoritetListBox.SelectedIndex].Link;
        }
    }
}
