using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.Input;
using Post_It_App.Model;
using Post_It_App.Views;

namespace Post_It_App.ViewModels;

public class MainViewModel : ViewModelBase {
    private readonly List<PostViewModel> _allPosts;
    private string? _searchText;

    public MainViewModel() {
        OpenAddPostWindowCommand = new AsyncRelayCommand(OpenAddPostWindow);

        _allPosts = new List<PostViewModel>();

        Posts = new ObservableCollection<PostViewModel>(_allPosts);

        foreach (var postViewModel in Posts) postViewModel.PostDeleted += OnPostDeleted;
    }

    public ObservableCollection<PostViewModel> Posts { get; set; }

    public string? SearchText {
        get => _searchText;
        set {
            SetProperty(ref _searchText, value);
            SearchPosts(_searchText);
        }
    }

    public ICommand OpenAddPostWindowCommand { get; }

    private async Task OpenAddPostWindow() {
        var addPostWindow = new AddPostWindow();
        var addPostViewModel = new AddPostViewModel();

        addPostWindow.DataContext = addPostViewModel;

        if (Application.Current!.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
            var result = false;
            PostItem newPost = null!;

            addPostViewModel.RequestClose += post => {
                newPost = post;
                result = true;
                addPostWindow.Close(result);
            };

            await addPostWindow.ShowDialog<bool>(desktop.MainWindow!);

            if (result) AddPost(newPost);
        }
    }

    private void AddPost(PostItem post) {
        var postViewModel = new PostViewModel(post);
        postViewModel.PostDeleted += OnPostDeleted;
        _allPosts.Add(postViewModel);
        Posts.Add(postViewModel);
    }

    private void OnPostDeleted(object? sender, EventArgs e) {
        if (sender is PostViewModel postViewModel) {
            Posts.Remove(postViewModel);
            _allPosts.Remove(postViewModel);
        }
    }

    private void SearchPosts(string? searchTerm) {
        Posts.Clear();

        if (string.IsNullOrWhiteSpace(searchTerm))
            foreach (var post in _allPosts)
                Posts.Add(post);
        else
            foreach (var post in _allPosts.Where(p =>
                         (p.Title?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false) ||
                         (p.Description?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false)))
                Posts.Add(post);
    }
}