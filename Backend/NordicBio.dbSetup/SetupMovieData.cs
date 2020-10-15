using Dapper;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Data.SqlClient;

namespace NordicBio.dbSetup
{
    class SetupMovieData
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://api.themoviedb.org");
            var request = new RestRequest("3/movie/upcoming?api_key=e1875a74a5c3708b92a2472f875f422d&language=da-DK&page=1", Method.GET);

            var response = client.Execute(request);

            //Dynamic variable bliver compilet i runtime, derfor vi kan tilgå json i respone.
            dynamic json = JObject.Parse(response.Content);
            JArray items = (JArray)json["results"];
            int length = items.Count;

            string sql = "INSERT INTO Movies (title, release_date, vote_avarage, poster_path) VALUES (@title, @release_date, @vote_avarage, @poster_path)";
            string constring = "Server=(localdb)\\mssqllocaldb; Database=NordicBio; Trusted_connection=true";
            using (var connection = new SqlConnection(constring))
            {
                for (int i = 1; i < 20; i++)
                {
                    var affectedRows = connection.Execute(sql, new
                    {
                        title = (string)json.results[i].title,
                        release_date = (string)json.results[i].release_date,
                        vote_avarage = (decimal)json.results[i].vote_average,
                        poster_path = (string)json.results[i].poster_path
                    });
                }
            }
        }
    }
}
