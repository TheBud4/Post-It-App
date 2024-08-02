using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Post_It_App.Model;

namespace Post_It_App.ViewModels;

public class AddPostViewModel : ViewModelBase {
    private string? _description;
    private string? _title;

    public AddPostViewModel() {
        SaveCommand = new RelayCommand(Save);
    }

    public string? Title {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    public string? Description {
        get => _description;
        set => SetProperty(ref _description, value);
    }

    public ICommand SaveCommand { get; }

    private void Save() {
        // Lógica para criar um novo post
        var newPost = new PostItem(Title, Description);

        // Resetar os campos após salvar
        Title = string.Empty;
        Description = string.Empty;

        // Encerra o diálogo e retorna o post criado
        CloseDialog(newPost);
    }

    // Método para fechar o diálogo e retornar o resultado
    public event Action<PostItem>? RequestClose;

    private void CloseDialog(PostItem post) {
        RequestClose?.Invoke(post);
    }
}