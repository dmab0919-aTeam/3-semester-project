using Dapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NordicBio.dal.Entities;
using NordicBio.NUnitTest.TestData;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;

namespace NordicBio.NUnitTest.Controllers
{
    [TestFixture]
    class AuthControllerShould
    {
        RestClient _client = new RestClient("http://localhost:5000/api");
        string _controller = "auth";
        string _authToken = "";

        [Test, Order(1)]
        [Category("User Authentication")]
        [TestCaseSource(typeof(TestData_AuthController), "Check_RegisterNewUser")]
        public void RegisterNewUser(HttpStatusCode expectedHttpStatusCode, string firstName, string lastName, string email, string phoneNumber, string password)
        {
            // arrange
            string jsonbody =
                "{" +
                    "\"firstName\": " + "\"" + firstName + "\"," +
                    "\"lastName\": " + "\"" + lastName + "\"," +
                    "\"email\": " + "\"" + email + "\"," +
                    "\"phoneNumber\": " + "\"" + phoneNumber + "\"," +
                    "\"password\": " + "\"" + password + "\"" +
                "}";

            // create request
            RestRequest request = new RestRequest($"{_controller}/{"register"}", Method.POST);

            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            request.AddJsonBody(jsonbody);

            // act
            IRestResponse response = _client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(expectedHttpStatusCode));
        }

        [Test, Order(2)]
        [Category("User Authentication")]
        [TestCaseSource(typeof(TestData_AuthController), "Check_LoginUser")]
        public void LoginWithUser(HttpStatusCode expectedHttpStatusCode, string email, string password)
        {
            // arrange
            string jsonbody =
                "{" +
                    "\"email\": " + "\"" + email + "\"," +
                    "\"password\": " + "\"" + password + "\"" +
                "}";

            // create request
            RestRequest request = new RestRequest($"{_controller}/{"login"}", Method.POST);

            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            request.AddJsonBody(jsonbody);

            // act
            IRestResponse response = _client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(expectedHttpStatusCode));
        }

        [Test, Order(3)]
        [Category("Admin Authentication")]
        [TestCaseSource(typeof(TestData_AuthController), "Check_LoginAdmin")]
        public void LoginWithAdmin(HttpStatusCode expectedHttpStatusCode, string email, string password)
        {
            // arrange
            string jsonbody =
                "{" +
                    "\"email\": " + "\"" + email + "\"," +
                    "\"password\": " + "\"" + password + "\"" +
                "}";

            RestRequest request = new RestRequest($"{_controller}/{"login"}", Method.POST);
            request.AddJsonBody(jsonbody);

            // act
            IRestResponse response = _client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var jsonResponse = JsonConvert.DeserializeObject<string>(response.Content);
                var json = JObject.Parse(jsonResponse);
                _authToken = json.SelectToken("Key").ToString();
                Assert.That(json.SelectToken("Key").ToString(), Is.Not.Null);
            }
            // assert
            Assert.That(response.StatusCode, Is.EqualTo(expectedHttpStatusCode));

        }

        [Test, Order(4)]
        [Category("Admin Authentication")]
        [TestCaseSource(typeof(CentralizedData), "Check_HttpStatusCode_OK")]
        public void GetAllUsers(HttpStatusCode expectedHttpStatusCode)
        {
            //arrange
            RestRequest request = new RestRequest("user", Method.GET);
            _client.Authenticator = new JwtAuthenticator(_authToken);

            //act
            IRestResponse response = _client.Execute(request);
            var jsonResponse = JsonConvert.DeserializeObject<List<User>>(response.Content);

            //assert
            Assert.That(response.StatusCode, Is.EqualTo(expectedHttpStatusCode));
            Assert.That(jsonResponse[2].FirstName, Is.EqualTo("Test"));
            Assert.That(jsonResponse, Is.Not.Empty);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            var sql = "DELETE FROM Users WHERE FirstName = 'Test'";

            using (SqlConnection con = new SqlConnection("Server=localhost,1433\\Catalog=NordicBio;Database=NordicBio;User=SA;Password=Q23wa!!!32;"))
            {
                con.Execute(sql);
            }

            _authToken = "";
        }
    }
}
