namespace PousadaIomar.View;

public partial class NewCompany : ContentPage
{
	public NewCompany()
	{
		InitializeComponent();
	}

    private void BackOnClick(object sender, TappedEventArgs e)
    {
		Navigation.PopModalAsync();
    }
}