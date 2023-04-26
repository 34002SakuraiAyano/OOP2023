using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallApp {
    class Program : Form {

        private Timer moveTimer;    //タイマー用
        private PictureBox pb;



        //ObjにSoccerBallとTennisBallが入ってる
        private List<Obj> balls = new List<Obj>();    //ボールインスタンス格納用
        private List<PictureBox> pbs = new List<PictureBox>();      //表示用


        static void Main(string[] args) {
            Application.Run(new Program());
        }

        public Program() {
            this.Size = new Size(800, 600);
            this.BackColor = Color.Green;
            this.Text = "BallGame:0";

            this.MouseClick += Program_MouseClick;
            KeyDown += Program_KeyDown;

            moveTimer = new Timer();
            moveTimer.Interval = 10; //タイマーのインターバル（ms）
            moveTimer.Tick += MoveTimer_Tick;  //デリゲート登録
             
        }

        private void Program_KeyDown(object sender, KeyEventArgs e) {

        }

        //マウスクリック時のイベントハンドラ
        private void Program_MouseClick(object sender, MouseEventArgs e) {
            //ボールインスタンス生成
            Obj ballobj = null;
            pb = new PictureBox();   //画像を表示するコントロール

            //左クリックでサッカーボール出す
            if (e.Button == MouseButtons.Left){
                ballobj= new SoccerBall(e.X - 25, e.Y - 25);
                pb.Size = new Size(50, 50); //画像の表示サイズ

            }
            else if(e.Button == MouseButtons.Right){
                ballobj = new TennisBall(e.X - 12, e.Y - 12);
                pb.Size = new Size(30, 35); //画像の表示サイズ
            }

            pb.Image = ballobj.Image;
            pb.Location = new Point((int)ballobj.PosX, (int)ballobj.PosY); //画像の位置
            pb.SizeMode = PictureBoxSizeMode.StretchImage;  //画像の表示モード
            pb.Parent = this;

            balls.Add(ballobj);
            pbs.Add(pb);
            this.Text = "BallGame SoccerBall :" + SoccerBall.Count + "TennisBall :" + TennisBall.Count;
            moveTimer.Start();  //タイマースタート

        }

        //タイマータイムアウト時のイベントハンドラ
        private void MoveTimer_Tick(object sender, EventArgs e) {
            for (int i = 0; i < balls.Count; i++){
                balls[i].Move();  //移動
                pbs[i].Location = new Point((int)balls[i].PosX, (int)balls[i].PosY); //画像の位置
            }
        }
    }
}
