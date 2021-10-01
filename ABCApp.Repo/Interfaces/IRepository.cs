using ABCApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCApp.Repo.Interfaces
{
    public interface IRepository
    {        
        void SaveError(DbError error);

    }
}
