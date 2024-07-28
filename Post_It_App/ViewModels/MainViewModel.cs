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

    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<PostViewModel> Posts { get; set; }

        public MainViewModel()
        {
            OpenAddPostWindowCommand = new AsyncRelayCommand(OpenAddPostWindow);
            Posts = [];
        }

        public ICommand OpenAddPostWindowCommand { get; }

        private async Task OpenAddPostWindow()
        {
            var addPostWindow = new AddPostView();
            var addPostViewModel = new AddPostViewModel();
            addPostWindow.DataContext = addPostViewModel;

            if (Application.Current!.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
                bool result = false;
                PostItem newPost = null;
                
                addPostViewModel.RequestClose += post => {
                    newPost = post;
                    result = true;
                    addPostWindow.Close(result);
                };

                // Showing the dialog
                await addPostWindow.ShowDialog<bool>(desktop.MainWindow);

                if (result && newPost != null)
                {
                    AddPost(newPost);
                }
            }
        }

        // Adiciona um post na lista de posts
        private void AddPost(PostItem post)
        {
            Posts.Add(new PostViewModel(post));
        }
        
        //Atualiza um post
        public void UpdatePost(int id, string? title, string? description) {
            var post = Posts.FirstOrDefault(p => p.Id == id);
            if (post == null) return;
            //ToDo: Implementar a atualização do post
            
        }
        
        //Deleta um post
        public void DeletePost(int id) {
            var post = Posts.FirstOrDefault(p => p.Id == id);
            if (post != null) {
                Posts.Remove(post);
            }
        }
        // Busca posts na lista
        // ToDo: Implementar a busca de posts
        // public PostItem? GetPostById(int id) {
        //     return _posts.FirstOrDefault(p => p != null && p.Id == id);
        // }
        //
        // public List<PostItem?> SearchPostsReturn(string searchTerm) {
        //     return _posts.FindAll(p => p?.Description != null && p is { Title: not null } && (p.Title.Contains(searchTerm) || p.Description.Contains(searchTerm)));
        // }
        
    }
