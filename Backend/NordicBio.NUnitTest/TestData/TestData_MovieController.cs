using NUnit.Framework;
using System.Collections;
using System.Net;

namespace NordicBio.NUnitTest.TestData
{
    class TestData_MovieController
    {
        public static IEnumerable Check_HttpStatusCode_OK
        {
            get
            {
                yield return new TestCaseData("1", HttpStatusCode.OK);
                yield return new TestCaseData("5", HttpStatusCode.OK);
                yield return new TestCaseData("10", HttpStatusCode.OK);
            }
        }
        public static IEnumerable Check_HttpStatusCode_NOTFOUND
        {
            get
            {
                yield return new TestCaseData("-15", HttpStatusCode.NotFound);
                yield return new TestCaseData("0", HttpStatusCode.NotFound);
                yield return new TestCaseData("21", HttpStatusCode.NotFound);
                yield return new TestCaseData("999", HttpStatusCode.NotFound);
            }
        }

        public static IEnumerable Check_MultiIdCorrect
        {
            get
            {
                yield return new TestCaseData("2");
                yield return new TestCaseData("4");
                yield return new TestCaseData("9");
            }
        }
    }
}
