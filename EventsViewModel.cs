using Data.Classes;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
 
namespace EventsApp.ViewModels
{
    public class EventsViewModel :  INotifyPropertyChanged
    {
        private readonly IEventsRepository _eventsRepository;
        private IEnumerable<Event> _events;
        public IEnumerable<Event> Events
        {
            get { return _events; }
            set
            {
                _events = value;
                OnPropertyChange();
            }
        }
        public string EventName { get; set; }
        public string EventType { get; set; }
        public string EventDescription { get; set; }
        public string EventCity { get; set; }
        public string EventAddress { get; set; }
        public DateTime EventDateTime { get; set; }
        
        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () => { Events = await _eventsRepository.GetEventsAsync(); });
            }
        }
        public ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var ev = new Event
                    {
                        Name = this.EventName,
                        Description = this.EventDescription,
                        EventType = this.EventType,
                        City = this.EventCity,
                        Address = this.EventAddress,
                        DateTime = this.EventDateTime, 
                        Org = new Organisation(),
                        IsVisible = true,
                    };
                    await _eventsRepository.AddEventAsync(ev);
                });
            }
        }
        public void HideOrShowEvent(Event ev)
        {
            ev.IsVisible = true;
            _eventsRepository.UpdateEventAsync(ev);
        }
        
        public EventsViewModel(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChange([CallerMemberName] string propertyName = null )
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs (propertyName));
        }
    }
}
