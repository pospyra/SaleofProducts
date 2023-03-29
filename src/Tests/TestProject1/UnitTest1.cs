using Otiva.API.Controllers;
using Otiva.Domain;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async void TestMethod1()
        {
            var testProducts = GetTestProducts();
            var controller = new CategoryController(testProducts);

            var result = await controller.GetAllCategory() as List<Category>;
            Assert.AreEqual(testProducts.Count, result.Count);
        }

        private List<Category> GetTestProducts()
        {
            var testProducts = new List<Category>();
            testProducts.Add(new Category { Id = Guid.NewGuid(), Name = "Demo1" });
            testProducts.Add(new Category { Id = Guid.NewGuid(), Name = "Demo2" });
            testProducts.Add(new Category { Id = Guid.NewGuid(), Name = "Demo3"});
            testProducts.Add(new Category { Id = Guid.NewGuid(), Name = "Demo4"});
            return testProducts;
        }
    }
}