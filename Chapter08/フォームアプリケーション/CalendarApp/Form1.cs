using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalendarApp {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent ();
        }    

        //経過日数計算
        private void btDayCalc_Click(object sender, EventArgs e) {
            var bith = dtpDate.Value;
            var now = DateTime.Now;

            var diff = now - bith;
            tbMessage.Text = "入力した日にちから"　+ diff.Days + "日経過";
        }

        //経過年数
        private void btAge_Click(object sender, EventArgs e) {
            //var birth = dtpDate.Value;
            // var now = DateTime.Now;
            //var age = GetAge ( birth, now );

            var age = GetAge ( dtpDate.Value, DateTime.Now );
            tbMessage.Text = "入力した日にちから今日まで" + age + "歳経過";
        }

        public static int GetAge(DateTime birth , DateTime targetDay) {
            var age = targetDay.Year - birth.Year;
            if (targetDay < birth.AddYears(age))
                age--;
            return age;
        }

        //実行時に一度だけ呼び出されるメソッド
        private void Form1_Load(object sender, EventArgs e) {
            var now = DateTime.Now;
            teNowTime.Text = now.ToString ();
            tmTimeDisp.Start();
        }

        //タイマーイベントハンドラー
        private void tmTimeDisp_Tick(object sender, EventArgs e) {
            teNowTime.Text = DateTime.Now.ToString ();

        }
    }
}
