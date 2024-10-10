using Dapper;
using SV21T1020533.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV21T1020533.DataLayers.SQLServer
{
    public class ShipperDAL : BaseDAL, ICommonDAL<Shipper>
    {
        public ShipperDAL(string connectionString) : base(connectionString)
        {
        }

        public int Add(Shipper data)
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
                        from Shippers
                        where (ShipperName like @searchValue)";
                var parameters = new
                {
                    searchValue
                };
                count = connection.ExecuteScalar<int>(sql, parameters, commandType: System.Data.CommandType.Text);

            }

            return count;
        }

        public bool Delete(Shipper data)
        {
            throw new NotImplementedException();
        }

        public Shipper? Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool InUsed(int id)
        {
            throw new NotImplementedException();
        }

        public List<Shipper> List(int page = 1, int pageSize = 0, string searchValue = "")
        {
            List<Shipper> data = new List<Shipper>();
            searchValue = $"%{searchValue}%"; //Tìm kiếm tương đối với LIKE
            using (var connection = OpenConnection())
            {
                var sql = @"select *
                        from (
	                        select *, row_number() over(order by ShipperName) as RowNumber
	                        from Shippers
	                        where (ShipperName like @searchValue)
                        ) as t
                        where (@pageSize = 0) or (RowNumber between (@page - 1) * @pageSize + 1 and @page * @pageSize)
                        order by RowNumber;";
                var parameters = new
                {
                    page = page,
                    pageSize = pageSize,
                    searchValue = searchValue
                };
                data = connection.Query<Shipper>(sql, parameters, commandType: System.Data.CommandType.Text).ToList();
                connection.Close();
            }
            return data;
        }

        public bool Update(Shipper data)
        {
            throw new NotImplementedException();
        }
    }
}
