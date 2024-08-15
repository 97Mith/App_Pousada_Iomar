using PousadaIomar.Interfaces;
using PousadaIomar.View;

namespace PousadaIomar;

public partial class App : Application
{
    public App(ICompanyRepository company)
    {
        InitializeComponent();

        MainPage = new NavigationPage(new HomePage(company));
    }
}
