﻿using Azure;
using Dapper;
using SV21T1020533.DomainModels;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV21T1020533.DataLayers.SQLServer
{
    public class ProvinceDAL : BaseDAL, ISimpleSelectDAL<Province>
    {
        public ProvinceDAL(string connectionString) : base(connectionString)
        {
        }
        public List<Province> List()
        {
            List<Province> data = new List<Province>();
            using (var connection = OpenConnection())
            {
                var sql = @"select *
                        from Provinces";
                data = connection.Query<Province>(sql, commandType: System.Data.CommandType.Text).ToList();
                connection.Close();
            }
            return data;
        }
    }
}
