using SistemaLicenca.Model;
using System.Diagnostics;

namespace SistemaLicenca.Views;

public partial class main : ContentPage
{
	public main()
	{
		InitializeComponent();
	}

    private async void btnLogin_Clicked(object sender, EventArgs e)
    {
        API obj = new API();

        var result = await obj.AuthenticateAsync(txt_user.Text, txt_pass.Text);
        if (result)
        {
            await DisplayAlert("Sucesso!", $"Bem Vindo {obj.test()}", "Ok");
            App.Current.MainPage = new NavigationPage(new Views.welcome());
        }
        else
        {
            await DisplayAlert("Erro!", "Usuário ou senha incorreta(s)", "Ok");
        }
    }

    private void btnRegister_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new Views.Register());

    }
}