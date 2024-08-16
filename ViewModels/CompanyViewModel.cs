using CommunityToolkit.Mvvm.ComponentModel;
using PousadaIomar.Entities;
using PousadaIomar.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace PousadaIomar.ViewModels
{
    public partial class CompanyViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Company> _companies;

        [ObservableProperty]
        private Company _company;

        [ObservableProperty]
        private bool _isRefreshing;

        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DisplayCommand { get; set; }
        public ICommand DisplayByIdCommand { get; set; }
        public ICommand DisplayByNameCommand { get; set; }
        public ICommand RefreshCommand { get; set; }

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
            DeleteCommand = new Command<Company>(async (company) => await DeleteCompany(company));
            UpdateCommand = new Command(async () => await UpdateCompany());
            DisplayCommand = new Command(async () => await DisplayCompanies());
            DisplayByIdCommand = new Command<int>(async (id) => await DisplayCompanyById(id));
            DisplayByNameCommand = new Command<string>(async (name) => await DisplayCompaniesByName(name));
            RefreshCommand = new Command(async () => await Refresh());

            LoadCompanies();
        }

        private async Task AddCompany()
        {
            await _companyRepository.InitializeAsync();
            await _companyRepository.AddAsync(Company);
            await Refresh();
            await _navigation.PopModalAsync();
        }

        private async Task DeleteCompany(Company company)
        {
            await _companyRepository.InitializeAsync();
            await _companyRepository.DeleteAsync(company);
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
            IsRefreshing = true;
            await DisplayCompanies();
            IsRefreshing = false;
        }

        private async void LoadCompanies()
        {
            await DisplayCompanies();
        }
    }
}
