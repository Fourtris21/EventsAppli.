using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// 
/// </summary>
namespace Data.Classes
{
    public class Organisation
    {
        [PrimaryKey, AutoIncrement]
        public int OrganisationId { get; set; }
        [Unique]
        public string OrganisationEmail { get; set; }
        public string OrganisationPassword { get; set; }
        public string OrganisationName { get; set; }
        [OneToMany]
        public List<Event> Events { get; set; }
        public bool CheckInformation()
        {
            if (OrganisationEmail.Equals("") && OrganisationPassword.Equals(""))
                return false;
            else return true;
        }
        public override string ToString()
        {
            return $"{OrganisationName}";
        }
    }
}