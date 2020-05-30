using Data.Interfaces;
using EventsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventsApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public IEventsRepository EventsRepository { get; private set; }
        public Page1()
        {
            InitializeComponent();
        }
       
        public Page1(IEventsRepository eventsRepository)
        {
            InitializeComponent();
            EventsRepository = eventsRepository;
            BindingContext = new EventsViewModel(eventsRepository);
        }

    }
}