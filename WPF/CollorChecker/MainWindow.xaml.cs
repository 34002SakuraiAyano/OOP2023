using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
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
            //var color = makeColor.Color;
            //var name = makeColor.Name;


        }


        //ストックボタン
        private void stockButton_Click(object sender, RoutedEventArgs e) {

            //stockList.Items.Add ( rValue.Text );
            //stockList.Items.Add ( gValue.Text );
            //stockList.Items.Add ( bValue.Text );
            stockList.Items.Insert( 0,makeColor);

        }


        //スライダーで色変換
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            makeColor = new MyColor {
                Color = Color.FromRgb ( (byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value ),
                Name = Name,
            };          
            var brush = new System.Windows.Media.SolidColorBrush ( makeColor.Color );
            colorArea.Background = brush;
        }
    }

    //色と色名セット
    public class MyColor {
        public Color Color { get; set; }
        public string Name { get; set; }
        public override string ToString() {
            return "R: " + Color.R + "G: " + Color.G + "B: " + Color.B;
        }
    }
}
