using Post_It_App.Model;

namespace Post_It_App.ViewModels
{
    public class PostViewModel(PostItem post) : ViewModelBase {
        public int Id => post.Id;
        public string? Title => post.Title;
        public string? Description => post.Description;
    }
}