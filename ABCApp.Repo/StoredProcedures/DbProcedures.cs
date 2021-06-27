using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCApp.Repo.StoredProcedures
{
    public class DbProcedures
    {
        public static readonly string LoadCountries = "[dbo].[GetCountries]";
        public static readonly string LoadRegions = "[dbo].[GetCountryRegions]";
        public static readonly string LoadCities = "[dbo].[GetRegionCities]";
        public static readonly string LoadProducts = "[dbo].[GetProducts]";
        public static readonly string GetProductByID = "[dbo].[GetProductById]";
        public static readonly string SaveOrderInfo = "[dbo].[sp_InsertOrderInfo]";
        public static readonly string SaveErrorInfo = "[dbo].[AddErrorInfo]";
        public static readonly string GetProductOrders = "[dbo].[GetProductOrders]";




    }
}
