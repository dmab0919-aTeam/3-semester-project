using NUnit.Framework;
using RestSharp;
using System.Net;

namespace NordicBio.NUnitTest
{
    public class BasicControllerTests
    {
        [TestCase("movies", HttpStatusCode.OK, TestName = "MovieCtrl - StatusCode")]
        [TestCase("showing", HttpStatusCode.OK, TestName = "ShowingCtrl - StatusCode")]
        [TestCase("seat", HttpStatusCode.OK, TestName = "SeatCtrl - StatusCode")]
        //[TestCase("user", HttpStatusCode.OK, TestName = "Test of UserController")]
        public void StatusCode(string controller, HttpStatusCode expectedStatusCode)
        {
            // arrange
            RestClient client = new RestClient("http://localhost:5000/api");
            RestRequest request = new RestRequest(controller, Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(expectedStatusCode));
        }

        [TestCase("movies", "application/json; charset=utf-8", TestName = "MovieCtrl - Contenttype of json")]
        [TestCase("showing", "application/json; charset=utf-8", TestName = "ShowingCtrl - Contenttype of json")]
        [TestCase("seat", "application/json; charset=utf-8", TestName = "SeatCtrl - Contenttype of json")]
        public void ContentTypeTest(string controller, string contentType)
        {
            // arrange
            RestClient client = new RestClient("http://localhost:5000/api");
            RestRequest request = new RestRequest(controller, Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.ContentType, Is.EqualTo(contentType));
        }
    }
}