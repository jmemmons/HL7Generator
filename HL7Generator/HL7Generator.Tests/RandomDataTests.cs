using FluentAssertions;
using HL7Generator.Base.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HL7Generator.Tests
{
    [TestClass]
    public class RandomDataTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var result = RandomData.Race();
            result.Length.Should().BeGreaterThan(0);
        }
    }
}
