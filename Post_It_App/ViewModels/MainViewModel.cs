using ReactiveUI;
using System.Reactive.Linq;
using System.Windows.Input;

namespace Post_It_App.ViewModels;

public class MainViewModel : ViewModelBase {

    public MainViewModel() {

        ShowDialog = new Interaction<AddPostViewModel, PostViewModel?>();

        AddPostCommand = ReactiveCommand.CreateFromTask(async () => {

            AddPostViewModel post = new();

            PostViewModel result = await ShowDialog.Handle(post);
        });
    }
    public ICommand AddPostCommand { get; }
    public Interaction<AddPostViewModel, PostViewModel?> ShowDialog { get; set; }
}
