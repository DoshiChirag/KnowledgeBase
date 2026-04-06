using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Moq;
using EssentialTools.Models;
namespace EssentialTools.Tests
{
    [TestClass]
    public class UnitTest2
    {
        private Product[] products = {
                     new Product{Name = "Kayak", Category = "WaterSports", Price = 275M},
                     new Product{Name = "Lifejacket", Category = "WaterSports", Price = 48.95M},
                      new Product{Name = "Soccer ball", Category= "Soccer",Price = 19.50M},
                      new Product{Name = "Corner flag", Category = "Soccer", Price = 34.95M}
             };

        [TestMethod]
        public void Sum_Products_Correctly()
        {
            var discounter = new MinimumDiscountHelper();
            var target = new LinqValueCalculator(discounter);
            var goalTotal = products.Sum(e => e.Price);

            var result = target.ValueProducts(products);

            Assert.AreEqual(goalTotal, result);
        }


        [TestMethod]
        public void Moq_Sum_Products_Correctly()
        {
            Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();
            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>())).Returns<decimal>(total => total);
            
            var target = new LinqValueCalculator(mock.Object);

            var result = target.ValueProducts(products);

            Assert.AreEqual(products.Sum(e => e.Price), result);
        }


        private Product[] createProduct(decimal value)
        {
            return new[] { new Product { Price = value } };
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void Pass_Through_Variable_Discounts()
        {
            //Arrange
            Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();
            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>())).Returns<decimal>(total => total);
            mock.Setup(m => m.ApplyDiscount(It.Is<decimal>(v => v == 0))).Throws<System.ArgumentOutOfRangeException>();
            mock.Setup(m => m.ApplyDiscount(It.Is<decimal>(v => v > 100))).Returns<decimal>(total => (total * 0.9M));
            mock.Setup(m => m.ApplyDiscount(It.IsInRange<decimal>(10, 100, Range.Inclusive))).Returns<decimal>(total => (total - 5));

           

            var target = new LinqValueCalculator(mock.Object);


            //Act
            decimal  FiveDollarDiscount = target.ValueProducts(createProduct(5));
            decimal TenDollarDiscount = target.ValueProducts(createProduct(10));
            decimal FiftyDollarDiscount = target.ValueProducts(createProduct(50));
            decimal HundredDollarDiscount = target.ValueProducts(createProduct(100));
            decimal FiveHundredDollarDiscount = target.ValueProducts(createProduct(500));


            //Assert
            Assert.AreEqual(5, FiveDollarDiscount, "Failed $5");
            Assert.AreEqual(5, TenDollarDiscount, "Failed $10");
            Assert.AreEqual(45, FiftyDollarDiscount, "Failed $50");
            Assert.AreEqual(95, HundredDollarDiscount, "Failed $100");
            Assert.AreEqual(450, FiveHundredDollarDiscount, "Failed $500");


            target.ValueProducts(createProduct(0));



        }
        


    }
}
