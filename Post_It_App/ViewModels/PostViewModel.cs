using Post_It_App.Model;
using Post_It_App.Views;

namespace Post_It_App.ViewModels;
public class PostViewModel : PostView {

    private readonly PostItem _post;
    public PostViewModel(PostItem post) {
        _post = post;
    }

    public string Title => _post.Title;

    public string Description => _post.Description;
}
