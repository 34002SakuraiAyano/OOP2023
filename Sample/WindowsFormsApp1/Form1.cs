using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            // int ans = int.Parse(tbNum1.Text) + int.Parse(tbNum2.Text);
            //tbAns.Text = ans.ToString();
            int num1 = int.Parse(tbNum1.Text);
            int num2 = int.Parse(tbNum2.Text);
            int sum = num1 + num2;
            tbAns.Text = sum.ToString();
        }
        //イベントハンドラ
        private void btPow_Click(object sender, EventArgs e) {

            //1行で書く場合
           // result.Text = (Math.Pow((double)Num3.Value, (double)Num4.Value)).ToString();
            //

            int num3 = (int)Num3.Value;
            int num4 = (int)Num4.Value;
            int ans2 = 1;
            for (int i = 0; i < num4; i++){
                ans2 = ans2 * num3;
            }
            result.Text = ans2.ToString();
        }
    }
}
