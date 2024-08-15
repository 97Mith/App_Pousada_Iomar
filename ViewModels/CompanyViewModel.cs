using CommunityToolkit.Mvvm.ComponentModel;
using PousadaIomar.Entities;
using PousadaIomar.Interfaces;
using System.Windows.Input;

namespace PousadaIomar.ViewModels;

public partial class CompanyViewModel : ObservableObject
{
    [ObservableProperty]
    private List<Company> _companies;

    [ObservableProperty]
    private Company _company;

    public ICommand AddCommand { get; set; }
    public ICommand DeleteCommand { get; set; }
    public ICommand UpdateCommand { get; set; }
    public ICommand DisplayCommand { get; set; }
    public ICommand DisplayByIdCommand { get; set; }
    public ICommand DisplayByNameCommand { get; set; }

    public CompanyViewModel(ICompanyRepository companyRepository)
    {
        Company = new Company();

        AddCommand = new Command(async () => await AddCompany(companyRepository));
        DeleteCommand = new Command(async () => await DeleteCompany(companyRepository));
        UpdateCommand = new Command(async () => await UpdateCompany(companyRepository));
        DisplayCommand = new Command(async () => await DisplayCompanies(companyRepository));
        DisplayByIdCommand = new Command<int>(async (id) => await DisplayCompanyById(companyRepository, id));
        DisplayByNameCommand = new Command<string>(async (name) => await DisplayCompaniesByName(companyRepository, name));
    }

    private async Task AddCompany(ICompanyRepository companyRepository)
    {
        await companyRepository.InitializeAsync();
        await companyRepository.AddAsync(Company);
        await Refresh(companyRepository);
    }

    private async Task DeleteCompany(ICompanyRepository companyRepository)
    {
        await companyRepository.InitializeAsync();
        await companyRepository.DeleteAsync(Company);
        await Refresh(companyRepository);
    }

    private async Task UpdateCompany(ICompanyRepository companyRepository)
    {
        await companyRepository.InitializeAsync();
        await companyRepository.UpdateAsync(Company);
        await Refresh(companyRepository);
    }

    private async Task DisplayCompanies(ICompanyRepository companyRepository)
    {
        await companyRepository.InitializeAsync();
        Companies = await companyRepository.GetAllAsync();
    }

    private async Task DisplayCompanyById(ICompanyRepository companyRepository, int id)
    {
        await companyRepository.InitializeAsync();
        Company = await companyRepository.GetByIdAsync(id);
    }

    private async Task DisplayCompaniesByName(ICompanyRepository companyRepository, string name)
    {
        await companyRepository.InitializeAsync();
        Companies = await companyRepository.GetByNameAsync(name);
    }

    private async Task Refresh(ICompanyRepository companyRepository)
    {
        Companies = await companyRepository.GetAllAsync();
    }
}

