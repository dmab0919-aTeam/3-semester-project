using NUnit.Framework;
using System.Collections;
using System.Net;

namespace NordicBio.NUnitTest.TestData
{
    class TestData_SeatController
    {
        public static IEnumerable Check_HttpStatusCode_OK
        {
            get
            {
                yield return new TestCaseData("1", HttpStatusCode.OK);
                yield return new TestCaseData("2", HttpStatusCode.OK);
            }
        }
    }
}
