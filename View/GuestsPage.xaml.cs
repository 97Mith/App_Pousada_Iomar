namespace PousadaIomar.View;

public partial class GuestsPage : ContentPage
{
	public GuestsPage()
	{
		InitializeComponent();
	}

    private void AddPerson(object sender, EventArgs e)
    {
		Navigation.PushModalAsync(new NewPerson());
    }

    private void EditPerson(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new EditPerson());
    }
    private void Edit(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new EditPerson());
    }
}