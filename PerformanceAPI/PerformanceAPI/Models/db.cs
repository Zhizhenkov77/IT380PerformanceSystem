﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data.SqlClient;

namespace PerformanceAPI.Models
{
    public class db
    {
        SqlConnection con;
        public db()
        {
            var configuation = GetConfiguration();
            con = new SqlConnection(configuation.GetSection("Data").GetSection("ConnectionString").Value);
            
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
    }

    
}
