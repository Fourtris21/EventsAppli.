using Data;
using Data.Classes;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 
/// </summary>
namespace Data.Repositories
{
    public class EventsRepository : IEventsRepository
    {
        private readonly DatabaseContext _databaseContext;
        public EventsRepository(string dbPath)
        {
            _databaseContext = new DatabaseContext(dbPath);
        }
        public async Task<bool> AddEventAsync(Event ev)
        {
            try
            {
                var add = await _databaseContext.Events.AddAsync(ev);
                await _databaseContext.SaveChangesAsync();
                var state = add.State == EntityState.Added;
                return state;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<Event> GetEventById(int id)
        {
            try
            {
                var ev = await _databaseContext.Events.FindAsync(id);
                return ev;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Event>> GetEventsAsync()
        {
            try
            {
                var events = await _databaseContext.Events.ToListAsync();
                return events;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<Event> QueryEvent(Func<Event, bool> predicate)
        {
            try
            {
                var ev =  _databaseContext.Events.Where(predicate);
                return ev.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> RemoveEventByIdAsync(int id)
        {
            try
            {
                var ev = await _databaseContext.Events.FindAsync(id);
                var remove = _databaseContext.Events.Remove(ev);
                await _databaseContext.SaveChangesAsync();
                var state = remove.State == EntityState.Deleted;
                return state;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateEventAsync(Event ev)
        {
            try
            {
                var updateEvent = _databaseContext.Events.Update(ev);
                await _databaseContext.SaveChangesAsync();
                var isUpdate = updateEvent.State == EntityState.Modified;
                return isUpdate;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
