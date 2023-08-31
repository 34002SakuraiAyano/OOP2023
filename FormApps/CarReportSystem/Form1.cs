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
        Settings settings = new Settings ();

        //コンストラクタ
        public Form1() {
            InitializeComponent ();
            dgvCarReports.DataSource = CarReports;
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
            }
            else if (cbCarName.Text == "") {
                statusLabelDisp ( "車名を入力してください" );
                return;
            }

            CarReports.Add ( new CarReport {
                Date = dtpDate.Value,
                Author = cbAuthor.Text,
                Maker = getSelectdMaker (),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                CarImage = pbCarImage.Image,
            } );

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
        private void setSelectedMaker(CarReport.MakerGroup makerGroup) {
            switch (makerGroup) {
                case CarReport.MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.スズキ:
                    rbSuzuki.Checked = true;
                    break;
                case CarReport.MakerGroup.ダイハツ:
                    rbDaihatsu.Checked = true;
                    break;
                case CarReport.MakerGroup.輸入車:
                    rbImported.Checked = true;
                    break;
                case CarReport.MakerGroup.その他:
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
            
            dgvCarReports.Columns[5].Visible = false;　//画像項目非表示
            tsTime.Text = DateTime.Now.ToString ( "yyyy年MM月dd日HH時MM分ss秒" ); //情報表示領域のテキストを初期化
            tsTime.BackColor = Color.Black;
            tsTime.ForeColor = Color.White;
            tmTimeUpdate.Start (); //時刻更新用のタイマー

            dgvCarReports.RowsDefaultCellStyle.BackColor = Color.LightGoldenrodYellow; //全体に色設定
            dgvCarReports.AlternatingRowsDefaultCellStyle.BackColor = Color.AntiqueWhite;　//奇数行の色を上書き設定

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
            //   var dgv = dgvCarReports.CurrentRow;
            //  CarReports.RemoveAt(dgv.Index);
            CarReports.RemoveAt ( dgvCarReports.CurrentRow.Index );
            //マスク表示
            if (CarReports.Count == 0) {
                btModifyReport.Enabled = false; //修正
                btDeleteReport.Enabled = false; //削除
            }
        }

        //レコード選択時
        private void dgvCarReports_Click(object sender, EventArgs e) {  //範囲選択コメント[ctrl + kc]
            //if ( dgvCarReports.RowCount != 0) {

            //    dtpDate.Value = (DateTime)dgvCarReports.CurrentRow.Cells[0].Value;  //日付
            //    cbAuthor.Text = dgvCarReports.CurrentRow.Cells[1].Value.ToString ();  //記録者

            //    //var tmp = (CarReport.MakerGroup)dgvCarReports.CurrentRow.Cells[2].Value;  //メーカー
            //    setSelectedMaker ( (CarReport.MakerGroup)dgvCarReports.CurrentRow.Cells[2].Value );

            //    cbCarName.Text = dgvCarReports.CurrentRow.Cells[3].Value.ToString (); //車名
            //    tbReport.Text = dgvCarReports.CurrentRow.Cells[4].Value.ToString ();  //レポート
            //    pbCarImage.Image = (Image)dgvCarReports.CurrentRow.Cells[5].Value;  //写真
            //}
        }

        //更新（修正）イベントハンドラ
        private void btModifyReport_Click(object sender, EventArgs e) {
            if (dgvCarReports.RowCount != 0) {
                //履歴追加
                setCbAuthor ( cbAuthor.Text );
                setCbCarName ( cbCarName.Text );

                CarReports[dgvCarReports.CurrentRow.Index].Date = dtpDate.Value;
                CarReports[dgvCarReports.CurrentRow.Index].Author = cbAuthor.Text;
                CarReports[dgvCarReports.CurrentRow.Index].Maker = getSelectdMaker ();
                CarReports[dgvCarReports.CurrentRow.Index].CarName = cbCarName.Text;
                CarReports[dgvCarReports.CurrentRow.Index].Report = tbReport.Text;
                CarReports[dgvCarReports.CurrentRow.Index].CarImage = pbCarImage.Image;
                //更新
                dgvCarReports.Refresh ();
                //項目クリア
                ClearSelection ();
            }
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

        //保存ボタン
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

        //開くボタン
        private void 開くToolStripMenuItem_Click(object sender, EventArgs e) {
            if (ofdCarRepoOpen.ShowDialog () == DialogResult.OK) {
                try {
                    //逆シリアル化でバイナリ形式を取り込む
                    var bf = new BinaryFormatter ();

                    using (FileStream fs = File.Open ( ofdCarRepoOpen.FileName, FileMode.Open, FileAccess.Read )) {
                        CarReports = (BindingList<CarReport>)bf.Deserialize ( fs );
                        dgvCarReports.DataSource = null;
                        dgvCarReports.DataSource = CarReports;

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
        private void dgvCarReports_CellClick(object sender, DataGridViewCellEventArgs e) {
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
    }
}
