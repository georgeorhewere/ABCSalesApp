using ABCApp.Data;
using ABCApp.Repo.Interfaces;
using ABCApp.Repo.StoredProcedures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCApp.Repo.Repositories
{
    public class CountryRepository : BaseRepository, ICountryRepository
    {        
        public CountryRepository(ABCDbContext _context):base(_context)
        {
           
        }

        public IEnumerable<Country> GetCountries()
        {
            return context.Countries.FromSqlRaw($"{DbProcedures.LoadCountries}").ToList();
        }

        public IEnumerable<Region> GetCountryRegions(string countryCode)
        {
            int countryId = Convert.ToInt32(countryCode);
            return context.Regions.FromSqlRaw($"{DbProcedures.LoadRegions} {countryId}").ToList();
        }

        public IEnumerable<City> GetRegionCities(string regionCode)
        {
            int regionId = Convert.ToInt32(regionCode);
            return context.Cities.FromSqlRaw($"{DbProcedures.LoadCities} {regionId}").ToList();
        }

    }
}
