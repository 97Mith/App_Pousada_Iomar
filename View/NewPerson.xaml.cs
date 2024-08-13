namespace PousadaIomar.View;

public partial class NewPerson : ContentPage
{
	public NewPerson()
	{
		InitializeComponent();
	}

    private void BackOnClick(object sender, TappedEventArgs e)
    {
		Navigation.PopModalAsync();
    }
}