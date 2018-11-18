using Quintity.TestFramework.Core;

namespace Quintity.TestFramework.TestLibrary
{
    [TestClass]
    public class TestClass : TestClassBase
    {
        [TestMethod]
        public TestVerdict SampleTestMethod()
        {
            return TestVerdict.Pass;
        }
    }
}
