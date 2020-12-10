using Newtonsoft.Json.Linq;
using NordicBio.NUnitTest.TestData;
using NUnit.Framework;
using RestSharp;
using System.Net;

namespace NordicBio.NUnitTest
{
    [TestFixture]
    class MovieControllerShould
    {
        RestClient _client = new RestClient("http://localhost:5000/api");
        string _controller = "movies";

        [Test]
        [Category("Http Response")]
        [TestCaseSource(typeof(TestData_MovieController), "Check_HttpStatusCode_OK")]
        public void ReturnHttpStatusOK(string id, HttpStatusCode expectedHttpStatusCode)
        {
            // arrange
            RestRequest request = new RestRequest($"{_controller}/{id}", Method.GET);

            // act
            IRestResponse response = _client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(expectedHttpStatusCode));
        }

        [Test]
        [Category("Http Response")]
        [TestCaseSource(typeof(TestData_MovieController), "Check_HttpStatusCode_NOTFOUND")]
        public void ReturnHttpStatusNOTFOUND(string id, HttpStatusCode expectedStatusCode)
        {
            // arrange
            RestRequest request = new RestRequest($"{_controller}/{id}", Method.GET);

            // act
            IRestResponse response = _client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(expectedStatusCode));
        }

        // RETURN THE DATA FORMAT OF JSON
        [Test]
        [Category("ContentType/Json")]
        [TestCaseSource(typeof(CentralizedData), "Check_JsonFormat")]
        public void ReturnJsonOnGet(string contentType)
        {
            // arrange
            RestRequest request = new RestRequest(_controller, Method.GET);

            // act
            IRestResponse response = _client.Execute(request);

            // assert
            Assert.That(response.ContentType, Is.EqualTo(contentType));
        }

        // RETURN THE DATA FORMAT OF JSON
        [Test]
        [Category("ContentType/Json")]
        [TestCaseSource(typeof(CentralizedData), "Check_JsonFormat")]
        public void ReturnJsonOnGetById(string contentType)
        {
            // arrange
            RestRequest request = new RestRequest($"{_controller}/{1}", Method.GET);

            // act
            IRestResponse response = _client.Execute(request);

            // assert
            Assert.That(response.ContentType, Is.EqualTo(contentType));
        }

        // RETURN THE RIGHT MOVIE ID
        [Test]
        [Category("Movies By Id")]
        [TestCaseSource(typeof(TestData_MovieController), "Check_MultiIdCorrect")]
        public void ReturnMovieId(string id)
        {
            // arrange
            RestRequest request = new RestRequest($"{_controller}/{id}", Method.GET);

            // act
            IRestResponse response = _client.Execute(request);
            var json = JObject.Parse(response.Content);

            // assert
            Assert.That(json.SelectToken("id").ToString(), Is.EqualTo(id.ToString()));
        }
    }
}
