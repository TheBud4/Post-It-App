using DynamicData.Binding;
using Post_It_App.Model;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Reactive.Linq;
using System.Threading.Channels;
using System.Windows.Input;

namespace Post_It_App.ViewModels;

public class MainViewModel : ViewModelBase {

    public MainViewModel() {

        ShowDialog = new Interaction<AddPostViewModel, PostViewModel?>();

        AddPostCommand = ReactiveCommand.CreateFromTask(async () => {

            AddPostViewModel post = new();

            PostViewModel result = await ShowDialog.Handle(post);
        });

        this.WhenAnyValue(x => x.SearchText).Subscribe(DoSearch!);

    }
    public ICommand AddPostCommand { get; }
    public Interaction<AddPostViewModel, PostViewModel?> ShowDialog { get; }

    //Search

    private PostViewModel? _selectedPost;

    public ObservableCollection<PostViewModel> SearchResults { get; } = new();

    private string? _searchText;

    public string? SearchText {
        get => _searchText;
        set => this.RaiseAndSetIfChanged(ref _searchText, value);
    }

    public PostViewModel? SelectedPost {
        get => _selectedPost;
        set => this.RaiseAndSetIfChanged(ref _selectedPost, value);
    }

    private void DoSearch(string? input) {

        SearchResults.Clear();


        if (!string.IsNullOrWhiteSpace(input)) {
            var posts = PostManager.Instance.SearchPostsReturn(input);

            foreach (var post in posts) {
                var vm = new PostViewModel(post);
                SearchResults.Add(vm);
            }
        } else {
            var posts = PostManager.Instance.GetAllPosts();

            foreach (var post in posts) {
                var vm = new PostViewModel(post);
                SearchResults.Add(vm);
            }
        }

    }


}
