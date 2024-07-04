using Practica.Models;
using Practica.ViewModels;

namespace Practica.Views;
    public partial class EditPersonaje : ContentPage
    {
    private Personaje _personaje;

    public EditPersonaje()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _personaje = BindingContext as Personaje;
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        var mainViewModel = Application.Current.MainPage.BindingContext as MainViewModel;
        if (mainViewModel != null)
        {
            mainViewModel.SavePersonajeCommand.Execute(_personaje);
        }
        await Navigation.PopAsync();
    }
}
