using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WeightManaged.Views {
    /// <summary>
    /// Input.xaml の相互作用ロジック
    /// </summary>
    public partial class Input : UserControl {
        public Input() {
            InitializeComponent ();
        }

        //入力画面の「登録する」ボタン
        private void Button_Click(object sender, RoutedEventArgs e) {

        }
        //テキストボックスのフォーカス時に入力欄が空文字もしくはプレースホルダーのテキストであれば空文字を設定し、
        //入力されていればそのテキストのままにする。
        private void TextBox_GotFocus(object sender, RoutedEventArgs e) {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text == "未入力です") {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black; // プレースホルダーが消えた後、通常の文字の色に変更
            }
        }

        //フォーカスアウト時に入力欄が空文字であれば、プレースホルダーの値にし、そうでない場合は、値を保持する
        private void TextBox_LostFocus(object sender, RoutedEventArgs e) {
            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrWhiteSpace ( textBox.Text )) {
                weightValueToday.Text = "未入力です";
                textBox.Foreground = Brushes.Gray; // プレースホルダー時の文字色を変更
            }
        }

        private void Value_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            // 0-9のみ
            e.Handled = !new Regex ( @"[0-9\.]" ).IsMatch ( e.Text );

        }
    }
}
