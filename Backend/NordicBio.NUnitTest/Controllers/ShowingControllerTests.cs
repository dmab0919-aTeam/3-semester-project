using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NordicBio.dal.Entities;
using NordicBio.NUnitTest.TestData;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace NordicBio.NUnitTest
{
    class ShowingControllerTests
    {
        RestClient _client = new RestClient("http://localhost:5000/api");
        string _controller = "showing";
        string _authToken = "";


        [SetUp]
        public void Init()
        {
            // Parameters
            string email = "admin@1234.dk";
            string password = "admin123";
            // Create Json body for login to admin
            string jsonbody =
                "{" +
                    "\"email\": " + "\"" + email + "\"," +
                    "\"password\": " + "\"" + password + "\"" +
                "}";

            // Login with the Admin
            RestRequest request = new RestRequest("auth/login", Method.POST);
            request.AddJsonBody(jsonbody);

            // Execute the request
            IRestResponse response = _client.Execute(request);

            // Collect the JWT
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var jsonResponse = JsonConvert.DeserializeObject<string>(response.Content);
                var json = JObject.Parse(jsonResponse);
                _authToken = json.SelectToken("Key").ToString();
            }
        }

        [Test]
        [Category("Showings")]
        [TestCaseSource(typeof(CentralizedData), "Check_HttpStatusCode_OK")]
        public void GetAllShowings(HttpStatusCode expectedHttpStatusCode)
        {
            //arrange
            RestRequest request = new RestRequest(_controller, Method.GET);
            request.AddHeader("Authorization", string.Format("bearer {0}", this._authToken));          

            //act
            IRestResponse response = _client.Execute(request);

            var jsonResponse = JsonConvert.DeserializeObject<List<Showing>>(response.Content);

            //assert
            Assert.That(response.StatusCode, Is.EqualTo(expectedHttpStatusCode));
            Assert.That(jsonResponse, Is.Not.Empty);
        }

        // RETURN THE DATA FORMAT OF JSON
        [Test]
        [Category("ContentType/Json")]
        [TestCaseSource(typeof(CentralizedData), "Check_JsonFormat")]
        public void ReturnJsonOnGet(string contentType)
        {
            // arrange
            RestRequest request = new RestRequest(_controller, Method.GET);
            request.AddHeader("Authorization", string.Format("bearer {0}", this._authToken));

            // act
            IRestResponse response = _client.Execute(request);

            // assert
            Assert.That(response.ContentType, Is.EqualTo(contentType));
        }
    }
}
