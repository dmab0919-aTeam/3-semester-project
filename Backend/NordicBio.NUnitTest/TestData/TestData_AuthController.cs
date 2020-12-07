using NUnit.Framework;
using System.Collections;
using System.Net;

namespace NordicBio.NUnitTest.Controllers
{
    class TestData_AuthController
    {
        public static IEnumerable Check_RegisterNewUser
        {
            get
            {
                yield return new TestCaseData(HttpStatusCode.OK,
                    "Test", "User", "testmail@123.dk", "34532311", "TestPas1");
            }
        }
    }
}
