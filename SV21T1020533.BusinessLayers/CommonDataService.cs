using Microsoft.Identity.Client;
using SV21T1020533.DataLayers;
using SV21T1020533.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV21T1020533.BusinessLayers
{
    public static class CommonDataService
    {
        private static readonly ICommonDAL<Customer> customerDB;
        private static readonly ICommonDAL<Category> categoryDB;
        private static readonly ICommonDAL<Supplier> supplierDB;
        private static readonly ICommonDAL<Employee> employeeDB;
        private static readonly ICommonDAL<Shipper> shipperDB;  
        /// <summary>
        /// ctor
        /// </summary>
        static CommonDataService()
        {
            string connectionString = "server=.;user id=sa;password=123;database=LiteCommerceDB_Update2023;TrustServerCertificate=true";
            customerDB = new DataLayers.SQLServer.CustomerDAL(connectionString);
            categoryDB = new DataLayers.SQLServer.CategoryDAL(connectionString);
            supplierDB = new DataLayers.SQLServer.SupplierDAL(connectionString);
            employeeDB = new DataLayers.SQLServer.EmployeeDAL(connectionString);
            shipperDB = new DataLayers.SQLServer.ShipperDAL(connectionString);

        }
        public static List<Customer> ListOfCustomers(out int rowCount, int page = 1, int pageSize = 0, string searchValue = "")
        {
            rowCount = customerDB.Count(searchValue);
            return customerDB.List(page, pageSize, searchValue);
        }
        public static List<Category> ListOfCategories(out int rowCount, int page = 1, int pageSize = 0, string searchValue = "")
        {
            rowCount = categoryDB.Count(searchValue);   
            return categoryDB.List(page, pageSize,searchValue); 
        }
        public static List<Supplier> ListOfSuppliers(out int rowCount, int page = 1, int pageSize = 0, string searchValue = "")
        {
            rowCount = supplierDB.Count(searchValue);
            return supplierDB.List(page, pageSize, searchValue);
        }
        public static List<Employee> ListOfEmployees(out int rowCount, int page = 1, int pageSize = 0, string searchValue = "")
        {
            rowCount = employeeDB.Count(searchValue);
            return employeeDB.List(page, pageSize, searchValue);
        }
        public static List<Shipper> ListOfShippers(out int rowCount, int page = 1, int pageSize = 0, string searchValue = "")
        {
            rowCount = shipperDB.Count(searchValue);
            return shipperDB.List(page, pageSize,searchValue) ;
        }


    }
}
