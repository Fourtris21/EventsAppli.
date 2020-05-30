using Data.Classes;
using Data.Interfaces;
using EventsApp.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EventsApp.ViewModels
{
   public class OrganisationsViewModel
    {
        private readonly IOrganisationRepository _organisationRepository;
     
        public string EntryOrganisationEmail { get; set; }
        public string EntryOrganisationPassword { get; set; }
        public string EntryOrganisationName { get; set; }

        public ICommand RegisterProcedure
        {
            get
            {
                return new Command(async () =>
                {
                    var organisation = new Organisation
                    {
                        OrganisationEmail = EntryOrganisationEmail,
                        OrganisationPassword = EntryOrganisationPassword,
                        OrganisationName = EntryOrganisationName
                    };
                    if (organisation.CheckInformation())
                    {
                        await _organisationRepository.AddOrganisationAsync(organisation);
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            await Application.Current.MainPage.DisplayAlert("", "Successful registration!", "OK");
                        });
                        Application.Current.MainPage = new NavigationPage(new LogInPage(_organisationRepository));
                        
                    }
                    else
                    {
                        Device.BeginInvokeOnMainThread(async () =>
                        { await Application.Current.MainPage.DisplayAlert("", "Empty email, password or name", "Try again"); });

                        Application.Current.MainPage = new Xamarin.Forms.NavigationPage(new RegisterPage(_organisationRepository));
                    }
                });
            }
        }
        public OrganisationsViewModel(IOrganisationRepository organisationRepository)
        {
            _organisationRepository = organisationRepository;
            
        }
    }
}
