using NUnit.Framework;
using System;
using System.Transactions;

namespace NordicBio.NUnitTest
{
    /// <summary>
    /// Rollback Attribute wraps test execution into a transaction and cancels the transaction once the test is finished.
    /// You can use this attribute on single test methods or test classes/suites
    /// </summary>
    public class RollbackAttribute : Attribute, ITestAction
    {
        private TransactionScope transaction;

        public void BeforeTest(NUnit.Framework.Interfaces.ITest test)
        {
            transaction = new TransactionScope();
        }

        public void AfterTest(NUnit.Framework.Interfaces.ITest test)
        {
            transaction.Dispose();
        }

        public ActionTargets Targets
        {
            get { return ActionTargets.Test; }
        }
    }
}
