using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace CollorChecker {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        MyColor makeColor;
        string ColorName = "";

        public MainWindow() {
            InitializeComponent ();
            DataContext = GetColorList ();

        }


        //コンボボックス
        private MyColor[] GetColorList() {
            return typeof ( Colors ).GetProperties ( BindingFlags.Public | BindingFlags.Static )
             .Select ( i => new MyColor () { Color = (Color)i.GetValue ( null ), Name = i.Name } ).ToArray ();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            makeColor = (MyColor)((ComboBox)sender).SelectedItem;

            //色クリックで背景変わる
            if (makeColor != null) {
                var brush = new System.Windows.Media.SolidColorBrush ( makeColor.Color );
                colorArea.Background = brush;

                ColorName = makeColor.Name;

                //色クリックでスライダーの位置変える
                rSlider.Value = makeColor.Color.R;
                gSlider.Value = ((MyColor)((ComboBox)sender).SelectedItem).Color.G;
                bSlider.Value = ((MyColor)((ComboBox)sender).SelectedItem).Color.B;
            }
        }

        //ストックボタン
        private void stockButton_Click(object sender, RoutedEventArgs e) {
            MyColor[] ColorNames = GetColorList ();  //&&がかつ.||がまたは
            //string names = " ";
            foreach (var item in ColorNames) {
                if (item.Color.R == rSlider.Value && item.Color.G == gSlider.Value && item.Color.B == bSlider.Value) {
                    makeColor = item;
                    //makeColor = item;
                    //makeColor.Name = item.Name;
                    //// stockList.Items.Insert ( 0, item.Name );
                    break;
                }else {
                    makeColor = new MyColor {
                        Color = Color.FromRgb ( (byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value ),
                        Name = "",
                    };
                }
            }
            if (makeColor.Name == "") {
                stockList.Items.Insert ( 0, makeColor.ToString() );
            }else {
                stockList.Items.Insert ( 0, makeColor.Name );
            }

            //rValue.Text = "0";
            //gValue.Text = "0";
            //bValue.Text = "0";
        }

        //スライダーで色変換
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            makeColor = new MyColor {
                Color = Color.FromRgb ( (byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value ),
                Name = "",
            };         
            var brush = new System.Windows.Media.SolidColorBrush ( makeColor.Color );
            colorArea.Background = brush;
        }

        private void stockList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            MyColor[] ColorNames = GetColorList ();  //&&がかつ.||がまたは
            byte r,g,b;
            if (Regex.IsMatch ( (string)stockList.SelectedItem, @"^[a-zA-Z]+$" )) {
                foreach (var item in ColorNames) {
                    if (item.Name == (string)stockList.SelectedItem) {
                        r = item.Color.R;
                        g = item.Color.G;
                        b = item.Color.B;

                        rSlider.Value = r;
                        gSlider.Value = g;
                        bSlider.Value = b;

                        break;
                    }
                }
            }else {
                string[] box = stockList.SelectedItem.ToString ().Split (' ',':');

                rValue.Text = box[2];
                gValue.Text = box[4];
                bValue.Text = box[6];
            }
        }
    }

    //色と色名セット
    public class MyColor {
        public Color Color { get; set; }
        public string Name { get; set; }
        public override string ToString() {
            return "R: " + Color.R + " G:" + Color.G + " B:" + Color.B;
        }
    }
}
