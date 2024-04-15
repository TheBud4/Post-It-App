using Avalonia.ReactiveUI;
using Post_It_App.Model;
using Post_It_App.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace Post_It_App.Views;

public partial class MainWindow : ReactiveWindow<MainViewModel> {
    public MainWindow() {
        InitializeComponent();

        this.WhenActivated(action =>
            action(ViewModel!.ShowDialog.RegisterHandler(DoShowDialogAsync)));
    }

    private async Task DoShowDialogAsync(InteractionContext<AddPostViewModel, PostViewModel?> interaction) {

        AddPostView dialog = new();
        dialog.DataContext = interaction.Input;


        PostViewModel? result = await dialog.ShowDialog<PostViewModel?>(this);
        interaction.SetOutput(result);
    }
}
