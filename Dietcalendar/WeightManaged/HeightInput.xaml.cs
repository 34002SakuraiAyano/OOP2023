using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace WeightManaged {
    /// <summary>
    /// HeightInput.xaml の相互作用ロジック
    /// </summary>
    public partial class HeightInput : Window {
        private string defaultText = "000.0";


        public HeightInput() {
            InitializeComponent ();
            DataGridName.ItemsSource = new ObservableCollection<DataGridItems> {
                new DataGridItems { BMI="18.5未満",Obesity  ="低体重" },
                new DataGridItems { BMI="18.5～25未満",Obesity  ="普通体重" },
                new DataGridItems { BMI="25～30未満", Obesity = "肥満度１" },
                new DataGridItems { BMI="35～35未満", Obesity = "肥満度２" },
                new DataGridItems { BMI="35～40未満",Obesity = "肥満度３" },
                new DataGridItems { BMI="40以上", Obesity = "肥満度４" },
            };
            DataGridName.IsReadOnly = true;
          // DataGridName.AllowUserToResizeRows = false;
            heightValue.Text = defaultText;

            properWeightLabel.Content = "あなたの適正体重は、、、";

        }


        //テキストボックスのフォーカス時に入力欄が空文字もしくはプレースホルダーのテキストであれば空文字を設定し、
        //入力されていればそのテキストのままにする。
        private void TextBox_GotFocus(object sender, RoutedEventArgs e) {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text == "000.0" || textBox.Text == "00.0" || textBox.Text == "00") {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black; // プレースホルダーが消えた後、通常の文字の色に変更
            }
        }

        //フォーカスアウト時に入力欄が空文字であれば、プレースホルダーの値にし、そうでない場合は、値を保持する
        private void TextBox_LostFocus(object sender, RoutedEventArgs e) {
            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrWhiteSpace ( textBox.Text )) {
                heightValue.Text = "000.0";
                weightValue.Text = "00.0";
                ageValue.Text = "00";
                textBox.Foreground = Brushes.Gray; // プレースホルダー時の文字色を変更
            }
        }



        //TextBox数字のみ
        private void Value_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            // 0-9のみ
            e.Handled = !new Regex ( @"[0-9\.]" ).IsMatch ( e.Text );
        }

        private void Value_PreviewExecuted(object sender, ExecutedRoutedEventArgs e) {
            // 貼り付けを許可しない
            if (e.Command == ApplicationCommands.Paste) {
                e.Handled = true;
            }
        }

        //計算ボタン
        private void calcButton_Click(object sender, RoutedEventArgs e) {
            //BMI値
            double bmi;
            bmi = double.Parse ( weightValue.Text ) / Math.Pow ( double.Parse ( heightValue.Text ) * 0.01, 2 );
            BMITextBox.Text = Math.Round ( bmi, 1 ).ToString ();

            //基礎代謝量
            double bmr;
            if (manRadioButton.IsChecked == true) {
                bmr = 88.362 + (13.397 * double.Parse ( weightValue.Text )) + (4.799 * double.Parse ( heightValue.Text )) - (5.677 * int.Parse ( ageValue.Text ));
            }
            else {
                bmr = 447.593 + (9.247 * double.Parse ( weightValue.Text )) + (3.098 * double.Parse ( heightValue.Text )) - (4.330 * int.Parse ( ageValue.Text ));
            }
            metabolismTextBox.Text = Math.Round ( bmr ).ToString () + "kcal";

            //データグリッド表
            double[] bmiBase = { 18.5, 25, 30, 35, 40, 100 };
            for (int i = 0; i < bmiBase.Length; i++) {
                if (bmi < bmiBase[i]) {
                    DataGridName.SelectedIndex = i;              
                    break;
                }
            }

          //適正体重
            var proper = Math.Pow ( double.Parse ( heightValue.Text ) * 0.01, 2 ) * 22;
            string symbol=  (proper > double.Parse ( weightValue.Text )) ? "+" : "";
            properWeightLabel.Content = "あなたの身長で標準の体重は、\n" + Math.Round ( proper, 1 ).ToString () 
                + "kgです。\n標準体重まで" + symbol + (proper- double.Parse ( weightValue.Text )) +"kgです。";
        }


        //リセットボタン(初期値)
        private void resetButton_Click(object sender, RoutedEventArgs e) {
            BMITextBox.Text = "";
            metabolismTextBox.Text = "0kcal";

            if (!string.IsNullOrWhiteSpace ( heightValue.Text )) {
                heightValue.Text = "000.0";
                heightValue.Foreground = Brushes.Gray; // プレースホルダー時の文字色を変更
            }
            if (!string.IsNullOrWhiteSpace ( weightValue.Text )) {
                weightValue.Text = "00.0";
                weightValue.Foreground = Brushes.Gray; // プレースホルダー時の文字色を変更
            }
            if (!string.IsNullOrWhiteSpace ( ageValue.Text )) {
                ageValue.Text = "00";
                ageValue.Foreground = Brushes.Gray; // プレースホルダー時の文字色を変更
            }

            properWeightLabel.Content = "あなたの標準体重は、、、";          
            manRadioButton.IsChecked = false;
            womanRadioButton.IsChecked = false;
        }

        //ウォーターマーカー
        private void OnTextBoxTextChanged(object sender, TextChangedEventArgs e) {
            if (sender is TextBox box) {
                if (string.IsNullOrEmpty ( box.Text ))
                    box.Background = (ImageBrush)FindResource ( "watermark" );
                else
                    box.Background = null;
            }
        }

        //完了ボタン
        private void CompleteButton_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        //リンククリック→BMIの増減に関するもの
        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e) {
            System.Diagnostics.Process.Start ( new System.Diagnostics.ProcessStartInfo ( e.Uri.AbsoluteUri ) );
            e.Handled = true;
        }
    }

    public class DataGridItems {
        public string BMI { get; set; } //BMI値
        public string Obesity { get; set; } //肥満度
    }

}



