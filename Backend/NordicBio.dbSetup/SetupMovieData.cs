using Dapper;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace NordicBio.dbSetup
{
    class SetupMovieData
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.AppSettings["connString"];
            
            var client = new RestClient("https://api.themoviedb.org");
            var request = new RestRequest("3/movie/upcoming?api_key=e1875a74a5c3708b92a2472f875f422d&language=da-DK&page=1", Method.GET);

            var response = client.Execute(request);

            //Dynamic variable bliver compilet i runtime, derfor vi kan tilgå json i respone.
            dynamic json = JObject.Parse(response.Content);
            JArray items = (JArray)json["results"];
            int length = items.Count;

            string sql = "INSERT INTO Movies (Title, ReleaseDate, VoteAverage, PosterPath) " +
                "VALUES (@Title, @ReleaseDate, @VoteAverage, @PosterPath)";
            
            using (var connection = new SqlConnection(connectionString))
            {
                for (int i = 1; i < 20; i++)
                {
                    var affectedRows = connection.Execute(sql, new
                    {
                        Title = (string)json.results[i].title,
                        ReleaseDate = (string)json.results[i].release_date,
                        VoteAverage = (decimal)json.results[i].vote_average,
                        PosterPath = (string)json.results[i].poster_path
                    });
                }
            }
        }
    }
}
