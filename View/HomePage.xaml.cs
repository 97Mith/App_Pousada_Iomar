namespace PousadaIomar.View;

public partial class HomePage : TabbedPage
{
	public HomePage()
	{
		InitializeComponent();

		var page1 = new AccomodationPage()
		{
			Title = "Acomodações",
			IconImageSource = "bedicon.svg"
		};

		var page2 = new GuestsPage()
        {
            Title = "Hóspedes",
            IconImageSource = "personicon.svg"
        };

        var page3 = new CompaniesPage()
        {
            Title = "Empresas",
            IconImageSource = "companyicon.svg"
        };

        var page4 = new FinancesPage()
        {
            Title = "Finanças",
            IconImageSource = "financeicon.svg"
        };

        this.Children.Add(page1);
        this.Children.Add(page2);
        this.Children.Add(page3);
        this.Children.Add(page4);

    }
}