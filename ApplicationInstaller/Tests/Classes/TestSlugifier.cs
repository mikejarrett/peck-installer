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
            Assert.AreEqual("make-ts-a-slg", slugified);

            String longSlug = Slugifier.GenerateSlug("Sho!!end this long string into a slug thirty fourty fifty");
            Assert.AreEqual("shoend-this-long-string-into-a-slug-thirty-fo", longSlug);
            Assert.AreEqual(45, longSlug.Length);
        }
    }
}
