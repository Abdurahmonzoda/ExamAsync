using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Services.DataContext
{
    public class DataContext
    {
        private readonly IConfiguration _configuration;
        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration; 

        }
        public NpgsqlConnection CreateConnection()
        {
            var connectionString = _configuration.GetConnectionString("SqlConnection");
            return new NpgsqlConnection(connectionString);
        }

    }
}
