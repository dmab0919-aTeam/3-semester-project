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
        [TearDown]
        public void TearDown()
        {
            var sql = "DELETE FROM Users WHERE FirstName = 'Test'";

            using (SqlConnection con = new SqlConnection(_constring))
            {
                try
                {
                    var res = await con.ExecuteAsync(sql, parameters);
                    return res;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

            }
        }
    }
}
