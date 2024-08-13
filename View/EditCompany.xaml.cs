namespace PousadaIomar.View;

public partial class EditCompany : ContentPage
{
	public EditCompany()
	{
		InitializeComponent();
	}

    private void BackOnClick(object sender, TappedEventArgs e)
    {
		Navigation.PopModalAsync();
    }
}