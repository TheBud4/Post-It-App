using Avalonia.Controls;
using Post_It_App.ViewModels;

namespace Post_It_App.Views;
public partial class PostView : UserControl {

    public PostView()
    {
        InitializeComponent();
    }
        
    public PostView(PostViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
