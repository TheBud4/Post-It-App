using Avalonia.Controls;
using Post_It_App.ViewModels;

namespace Post_It_App.Views;

public partial class AddPostWindow : Window {
    public AddPostWindow() {
        InitializeComponent();
        DataContext = new AddPostViewModel();
    }
}