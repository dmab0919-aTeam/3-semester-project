
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NordicBio.api.Domain;

using System.Collections.Generic;

using System.Net.Http;


namespace NordicBio.api.Services
       
{
    public class ProductsService : IProductsService
    {
        private readonly IConfiguration configuration1;

        public ProductsService(IConfiguration configuration)
        {
            configuration1 = configuration;


        }

        public string Getmovies()
        {
            string result = GetResponseString();

            return result;
        }
        public ICollection<Product> GetAll()
        {
            string df = configuration1["TMDBApi"];


            string result = GetResponseString();
            //var model = JsonConvert.DeserializeObject<SentimentJsonModel>(result.Result);

            JObject json = JObject.Parse(result);

            return new List<Product>()
            {

                new Product(){ Name=df, Price = 1299.90},
                new Product(){ Name=result, Price = 1599.90}
            };
        }

        private string GetResponseString()
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync("https://api.themoviedb.org/3/movie/upcoming?api_key=e1875a74a5c3708b92a2472f875f422d&language=da-DK&page=1").Result;
            var contents = response.Content.ReadAsStringAsync().Result;
            return contents;
        }
    }
}
