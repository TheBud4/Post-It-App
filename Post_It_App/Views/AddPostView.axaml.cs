using Avalonia.Controls;
using Avalonia.ReactiveUI;
using Post_It_App.ViewModels;

namespace Post_It_App.Views;
public partial class AddPostView : ReactiveWindow<AddPostViewModel> {
    public AddPostView() {
        InitializeComponent();
    }


    private void SavePost(object? sender, Avalonia.Interactivity.RoutedEventArgs e) {
        Close();
    }
}
