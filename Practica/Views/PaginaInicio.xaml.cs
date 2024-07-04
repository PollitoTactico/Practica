using Practica.ViewModel;


using Practica.ViewModels;

namespace Practica.Views;

public partial class PaginaInicio : ContentPage
{
    private MainViewModel _viewModel;

    public PaginaInicio()
    {
        InitializeComponent();
        _viewModel = new MainViewModel();
        BindingContext = _viewModel;
        _viewModel.EditCommand = new Command(OpenEditPage, CanExecuteEditCommand);
    }

    private bool CanExecuteEditCommand(object parameter)
    {
        return _viewModel.SelectedPersonaje != null;
    }

    private async void OpenEditPage(object parameter)
    {
        var editPage = new EditPersonaje
        {
            BindingContext = _viewModel.SelectedPersonaje
        };
        await Navigation.PushAsync(editPage);
    }
}
