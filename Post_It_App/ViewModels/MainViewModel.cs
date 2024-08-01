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
    private string? _searchText;
    private readonly List<PostViewModel> allPosts;

    public MainViewModel() {
        OpenAddPostWindowCommand = new AsyncRelayCommand(OpenAddPostWindow);


        //ToDo: Remover os posts de exemplo antes de publicar
        //allPosts = new List<PostViewModel>();
        allPosts = new List<PostViewModel> {
            new(new PostItem("Titulo Muito grande vai passar da borda", "Descrição do Post")),
            new(new PostItem("Post", "Descrição muito grande do Post vai passar da borda")),
            new(new PostItem("Post", "Descrição do Post")),
            new(new PostItem("Post", "Descrição do Post")),
            new(new PostItem("Post", "Descrição do Post")),
            new(new PostItem("Post", "Descrição do Post")),
            new(new PostItem("Post", "Descrição do Post")),
            new(new PostItem("Post", "Descrição do Post")),
            new(new PostItem("Post", "Descrição do Post")),
            new(new PostItem("Post", "Descrição do Post")),
            new(new PostItem("Post", "Descrição do Post")),
            new(new PostItem("Post", "Descrição do Post")),
            new(new PostItem("Post", "Descrição do Post")),
            new(new PostItem("Post", "Descrição do Post")),
            new(new PostItem("Post", "Descrição do Post"))
        };

        Posts = new ObservableCollection<PostViewModel>(allPosts);
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
        var addPostWindow = new AddPostView();
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

            // Mostrar o diálogo
            await addPostWindow.ShowDialog<bool>(desktop.MainWindow);

            if (result) AddPost(newPost);
        }
    }

    private void AddPost(PostItem post) {
        var postViewModel = new PostViewModel(post);
        allPosts.Add(postViewModel);
        Posts.Add(postViewModel);
    }

    // Pesquisa de posts
    private void SearchPosts(string? searchTerm) {
        Posts.Clear();

        if (string.IsNullOrWhiteSpace(searchTerm))
            foreach (var post in allPosts)
                Posts.Add(post);
        else
            foreach (var post in allPosts.Where(p =>
                         (p.Title?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false) ||
                         (p.Description?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false)))
                Posts.Add(post);
    }
    // Pesquisa de posts

    //Deletar post

    public ICommand RemovePostCommand { get; }

    private void RemovePost(PostViewModel postViewModel) {
        Posts.Remove(postViewModel);
    }
}