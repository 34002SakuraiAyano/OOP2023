using WeightManaged.Command;
using WeightManaged.ViewModels;

namespace WeightManaged.ViewModels {
    public class MainViewModel : ViewModelBase {
        private ViewModelBase activeView = new InputModel ();

        //画面に表示するUserControlのViewModelを設定するプロパティ
        public ViewModelBase ActiveView {
            get { return activeView; }
            set {
                if (activeView != value) {
                    activeView = value;
                    OnPropertyChanged ( "ActiveView" );
                }
            }
        }

        //ボタンのコマンドプロパティ
        public DelegateCommand<string> ScreenTransitionCommand { get; }

        //コンストラクタ
        public MainViewModel() {
            ScreenTransitionCommand = new DelegateCommand<string> ( screenTransitionExcute );
        }

        //ボタンのコマンド実行メソッド
        private void screenTransitionExcute(string param) {
            //コマンドのパラメーターによって
            //ActiveViewにセットするViewModelを切り替える

            switch (param) {
                case "Input":
                    ActiveView = new InputModel ();
                    break;
                case "Calendar":
                    ActiveView = new CalendarModel ();
                    break;
                case "Graph":
                    ActiveView = new GraphModel ();
                    break;
                case "Recommend":
                    ActiveView = new RecommendModel ();
                    break;
                case "Setting":
                    ActiveView = new SetModel ();
                    break;
            }
        }
    }
}