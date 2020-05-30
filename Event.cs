using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
/// <summary>
/// този клас създава таблица от events
/// съдържа ключ, който референсира към таблицата с organisations
/// </summary>

namespace Data.Classes
{
    public class Event
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EventType { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public DateTime DateTime { get; set; }

        public bool IsVisible { get; set; }
        [ForeignKey(typeof(Event))]
        public int OrganisationId { get; set; }
        public Organisation Org { get; set; }

        public override string ToString()
        {
            return $"{Id}. {Name}";
        }
    }
}
