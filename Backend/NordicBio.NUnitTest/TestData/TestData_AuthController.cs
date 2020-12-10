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
                yield return new TestCaseData(HttpStatusCode.BadRequest,
                    "123sdf", "adf12", "12sdf", "34", "sdfsfd");
                yield return new TestCaseData(HttpStatusCode.BadRequest,
                    "", "", "", "", "");
            }
        }

        public static IEnumerable Check_LoginUser
        {
            get
            {
                yield return new TestCaseData(HttpStatusCode.OK,
                    "testmail@123.dk", "TestPas1");
                yield return new TestCaseData(HttpStatusCode.BadRequest,
                    "thisisnotworking", "blabla");
                yield return new TestCaseData(HttpStatusCode.BadRequest,
                    "", "");
            }
        }

        public static IEnumerable Check_LoginAdmin
        {
            get
            {
                yield return new TestCaseData(HttpStatusCode.OK,
                    "admin@1234.dk", "admin123");
                yield return new TestCaseData(HttpStatusCode.BadRequest,
                    "notadmin@12.dk", "password");
                yield return new TestCaseData(HttpStatusCode.BadRequest,
                    "", "");
            }
        }
    }
}
