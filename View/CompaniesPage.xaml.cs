namespace PousadaIomar.View;

public partial class CompaniesPage : ContentPage
{
	public CompaniesPage()
	{
		InitializeComponent();
	}

    private void AddCompany(object sender, EventArgs e)
    {
		Navigation.PushModalAsync(new NewCompany());
    }

    private void EditCompany(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new EditCompany());
    }
}