using PousadaIomar.Interfaces;
using PousadaIomar.ViewModels;

namespace PousadaIomar.View;

public partial class HomePage : TabbedPage
{
    private readonly ICompanyRepository _companyRepository;
	public HomePage(ICompanyRepository company)
	{
		InitializeComponent();
        _companyRepository = company;
        BindingContext = new CompanyViewModel(_companyRepository, Navigation);

		var page1 = new AccomodationPage()
		{
			Title = "Acomoda��es",
			IconImageSource = "bedicon.svg"
		};

		var page2 = new GuestsPage()
        {
            Title = "H�spedes",
            IconImageSource = "personicon.svg"
        };

        var page3 = new CompaniesPage(_companyRepository)
        {
            Title = "Empresas",
            IconImageSource = "companyicon.svg"
        };

        var page4 = new FinancesPage()
        {
            Title = "Finan�as",
            IconImageSource = "financeicon.svg"
        };

        this.Children.Add(page1);
        this.Children.Add(page2);
        this.Children.Add(page3);
        this.Children.Add(page4);

    }
}