
using ADONetMovie_RazorPages.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ADONetMovie_RazorPages.Services.ADOStudioService
{
    public class AdonetStudioService
    {
        private IConfiguration configuration { get; }
        string connectionString;

        public AdonetStudioService() { }
        public AdonetStudioService(IConfiguration config)
        {
            configuration = config;
            connectionString=configuration.GetConnectionString("MovieConnection");
        } 
        public List<Studio> GetAllStudios()
        {
            List<Studio> lst = new List<Studio>();       
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                connection.Open();
                string sql = "Select * From Studio";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Studio  studio = new Studio();
                        studio.Id= Convert.ToInt32(dataReader["Id"]);
                        studio.Name= Convert.ToString(dataReader["Name"]);
                        studio.Hqcity = Convert.ToString(dataReader["Hqcity"]);
                        studio.NoOfEmployees= Convert.ToInt32(dataReader["NoOfEmployees"]);
                        lst.Add(studio);
                    }
                }
         }
         return lst;
     }
    }
}

