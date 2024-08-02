using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace Post_It_App.ViewModels;

public class EditPostViewModel : ViewModelBase {
    private string _title;
    private string _description;
    private readonly Action _onDelete;

    public EditPostViewModel(string title, string description, Action onDelete) {
        Title = title;
        _description = description;
        _title = title;
        Description = description;
        _onDelete = onDelete;
        SaveCommand = new RelayCommand(Save);
        DeleteCommand = new RelayCommand(Delete);
    }

    public string Title {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    public string Description {
        get => _description;
        set => SetProperty(ref _description, value);
    }

    public ICommand SaveCommand { get; }
    public ICommand DeleteCommand { get; }

    public event Action<bool>? RequestClose;

    private void Save() {
        RequestClose?.Invoke(true);
    }

    private void Delete() {
        _onDelete?.Invoke();
        RequestClose?.Invoke(false);
    }
}