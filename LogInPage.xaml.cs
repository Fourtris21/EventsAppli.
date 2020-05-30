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
    public partial class LogInPage : ContentPage
    {
       
        public LogInPage(IOrganisationRepository organisationRepository)
        {
            InitializeComponent();
            BindingContext = new LogInViewModel(organisationRepository);
        }

      

      
    }
}