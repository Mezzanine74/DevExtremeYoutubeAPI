using DevExtremeYoutubeModel.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace DevExtremeYoutubeAPI.Tests
{
    [TestClass]
    public class EntityModelUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var context = new NorthwindEntities())
            {
                var test = context.Products.Take(10).ToList();
                Assert.IsNotNull(test);
            }
        }
    }
}
