using Avalonia.Controls;
using Avalonia.Interactivity;
using Post_It_App.Model;
using System.Diagnostics;

namespace Post_It_App.Views;
public partial class AddPostView : Window {

    public PostManager manager = new();
    public AddPostView() {
        InitializeComponent();
    }


    private void SavePost(object? sender, RoutedEventArgs e) {

        PostItem? post = new(Name.Text, Description.Text);
        Debug.WriteLine("Post adicionado: " + post.Title + post.Description);
        Close();
    }
}
