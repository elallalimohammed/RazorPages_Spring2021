using ADONetMovie_RazorPages.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ADONetMovie_RazorPages.Services.ADOMovieService
{
    public class AdonetMovieService
    {
        private IConfiguration configuration { get; }
        string connectionString ;

        public AdonetMovieService() { }
        public AdonetMovieService(IConfiguration config)
        {
            configuration = config;
              connectionString = configuration.GetConnectionString("MovieConnection");
        }    
        public List<Movie> GetAllMovies()
        {
            List<Movie> lstmovie = new List<Movie>();
            string sql = "Select * From Movie ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Movie   movie = new Movie();
                        movie.Id = Convert.ToInt32(dataReader["Id"]);
                        movie.Title = Convert.ToString(dataReader["Title"]);
                        movie.Country= Convert.ToString(dataReader["Country"]);
                        movie.Year= Convert.ToInt32(dataReader["Year"]);
                        movie.StudioId = Convert.ToInt32(dataReader["StudioId"]);
                        movie.ActorId = Convert.ToInt32(dataReader["ActorId"]);
                        lstmovie.Add(movie);
                    }
                }
            }
            return lstmovie;
        }
      }
}
