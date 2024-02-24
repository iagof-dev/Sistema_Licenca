namespace SistemaLicenca.Views;

public partial class Register : ContentPage
{
	public Register()
	{
		InitializeComponent();
	}

    private void btnRegister_Clicked(object sender, EventArgs e)
    {

    }

    private void btnVoltar_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new Views.main();
    }
}