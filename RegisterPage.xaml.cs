using Data.Interfaces;
using Data.Repositories;
using EventsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventsApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public IOrganisationRepository OrganisationRepository { get; private set; }
   
        public RegisterPage(IOrganisationRepository organisationRepository)
        {
            InitializeComponent();
            OrganisationRepository = organisationRepository;
            BindingContext = new OrganisationsViewModel(organisationRepository);
        }
        async void NavigateToLogIn(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LogInPage(OrganisationRepository));
        }
    }
}