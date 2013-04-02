using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApplicationInstaller.Classes;

namespace Tests
{
    [TestClass]
    public class TestSlugifier
    {
        [TestMethod]
        public void TestGenerateSlug()
        {
            String slugified = Slugifier.GenerateSlug("Make t=#s a sl*g");
            Assert.AreEqual(slugified, "make-ts-a-slg");

            String longSlug = Slugifier.GenerateSlug("Sho!!end this long string into a slug thirty fourty fifty");
            Assert.AreEqual(longSlug, "shoend-this-long-string-into-a-slug-thirty-fo");
            Assert.AreEqual(longSlug.Length, 45);
        }
    }
}
