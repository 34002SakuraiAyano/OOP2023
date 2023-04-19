using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallApp {
    class SoccerBall {
        //フィールド
        private Image image; //画像データ

        private double posX; //ｘ座標
        private double posY; //y座標

        private double moveX; //移動量(ｘ方向)
        private double moveY; //移動量(ｙ方向)
        Random ran = new Random();

        public SoccerBall(double xp,double yp) {
            Image = Image.FromFile(@"pic\soccer_ball.png");
            PosX = xp;
            PosY = yp;

            // double num = ran.Next(0, 500);
            // moveX = ran.Next(1, 50); 　　//乱数で移動量を設定
            //  moveY = ran.Next(1, 50) ;　　//乱数で移動量を設定

            int rndX = ran.Next(-25, -15);
            moveX = (rndX != 0 ? rndX : 1); //乱数で移動量を設定

            int rndY = ran.Next(-25, -15);
            moveY = (rndX != 0 ? rndX : 1); //乱数で移動量を設定


        }

        //プロパティ
        public Image Image { get => image; set => image = value; }
        public double PosX { get => posX; set => posX = value; }
        public double PosY { get => posY; set => posY = value; }

        //メソッド
        public void Move() {
            Console.WriteLine("x座標 = {0} , y座標 = {1}" ,posX,posY);

            if (posY > 500 || posY <0)
            {
                moveY = -moveY;
            }
            if (posX >= 720 || posX <0)
            {
                moveX = -moveX;
            }
            PosX += moveX;
            PosY += moveY;
        }
    }
}
