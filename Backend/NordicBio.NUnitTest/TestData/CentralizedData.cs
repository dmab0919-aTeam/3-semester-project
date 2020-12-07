using NUnit.Framework;
using System.Collections;
using System.Net;

namespace NordicBio.NUnitTest.TestData
{
    public class CentralizedData
    {
        public static IEnumerable Check_HttpStatusCode_OK
        {
            get
            {
                yield return new TestCaseData(HttpStatusCode.OK);
            }
        }

        public static IEnumerable Check_HttpStatusCode_NOTFOUND
        {
            get
            {
                yield return new TestCaseData(HttpStatusCode.NotFound);
            }
        }

        public static IEnumerable Check_JsonFormat
        {
            get
            {
                yield return new TestCaseData("application/json; charset=utf-8");
            }
        }
    }
}
