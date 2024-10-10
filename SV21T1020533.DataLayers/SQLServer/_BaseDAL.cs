﻿using Microsoft.Data.SqlClient;

namespace SV21T1020533.DataLayers.SQLServer
{
    public abstract class BaseDAL
    {
        protected string _connectionString = " ";
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public BaseDAL(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();
            return connection;
        }
    }
}
