
using System;
using FluentAssertions;
using HL7Generator.Model.V251.Segment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HL7Generator.Tests.SegmentTests
{
    [TestClass]
    public class MSHTests
    {
        [TestMethod]
        public void WhenGeneratingMSHSegment_WithDefault()
        {
            var msh = new MSH();
            msh.BuildSegment();
            var result = msh.ConvertToHL7();

            Console.WriteLine(result);
            result.Should().Contain("MSH|^~&|||||||^^||T|2.5.1|||NE|AL|USA|ASCII||||");
        }
    }
}
