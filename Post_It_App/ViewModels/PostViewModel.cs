using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Post_It_App.Model;

namespace Post_It_App.ViewModels {
    public class PostViewModel : ViewModelBase {
        public PostItem Post { get; }

        public PostViewModel(PostItem post) {
            Post = post;
            DeleteCommand = new RelayCommand(OnDelete);
        }

        public string? Title {
            get => Post.Title;
            set => Post.Title = value;
        }

        public string? Description {
            get => Post.Description;
            set => Post.Description = value;
        }

        public ICommand DeleteCommand { get; }

        private void OnDelete() {
            PostDeleted?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler? PostDeleted;
    }
}