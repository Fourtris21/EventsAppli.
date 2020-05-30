using Data.Interfaces;
using EventsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EventsApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : Shell
    {
       // public IEventsRepository EventsRepository { get; private set; }
        public MainPage()
        {
            InitializeComponent();
        }
        public MainPage(IEventsRepository eventsRepository)
        {
            InitializeComponent();
           // EventsRepository = eventsRepository;
            BindingContext = new EventsViewModel(eventsRepository);
        }
    }
}
