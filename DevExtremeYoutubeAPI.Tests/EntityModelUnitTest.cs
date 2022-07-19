using DevExtremeYoutubeDataAccess.DAL;
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

        [TestMethod]
        public void TestMethod2()
        {
                var dal = new CategoryDal();
                var test = dal.GetList();
                Assert.IsNotNull(test);
        }

        [TestMethod]
        public void TestMethod3()
        {
                var dal = new CategoryDal();
                var newCategory = new Category()
                {
                    CategoryName = "test",
                    Description = "desc",
                };

                var addResult = dal.Add(newCategory);
                Assert.IsNotNull(addResult);

                newCategory.CategoryName = "impossibletext";
            dal.Update(newCategory);

            Assert.IsNotNull(dal.Get(c => c.CategoryName.ToLower() == "impossibletext"));

                var deleteResult = dal.Delete(newCategory);
                Assert.IsTrue(deleteResult > 0);
        }

        [TestMethod]
        public void TestMethod4()
        {
                var dal = new CategoryDal();
                var test = dal.GetByPrimaryKey(1);
                Assert.IsNotNull(test);
        }

    }
}
