using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WeightManaged.ViewModels {
    public class ViewModelBase : INotifyPropertyChanged {
        // INotifyPropertyChanged を実装するためのイベントハンドラ
        public event PropertyChangedEventHandler PropertyChanged;

        // プロパティ名によって自動的にセットされる
        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke ( this, new PropertyChangedEventArgs ( propertyName ) );
    }
}