using Data.Interfaces;
using Data.Classes;
using EventsApp.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EventsApp.ViewModels
{
    public class LogInViewModel 
    {
        private readonly IOrganisationRepository _organisationRepository;
        private readonly IEventsRepository _eventsRepository;
        public string LogInOrganisationEmail { get; set; }
        public string LogInOrganisationPassword { get; set; }
        public ICommand LogInProcedure
        {
            get
            {
                return new Command(async =>
                {
                    var organisation = new Organisation
                    {
                        OrganisationEmail = LogInOrganisationEmail,
                        OrganisationPassword = LogInOrganisationPassword
                    };
                    if (organisation.CheckInformation())
                    {
                        if (_organisationRepository.OrganisationExists(organisation.OrganisationEmail))
                        {
                            if (_organisationRepository.LogIn(organisation).Equals(true))
                            {
                                Application.Current.MainPage = new NavigationPage(new MainPage(_eventsRepository));
                            }
                            else
                            {
                                Device.BeginInvokeOnMainThread(async () =>
                                { await Application.Current.MainPage.DisplayAlert("", "Wrong email or password", "Try again"); });
                                Application.Current.MainPage = new NavigationPage(new LogInPage(_organisationRepository));
                            }
                        }
                    }
                    else
                    {
                        Device.BeginInvokeOnMainThread(async () =>
                        { await Application.Current.MainPage.DisplayAlert("", "Wrong email or password", "Try again"); });
                    }
                });
            }
        }
        public LogInViewModel(IOrganisationRepository organisationRepository)
        {
            _organisationRepository = organisationRepository;
            _eventsRepository = App.EventsRepository;
        }
       
    }
}
