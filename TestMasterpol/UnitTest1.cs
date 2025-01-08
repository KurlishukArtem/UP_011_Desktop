using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestMasterpol
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCalculateDiscount()
        {
            var discount = 10;
            Assert.AreEqual(discount, master_pol.Elements.Partner_item.CalculateDiscount(1));
        }

        [TestMethod]
        public void TestCalculateDiscountNegative()
        {
            var discount = 10;
            Assert.AreNotEqual(discount, master_pol.Elements.Partner_item.CalculateDiscount(2));
        }
    }
}
