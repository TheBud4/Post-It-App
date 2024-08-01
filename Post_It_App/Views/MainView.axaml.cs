using Avalonia.Controls;
using Post_It_App.ViewModels;

namespace Post_It_App.Views;

public partial class MainView : UserControl {
    public MainView() {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}