using Avalonia.Controls;
using Avalonia.Interactivity;
using Post_It_App.Model;
using System;
using System.Diagnostics;

namespace Post_It_App.Views {
    public partial class AddPostView : Window {
        public AddPostView() {
            InitializeComponent();
        }

        private void SavePost(object? sender, RoutedEventArgs e) {

            PostItem? post = new(Name.Text, Description.Text);

            PostManager.Instance.AddPost(post);

            foreach (var a in PostManager.Instance.GetAllPosts()) {
                Debug.WriteLine($"Título: {a.Title}, Descrição: {a.Description}");
            }

            Close();
        }
    }
}
