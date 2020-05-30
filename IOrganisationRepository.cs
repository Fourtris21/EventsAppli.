using Data.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Data.Interfaces
{
    public interface IOrganisationRepository
    {
        Task<bool> AddOrganisationAsync(Organisation organisation);
        Organisation GetOrganisationByEmail(string email);
        bool LogIn(Organisation organisation);
        bool OrganisationExists(string email);
    }
}