using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace CarReportSystem {
    public partial class Form1 : Form {
        //管理用データ
        BindingList<CarReport> CarReports = new BindingList<CarReport> ();
        private int mode;

        //設定情報（保存用）オブジェクト
       // Settings settings = new Settings ();

        Settings settings = Settings.getInstance();


        //コンストラクタ
        public Form1() {
            InitializeComponent ();
          // dgvCarReports.DataSource = CarReports;
        }

        private void statusLabelDisp(string msg = "") {
            //MessageBox.Show(msg);
            tsInfoText.Text = msg;
        }

        //追加ボタンがクリックされた時のイベントハンドラー
        private void btAddReport_Click(object sender, EventArgs e) {
            statusLabelDisp ();//⑥ステータスラベルのテキスト非表示
            if (cbAuthor.Text == "") {
                statusLabelDisp ( "記録者を入力してください" );
                return;
            }else if (cbCarName.Text == "") {
                statusLabelDisp ( "車名を入力してください" );
                return;
            }

            DataRow newRow = infosys202301DataSet.CarReportTable.NewRow ();
            newRow[1] = dtpDate.Value;
            newRow[2] = cbAuthor.Text;
            newRow[3] = getSelectdMaker();
            newRow[4] = cbCarName.Text;
            newRow[5] = tbReport.Text;
            newRow[6] = ImageToByteArray ( pbCarImage.Image );

            infosys202301DataSet.CarReportTable.Rows.Add ( newRow );
            this.carReportTableTableAdapter.Update ( infosys202301DataSet.CarReportTable);


            //CarReports.Add ( new CarReport {
            //    Date = dtpDate.Value,
            //    Author = cbAuthor.Text,
            //    Maker = getSelectdMaker (),
            //    CarName = cbCarName.Text,
            //    Report = tbReport.Text,
            //    CarImage = pbCarImage.Image,
            //} );

            //マスク
            btModifyReport.Enabled = true;
            btDeleteReport.Enabled = true;
            btScaleChange.Enabled = false;

            //⑦履歴追加
            setCbAuthor(cbAuthor.Text);
            setCbCarName(cbCarName.Text);

            //⑤追加ボタンクリックで項目クリアする
            ClearSelection ();

            dgvCarReports.ClearSelection ();

        }

        //記録者と車名履歴追加・重複なし
        private void setCbAuthor(string author) {
            if (!cbAuthor.Items.Contains ( author )) {
                cbAuthor.Items.Add ( author );
            }
        }
        private void setCbCarName(string carname) {
            if (!cbCarName.Items.Contains( carname )) {
                cbCarName.Items.Add( carname );
            }
        }

        //項目クリア
        private void ClearSelection() {
            dtpDate.Value = DateTime.Today;
            cbAuthor.Text = null;
            cbCarName.Text = null;
            rbToyota.Checked = true;
            tbReport.Text = null;
            pbCarImage.Image = null;
        }

        //ラジオボタンで選択されているメーカーを返却
        private CarReport.MakerGroup getSelectdMaker() {
            // int tag = 0;
            foreach (var item in gbMaker.Controls) {
                if (((RadioButton)item).Checked) {
                    //tag = int.Parse ( ((RadioButton)item).Tag.ToString () );
                    //break;
                    return (CarReport.MakerGroup)int.Parse ( ((RadioButton)item).Tag.ToString () );
                }
            }
            return CarReport.MakerGroup.その他;
            /*    if (rbToyota.Checked) {
                   return CarReport.MakerGroup.トヨタ;
               }else if (rbNissan.Checked) {
                   return CarReport.MakerGroup.日産;
               }else if (rbHonda.Checked) {
                   return CarReport.MakerGroup.ホンダ;
               }else if (rbSubaru.Checked) {
                   return CarReport.MakerGroup.スバル;
               }else if (rbSuzuki.Checked) {
                   return CarReport.MakerGroup.スズキ;
               }else if (rbDaihatsu.Checked) {
                   return CarReport.MakerGroup.ダイハツ;
               }else if (rbImported.Checked) {
                   return CarReport.MakerGroup.輸入車;
               }
               return CarReport.MakerGroup.その他; */
        }

        //指定したメーカーのラジオボタンをセット
        private void setSelectedMaker(string makerGroup) {
            switch (makerGroup) {
                case "トヨタ":
                    rbToyota.Checked = true;
                    break;
                case "日産":
                    rbNissan.Checked = true;
                    break;
                case "ホンダ":
                    rbHonda.Checked = true;
                    break;
                case "スバル":
                    rbSubaru.Checked = true;
                    break;
                case "スズキ":
                    rbSuzuki.Checked = true;
                    break;
                case "ダイハツ":
                    rbDaihatsu.Checked = true;
                    break;
                case "輸入車":
                    rbImported.Checked = true;
                    break;
                case "その他":
                    rbOthers.Checked = true;
                    break;
                default:
                    break;
            }
        }

        //写真追加
        private void btImageOpen_Click(object sender, EventArgs e) {
            if (ofdImageFileOpen.ShowDialog () == DialogResult.OK) {
                //  ofdImageFileOpen.ShowDialog ();
                pbCarImage.Image = Image.FromFile ( ofdImageFileOpen.FileName );
                btScaleChange.Enabled = true;
                btImageDelete.Enabled = true;
            }
        }

        //Formを開いたとき
        private void Form1_Load(object sender, EventArgs e) {

            dgvCarReports.Columns[6].Visible = false;　//画像項目非表示
            tsTime.Text = DateTime.Now.ToString ( "yyyy年MM月dd日HH時MM分ss秒" ); //情報表示領域のテキストを初期化
            tsTime.BackColor = Color.Black;
            tsTime.ForeColor = Color.White;
            tmTimeUpdate.Start (); //時刻更新用のタイマー

            dgvCarReports.RowsDefaultCellStyle.BackColor = Color.LightGoldenrodYellow; //全体に色設定
            dgvCarReports.AlternatingRowsDefaultCellStyle.BackColor = Color.PowderBlue ;　//奇数行の色を上書き設定


            tsInfoText.Text = " ";

            if (CarReports.Count == 0) { //マスク
                btScaleChange.Enabled = false;  //サイズ変更ボタン
                btImageDelete.Enabled = false;  //削除ボタン
            }

            try {
                //設定ファイルを逆シリアル化して背景設定
                using (var reader = XmlReader.Create ( "setting.xml" )) {
                    var serializer = new XmlSerializer ( typeof ( Settings ) );
                    settings = serializer.Deserialize ( reader ) as Settings;
                    BackColor = Color.FromArgb ( settings.MainFormColor );
                }
            }
            catch (Exception ex) {
                MessageBox.Show ( ex.Message);
            }
        }

        //削除ボタン
        private void btDeleteReport_Click(object sender, EventArgs e) {

            dgvCarReports.Rows.RemoveAt ( dgvCarReports.CurrentRow.Index );
            ClearSelection ();
            carReportTableTableAdapter.Update ( infosys202301DataSet.CarReportTable ); //更新
        }

    /*    //レコード選択時
       private void dgvCarReports_Click(object sender, EventArgs e) {  //範囲選択コメント[ctrl + kc]
            if (dgvCarReports.RowCount != 0) {

                dtpDate.Value = (DateTime)dgvCarReports.CurrentRow.Cells[0].Value;  //日付
                cbAuthor.Text = dgvCarReports.CurrentRow.Cells[1].Value.ToString ();  //記録者

                //var tmp = (CarReport.MakerGroup)dgvCarReports.CurrentRow.Cells[2].Value;  //メーカー
                setSelectedMaker ( (CarReport.MakerGroup)dgvCarReports.CurrentRow.Cells[2].Value );

                cbCarName.Text = dgvCarReports.CurrentRow.Cells[3].Value.ToString (); //車名
                tbReport.Text = dgvCarReports.CurrentRow.Cells[4].Value.ToString ();  //レポート
                pbCarImage.Image = (Image)dgvCarReports.CurrentRow.Cells[5].Value;  //写真
            }
        }
    */

        //更新（修正）イベントハンドラ
        private void btModifyReport_Click(object sender, EventArgs e) {
            dgvCarReports.CurrentRow.Cells[1].Value = dtpDate.Value;  // 日付
            dgvCarReports.CurrentRow.Cells[2].Value = cbAuthor.Text;  // 記録者
            dgvCarReports.CurrentRow.Cells[3].Value = getSelectdMaker();  //メーカー
            dgvCarReports.CurrentRow.Cells[4].Value = cbCarName.Text; //車名
            dgvCarReports.CurrentRow.Cells[5].Value = tbReport.Text;  //レポート
            dgvCarReports.CurrentRow.Cells[6].Value = pbCarImage.Image ;  //写真

            this.Validate ();
            this.carReportTableBindingSource.EndEdit ();
            this.tableAdapterManager.UpdateAll ( this.infosys202301DataSet );

            btImageDelete.Enabled = false;
        }

        //画像削除ボタン
        private void btImageDelete_Click(object sender, EventArgs e) {
            pbCarImage.Image = null;
        }

        //終了メニュー選択時のイベントハンドラ
        private void 終了XToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit ();
        }


        private void バージョン情報ToolStripMenuItem_Click(object sender, EventArgs e) {
            var vf = new VersionForm ();
            vf.ShowDialog ();  //モーダルダイヤログで表示
        }

        //背景色変更
        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (cdColor.ShowDialog () == DialogResult.OK) {
                BackColor = cdColor.Color;
                settings.MainFormColor = cdColor.Color.ToArgb() ;
            }
        }

        //サイズ変更
        private void btScaleChange_Click(object sender, EventArgs e) {
            mode = mode < 4 ? ((mode == 1) ? 3 : ++mode) : 0;  //AutoSize(2)を除外
          //mode = mode < 4 ? ++mode : 0;
            pbCarImage.SizeMode = (PictureBoxSizeMode)mode;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            //設定ファイルのシリアル化
            using (var writer = XmlWriter.Create ("setting.xml")) {
                var serializer = new XmlSerializer ( settings.GetType());
                serializer.Serialize (writer, settings );
            }
        }

        private void tmTimeUpdate_Tick(object sender, EventArgs e) {
            tsTime.Text = DateTime.Now.ToString ("yyyy年MM月dd日HH時MM分ss秒"); //情報表示領域のテキストを初期化
        }

   /*   //保存ボタン
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (sfdCarRepoSave.ShowDialog () == DialogResult.OK) {
                try {
                    //バイナリ形式でシリアル化
                    var bf = new BinaryFormatter ();
                    using (FileStream fs = File.Open ( sfdCarRepoSave.FileName, FileMode.Create )) {
                        bf.Serialize ( fs, CarReports );
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show ( ex.Message );
                }
            }
        } 
     */

   /*     //開くボタン
        private void 開くToolStripMenuItem_Click(object sender, EventArgs e) {
            if (ofdCarRepoOpen.ShowDialog () == DialogResult.OK) {
                try {
                    //逆シリアル化でバイナリ形式を取り込む
                    var bf = new BinaryFormatter ();
                    using (FileStream fs = File.Open ( ofdCarRepoOpen.FileName, FileMode.Open, FileAccess.Read )) {
                        CarReports = (BindingList<CarReport>)bf.Deserialize ( fs );
                        dgvCarReports.DataSource = null;
                        dgvCarReports.DataSource = CarReports;

                        //画像項目非表示
                        dgvCarReports.Columns[5].Visible = false;　


                        //記録者と車名履歴/重複なし
                        foreach (var carReport in CarReports) {
                            setCbAuthor ( carReport.Author );
                            setCbCarName ( carReport.CarName );
                        }

                        //選択行の解除
                        dgvCarReports.ClearSelection ();

                        //マスク
                        btModifyReport.Enabled = true;  //修正
                        btDeleteReport.Enabled = true;  //削除
                        btScaleChange.Enabled = false;  //サイズ変更
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show ( ex.Message );
                }
            }
        }  
   */

        private void dgvCarReports_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (dgvCarReports.RowCount != 0) {
                dtpDate.Value = (DateTime)dgvCarReports.CurrentRow.Cells[1].Value;  //日付
                cbAuthor.Text = dgvCarReports.CurrentRow.Cells[2].Value.ToString ();  //記録者
                //var tmp = (CarReport.MakerGroup)dgvCarReports.CurrentRow.Cells[2].Value;  //メーカー
                //setSelectedMaker ( (CarReport.MakerGroup)dgvCarReports.CurrentRow.Cells[3].Value );
                setSelectedMaker (dgvCarReports.CurrentRow.Cells[3].Value.ToString() );
                cbCarName.Text = dgvCarReports.CurrentRow.Cells[4].Value.ToString (); //車名
                tbReport.Text = dgvCarReports.CurrentRow.Cells[5].Value.ToString ();  //レポート


                //写真表示
                pbCarImage.Image = !dgvCarReports.CurrentRow.Cells[6].Value.Equals(DBNull.Value)
                        &&((Byte[])dgvCarReports.CurrentRow.Cells[6].Value).Length != 0 ?
                          ByteArrayToImage ( (Byte[])dgvCarReports.CurrentRow.Cells[6].Value ) : null;
                                            //　↓
                //if (!dgvCarReports.CurrentRow.Cells[6].Value.Equals(DBNull.Value)) {
                //    pbCarImage.Image = ByteArrayToImage ( (Byte[])dgvCarReports.CurrentRow.Cells[6].Value );  //写真表示
                //}else {
                //    pbCarImage.Image = null;
                //}

                btModifyReport.Enabled = true;  //修正
                btDeleteReport.Enabled = true;  //削除
            }
        }

        // バイト配列をImageオブジェクトに変換
        public static Image ByteArrayToImage(byte[] b) {
            ImageConverter imgconv = new ImageConverter ();
            Image img = (Image)imgconv.ConvertFrom ( b );
            return img;
        }

        // Imageオブジェクトをバイト配列に変換
        public static byte[] ImageToByteArray(Image img) {
            ImageConverter imgconv = new ImageConverter ();
            byte[] b = (byte[])imgconv.ConvertTo ( img, typeof ( byte[] ) );
            return b;
        }


        //DB保存
        private void carReportTableBindingNavigatorSaveItem_Click(object sender, EventArgs e) {
            this.Validate ();
            this.carReportTableBindingSource.EndEdit ();
            this.tableAdapterManager.UpdateAll ( this.infosys202301DataSet );
        }

        //接続
        private void 接続ToolStripMenuItem_Click(object sender, EventArgs e) {
            dbConnection ();
        }
        //メソッド
        private void dbConnection() {
            // TODO: このコード行はデータを 'infosys202301DataSet.CarReportTable' テーブルに読み込みます。必要に応じて移動、または削除をしてください。    
            this.carReportTableTableAdapter.Fill ( this.infosys202301DataSet.CarReportTable );
            dgvCarReports.ClearSelection ();  //選択解除

            //記録者と車名履歴/重複なし
            foreach (var carReport in infosys202301DataSet.CarReportTable) {
                setCbAuthor ( carReport.Author );
                setCbCarName ( carReport.CarName );
            }
        }
    }
}
