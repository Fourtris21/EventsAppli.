using Data.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// интерфейсът имплементиrа методи в EventsRepository, извършващи CRUD операции
/// </summary>
namespace Data.Interfaces
{
    public interface IEventsRepository
    {
        Task<IEnumerable<Event>> GetEventsAsync();
        Task<Event> GetEventById(int id);
        Task<bool> AddEventAsync(Event ev);
        Task<bool> UpdateEventAsync(Event ev);
        Task<bool> RemoveEventByIdAsync(int id);
        IEnumerable<Event> QueryEvent(Func<Event, bool> predicate);
    }
}
