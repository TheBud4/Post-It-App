using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.Input;
using Post_It_App.Model;
using Post_It_App.Views;

namespace Post_It_App.ViewModels;

public class PostViewModel : ViewModelBase {
    private string? _postDescription;
    private string? _postTitle;

    public PostViewModel(PostItem post) {
        Post = post;
        DeleteCommand = new RelayCommand(OnDelete);
        EditCommand = new AsyncRelayCommand(OpenEditWindow);
        _postDescription = Post.Description;
        _postTitle = Post.Title;
    }

    private PostItem Post { get; }

    public string? Title {
        get => _postTitle;
        set => SetProperty(ref _postTitle, value);
    }

    public string? Description {
        get => _postDescription;
        set => SetProperty(ref _postDescription, value);
    }

    public ICommand DeleteCommand { get; }
    public ICommand EditCommand { get; }

    private void OnDelete() {
        PostDeleted?.Invoke(this, EventArgs.Empty);
    }

    public event EventHandler? PostDeleted;

    private async Task OpenEditWindow() {
        var editWindow = new EditPostWindow();
        if (Title != null && Description != null) {
            var editViewModel = new EditPostViewModel(Title, Description, DeletePost);
            editWindow.DataContext = editViewModel;

            if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
                var result = false;
                editViewModel.RequestClose += r => {
                    result = r;
                    editWindow.Close(result);
                };

                if (desktop.MainWindow != null)
                    await editWindow.ShowDialog<bool>(desktop.MainWindow);

                if (result) {
                    Title = editViewModel.Title;
                    Description = editViewModel.Description;
                }
            }
        }
    }

    private void DeletePost() {
        OnDelete();
    }
}