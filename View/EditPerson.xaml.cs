namespace PousadaIomar.View;

public partial class EditPerson : ContentPage
{
	public EditPerson()
	{
		InitializeComponent();
	}

    private void BackOnClick(object sender, TappedEventArgs e)
    {
		Navigation.PopModalAsync();
    }
}