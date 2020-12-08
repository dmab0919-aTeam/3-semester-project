using Newtonsoft.Json;
using NordicBio.dal.Entities;
using NordicBio.NUnitTest.TestData;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using System.Net;

namespace NordicBio.NUnitTest
{
    [TestFixture]
    class SeatControllerTests
    {
        RestClient _client = new RestClient("http://localhost:5000/api");
        string _controller = "seat";

        // RETURN A "OK" HTTP STATUS CODE
        [Test]
        [Category("Http Response")]
        [TestCaseSource(typeof(CentralizedData), "Check_HttpStatusCode_OK")]
        public void ReturnHttpStatusOK(HttpStatusCode expectedStatusCode)
        {
            // arrange
            RestRequest request = new RestRequest(_controller, Method.GET);

            // act
            IRestResponse response = _client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(expectedStatusCode));
        }

        // RETURN THE DATA FORMAT OF JSON
        [Test]
        [Category("ContentType/Json")]
        [TestCaseSource(typeof(CentralizedData), "Check_JsonFormat")]
        public void ContentTypeTest(string contentType)
        {
            // arrange
            RestRequest request = new RestRequest(_controller, Method.GET);

            // act
            IRestResponse response = _client.Execute(request);

            // assert
            Assert.That(response.ContentType, Is.EqualTo(contentType));
        }

        // RETURN EITHER "OK" OR "NOTFOUND" HTTP STATUS CODE
        [Test]
        [Category("Http Response")]
        [TestCaseSource(typeof(TestData_SeatController), "Check_HttpStatusCode_OK")]
        public void ReturnAllSeatsFromShowing(string id, HttpStatusCode expectedHttpStatusCode)
        {
            // arrange
            RestRequest request = new RestRequest($"{_controller}/{id}", Method.GET);

            // act
            IRestResponse response = _client.Execute(request);
            var jsonResponse = JsonConvert.DeserializeObject<List<Seat>>(response.Content);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(expectedHttpStatusCode));
            Assert.That(jsonResponse, Is.Not.Empty);
        }
    }
}
