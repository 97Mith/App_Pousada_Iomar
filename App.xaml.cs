using PousadaIomar.View;

namespace PousadaIomar;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new HomePage());
    }
}
