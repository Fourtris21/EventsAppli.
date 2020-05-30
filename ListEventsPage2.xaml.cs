using Data.Classes;
using Data.Interfaces;
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
    public partial class ListEventsPage2 : ContentPage
    {
       // public IEventsRepository EventsRepository { get; set; }
        public ListEventsPage2()
        {
            InitializeComponent();
        }
        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var vm = BindingContext as EventsViewModel;
            var ev = e.Item as Event;
            vm.HideOrShowEvent(ev);
        }
    }
}