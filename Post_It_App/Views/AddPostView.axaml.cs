using Avalonia.Controls;
using Post_It_App.ViewModels;

namespace Post_It_App.Views {
    public partial class AddPostView : Window {
        public AddPostView() {
            InitializeComponent();
            DataContext = new AddPostViewModel();
        }
    }
}
