using Post_It_App.Model;

namespace Post_It_App.ViewModels {
    public class PostViewModel(PostItem post) : ViewModelBase {
        public int Id => post.Id;

        public string? Title {
            get => post.Title;
            set => post.Title = value;
        }

        public string? Description {
            get => post.Description;
            set => post.Description = value;
        }
    }
}