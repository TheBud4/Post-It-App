using Post_It_App.Model;
using Post_It_App.Views;
using System.Diagnostics;



namespace Post_It_App.ViewModels;
public class PostViewModel : PostView {

    private readonly PostItem _post;

    public PostViewModel(PostItem post) {
        _post = post;

        Debug.WriteLine($"Título: {post.Title}, Descrição: {post.Description}");
    }
    public int Id => _post.Id;
    public string Title => _post.Title;

    public string Description => _post.Description;

}
