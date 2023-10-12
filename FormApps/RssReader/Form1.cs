﻿using System;
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

        public Form1() {
            InitializeComponent ();
        }

        //取得ボタン
        private void btGet_Click(object sender, EventArgs e) {
            if (tbUrl.Text == "") {
                return;
            }
            lbRssTitle.Items.Clear ();


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
            // wbBrowser.Navigate ( itemdDatas[lbRssTitle.SelectedIndex].Link );

        }
        //private void setSelectedMaker(CarReport.TopicGroup topicGroup) {
        //    switch (topicGroup) {
        //        case CarReport.MakerGroup.トヨタ:
        //            rbToyota.Checked = true;
        //            break;
        //        case CarReport.MakerGroup.日産:
        //            rbNissan.Checked = true;
        //            break;
        //        case CarReport.MakerGroup.ホンダ:
        //            rbHonda.Checked = true;
        //            break;
        //        case CarReport.MakerGroup.スバル:
        //            rbSubaru.Checked = true;
        //            break;
        //    }
        //}
    }
}