using PousadaIomar.Interfaces;
using PousadaIomar.ViewModels;

namespace PousadaIomar.View;

public partial class CompaniesPage : ContentPage
{
    private readonly ICompanyRepository _companyRepository;

    public CompaniesPage(ICompanyRepository company)
	{
		InitializeComponent();
        _companyRepository = company;
        BindingContext = new CompanyViewModel(_companyRepository, Navigation);
    }

    private void AddCompany(object sender, EventArgs e)
    {
		Navigation.PushModalAsync(new NewCompany(_companyRepository));
    }

    private void EditCompany(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new EditCompany());
    }
}