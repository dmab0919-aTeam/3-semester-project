using RestSharp;
using System.Net;
using Xunit;

namespace NordicBio.XUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void StatusCodeTest()
        {
            RestClient client = new RestClient("http://localhost:5000/api");
            RestRequest request = new RestRequest("movies", Method.GET);

            // act
            var response = client.Execute(request);

            // assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public void ContentTypeTest()
        {
            // arrange
            RestClient client = new RestClient("http://localhost:5000/api");
            RestRequest request = new RestRequest("movies", Method.GET);

            // act
            var response = client.Execute(request);

            // assert
            Assert.Equal("application/json", response.ContentType);
        }
    }
}
