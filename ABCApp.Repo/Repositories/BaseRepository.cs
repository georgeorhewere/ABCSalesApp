using ABCApp.Data;
using ABCApp.Repo.Interfaces;
using ABCApp.Repo.StoredProcedures;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABCApp.Repo
{
    public class BaseRepository 
    {
        protected readonly ABCDbContext context;        

        public BaseRepository(ABCDbContext _context)
        {
            context = _context;
        }


        protected void SaveChanges()
        {
            context.SaveChangesAsync();
        }        

        protected void SaveError(DbError error)
        {
            List<SqlParameter> errorParams = new List<SqlParameter>
                                    { 
                                        // Create parameters    
                                        new SqlParameter { ParameterName = "@ErrorDetail", Value = error.ErrorDetail },
                                        new SqlParameter { ParameterName = "@ErrorBy", Value = error.ErrorBy },
                                        new SqlParameter { ParameterName = "@ErrorOn", Value = error.ErrorOn },
                                        };
            int savedRows = context.Database.ExecuteSqlRaw($"{DbProcedures.SaveErrorInfo} @ErrorDetail, @ErrorBy, @ErrorOn", errorParams.ToArray());
            SaveChanges();
        }

        
    }
}
