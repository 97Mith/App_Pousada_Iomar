using CommunityToolkit.Mvvm.ComponentModel;
using PousadaIomar.Entities;
using PousadaIomar.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace PousadaIomar.ViewModels
{
    public partial class CompanyViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Company> _companies;

        [ObservableProperty]
        private Company _company;

        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DisplayCommand { get; set; }
        public ICommand DisplayByIdCommand { get; set; }
        public ICommand DisplayByNameCommand { get; set; }

        private readonly ICompanyRepository _companyRepository;
        private readonly INavigation _navigation;

        public CompanyViewModel()
        {
            
        }

        public CompanyViewModel(ICompanyRepository companyRepository, INavigation navigation)
        {
            _companyRepository = companyRepository;
            _navigation = navigation;
            Companies = new ObservableCollection<Company>();
            Company = new Company();

            AddCommand = new Command(async () => await AddCompany());
            DeleteCommand = new Command(async () => await DeleteCompany());
            UpdateCommand = new Command(async () => await UpdateCompany());
            DisplayCommand = new Command(async () => await DisplayCompanies());
            DisplayByIdCommand = new Command<int>(async (id) => await DisplayCompanyById(id));
            DisplayByNameCommand = new Command<string>(async (name) => await DisplayCompaniesByName(name));

            LoadCompanies();
        }

        private async Task AddCompany()
        {
            await _companyRepository.InitializeAsync();
            await _companyRepository.AddAsync(Company);
            await Refresh();
            await _navigation.PopModalAsync();
        }

        private async Task DeleteCompany()
        {
            await _companyRepository.InitializeAsync();
            await _companyRepository.DeleteAsync(Company);
            await Refresh();
        }

        private async Task UpdateCompany()
        {
            await _companyRepository.InitializeAsync();
            await _companyRepository.UpdateAsync(Company);
            await Refresh();
        }

        private async Task DisplayCompanies()
        {
            await _companyRepository.InitializeAsync();
            var companies = await _companyRepository.GetAllAsync();
            Companies.Clear();
            foreach (var company in companies)
            {
                Companies.Add(company);
            }
        }

        private async Task DisplayCompanyById(int id)
        {
            await _companyRepository.InitializeAsync();
            Company = await _companyRepository.GetByIdAsync(id);
        }

        private async Task DisplayCompaniesByName(string name)
        {
            await _companyRepository.InitializeAsync();
            var companies = await _companyRepository.GetByNameAsync(name);
            Companies.Clear();
            foreach (var company in companies)
            {
                Companies.Add(company);
            }
        }

        private async Task Refresh()
        {
            await DisplayCompanies();
        }

        private async void LoadCompanies()
        {
            await DisplayCompanies();
        }
    }
}
