using System;
using Dapper;
using SV21T1020533.DomainModels;

namespace SV21T1020533.DataLayers.SQLServer
{
    public class CustomerDAL : BaseDAL, ICommonDAL<Customer>
    {
        public CustomerDAL(string connectionString) : base(connectionString)
        {
        }

        public int Add(Customer data)
        {
            throw new NotImplementedException();
        }

        public int Count(string searchValue = "")
        {
            int count = 0;
            searchValue = $"%{searchValue}%";
            using (var connection = OpenConnection())
            {
                var sql = @"select count(*)
                        from Customers
                        where (CustomerName like @searchValue) or (ContactName like @searchValue)";
                var parameters = new
                {
                    searchValue
                };
                count = connection.ExecuteScalar<int>(sql, parameters, commandType: System.Data.CommandType.Text);
                
            }

            return count;
        }

        public bool Delete(Customer data)
        {
            throw new NotImplementedException();
        }

        public Customer? Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool InUsed(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> List(int page = 1, int pageSize = 0, string searchValue = "")
        {
            List<Customer> data = new List<Customer>();
            searchValue = $"%{searchValue}%"; //Tìm kiếm tương đối với LIKE
            using (var connection = OpenConnection())
            {
                var sql = @"select *
                        from (
	                        select *, row_number() over(order by CustomerName) as RowNumber
	                        from Customers
	                        where (CustomerName like @searchValue) or (ContactName like @searchValue)
                        ) as t
                        where (@pageSize = 0) or (RowNumber between (@page - 1) * @pageSize + 1 and @page * @pageSize)
                        order by RowNumber;";
                var parameters = new
                {
                    page = page,
                    pageSize = pageSize,
                    searchValue = searchValue
                };
                data = connection.Query<Customer>(sql, parameters, commandType: System.Data.CommandType.Text).ToList();
                connection.Close();
            }
            return data;
        }

        public bool Update(Customer data)
        {
            throw new NotImplementedException();
        }
    }
}
