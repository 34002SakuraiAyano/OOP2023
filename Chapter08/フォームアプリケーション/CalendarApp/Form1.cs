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

        private void btDayCalc_Click(object sender, EventArgs e) {
            var bith = dtpDate.Value;
            var _time = DateTime.Now;

            var diff = _time - bith;
            tbMessage.Text = "Textプロパティへ文字列を渡すと表示されます。";
            tbMessage.Text = diff.ToString();
        }

        private void dtOneYear_Click(object sender, EventArgs e) {
            var birth = dtpDate.Value.AddYears ( 1 );

        }
    }
}
