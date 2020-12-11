using Newtonsoft.Json;
using NordicBio.dal.Entities;
using NordicBio.NUnitTest.TestData;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using System.Net;

namespace NordicBio.NUnitTest
{
    class ShowingControllerTests
    {
        RestClient _client = new RestClient("http://localhost:5000/api");
        string _controller = "showing";

        [Test, Ignore("needs admin token")]
        [Category("Showings")]
        [TestCaseSource(typeof(CentralizedData), "Check_HttpStatusCode_OK")]
        public void GetAllShowings(HttpStatusCode expectedHttpStatusCode)
        {
            //arrange
            RestRequest request = new RestRequest(_controller, Method.GET);

            //act
            IRestResponse response = _client.Execute(request);
            var jsonResponse = JsonConvert.DeserializeObject<List<Showing>>(response.Content);

            //assert
            Assert.That(response.StatusCode, Is.EqualTo(expectedHttpStatusCode));
            Assert.That(jsonResponse[0].Id, Is.EqualTo(1));
            Assert.That(jsonResponse, Is.Not.Empty);
        }

        // RETURN THE DATA FORMAT OF JSON
        [Test, Ignore("needs admin token")]
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
    }
}
