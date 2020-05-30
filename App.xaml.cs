using Data.Interfaces;
using EventsApp.Pages;
using EventsApp.ViewModels;
using System;
using System.Diagnostics.Tracing;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventsApp
{
    public partial class App : Application
    {
        public static IEventsRepository EventsRepository;
        public static IOrganisationRepository OrganisationRepository;

        public App(IEventsRepository eventsRepository, IOrganisationRepository organisationRepository)
        { 
            InitializeComponent();
            EventsRepository = eventsRepository;
            OrganisationRepository = organisationRepository;

            MainPage = new NavigationPage(new RegisterPage(organisationRepository))
            {
                BindingContext = new OrganisationsViewModel(organisationRepository)
            };
        }

    
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
