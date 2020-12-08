using NUnit.Framework;
using RestSharp;
using System.Net;

namespace NordicBio.NUnitTest.Controllers
{
    [TestFixture]
    class AuthControllerShould
    {
        RestClient _client = new RestClient("http://localhost:5000/api");
        string _controller = "auth";

        [Test]
        [Category("Authentication")]
        [TestCaseSource(typeof(TestData_AuthController), "Check_RegisterNewUser")]
        public void RegisterNewUser(HttpStatusCode expectedHttpStatusCode, string firstName, string lastName, string email, string phoneNumber, string password)
        {
            // arrange
            RestRequest request = new RestRequest($"{_controller}/{"register"}", Method.POST);
            request.AddHeader("Accept", "application/json");
            request.Parameters.Clear();

            var body = new
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                Password = password
            };
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            // act
            IRestResponse response = _client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(expectedHttpStatusCode));
        }
    }
}
