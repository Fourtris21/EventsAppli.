using Android.Widget;
using Data.Classes;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data.Repositories
{
    public class OrganisationRepository : IOrganisationRepository
    {
        private readonly DatabaseContext _databaseContext;
        public OrganisationRepository(string dbPath)
        {
            _databaseContext = new DatabaseContext(dbPath);
        }
        public async Task<bool> AddOrganisationAsync(Organisation organisation)
        {
            try
            {
                if (OrganisationExists(organisation.OrganisationEmail))
                {
                    return false;
                }
                else
                {
                    var add = await _databaseContext.Organisations.AddAsync(organisation);
                    await _databaseContext.SaveChangesAsync();
                    var state = add.State == EntityState.Added;
                  
                    return state;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Organisation GetOrganisationByEmail(string email)
        {
                Organisation organisation = _databaseContext.Organisations.Where(item =>item.OrganisationEmail == email).FirstOrDefault();
                return organisation;
        }
        public bool LogIn(Organisation organisation)
        {
            try
            {
                Organisation org = GetOrganisationByEmail(organisation.OrganisationEmail);
                if (org.OrganisationPassword.Equals(organisation.OrganisationPassword))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool OrganisationExists(string email)
        {
            var organisation = _databaseContext.Organisations.Where(item => item.OrganisationEmail == email).FirstOrDefault();
            if(organisation != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
