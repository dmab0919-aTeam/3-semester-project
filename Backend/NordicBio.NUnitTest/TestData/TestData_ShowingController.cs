using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace NordicBio.NUnitTest.TestData
{
    class TestData_ShowingController
    {
        public static IEnumerable AdminLogin
        {
            get
            {
                yield return new TestCaseData(HttpStatusCode.OK,
                    "admin@1234.dk", "admin123");

            }
        }
        
    }
}
