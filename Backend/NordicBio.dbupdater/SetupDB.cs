﻿using Dapper;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Data.SqlClient;
using System.IO;

namespace NordicBio.dbSetup
{
    public class SetupDB
    {
        public void Setup()
        {
            const string connectionString = "Server=localhost,1433\\Catalog=NordicBio;Database=NordicBio;User=SA;Password=Q23wa!!!32;";

            // RestSharp client, request and response
            var client = new RestClient("https://api.themoviedb.org");
            var request = new RestRequest("3/movie/upcoming?api_key=e1875a74a5c3708b92a2472f875f422d&language=EN&page=1", Method.GET);
            var response = client.Execute(request);

            //Dynamic variable bliver compilet i runtime, derfor vi kan tilgå json i respone.
            dynamic json = JObject.Parse(response.Content);
            JArray items = (JArray)json["results"];

            // Prepaired statement
            const string sql = "INSERT INTO [dbo].[Movies] (Title, ReleaseDate, VoteAverage, PosterPath, Description) " +
                               "VALUES (@Title, @ReleaseDate, @VoteAverage, @PosterPath, @Description)";

            // Executer sql statement
            using (var connection = new SqlConnection(connectionString))
            {
                for (int i = 1; i < 20; i++)
                {
                    connection.Execute(sql, new
                    {
                        Title = (string)json.results[i].title,
                        ReleaseDate = (string)json.results[i].release_date,
                        VoteAverage = (decimal)json.results[i].vote_average,
                        PosterPath = (string)json.results[i].poster_path,
                        Description = (string)json.results[i].overview

                    });
                }
                connection.Close();
            }
        }

        public void AddDummyData()
        {
            string sqlConnectionString = "Server=localhost,1433\\Catalog=NordicBio;Database=NordicBio;User=SA;Password=Q23wa!!!32;";

            FileInfo file = new FileInfo("./Scripts/DummyData.sql");
            string script = file.OpenText().ReadToEnd();

            SqlConnection conn = new SqlConnection(sqlConnectionString);
            conn.Open();
            conn.Execute(script);
            conn.Close();
        }
    }
}
