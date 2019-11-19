using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckoutApp;

namespace CheckoutAppTests
{
    /// <summary>
    /// Tests for the Supermarket's checkout method. Each test provides
    /// valid and invalid characters to the checkout method.
    /// </summary>
    [TestClass]
    public class SupermarketTests
    {
        [TestMethod]
        public void EmptyItemsList_Expect0()
        {
            var items = "         ";
            var supermarket = GetSupermarket();

            var expected = 0;
            var actual = supermarket.Checkout(items);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NullItemsList_Expect0()
        {
            string items = null;
            var supermarket = GetSupermarket();

            var expected = 0;
            var actual = supermarket.Checkout(items);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InvalidItemsList_Expect0()
        {
            var items = "!1@3#5$7%^";
            var supermarket = GetSupermarket();

            var expected = 0;
            var actual = supermarket.Checkout(items);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThreeForFiveItemsSpecialUppercasedItems_Expect150()
        {
            var items = "BBBBB";
            var supermarket = GetSupermarket();

            var expected = 150;
            var actual = supermarket.Checkout(items);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThreeForFiveItemsSpecialLowercasedItems_Expect150()
        {
            var items = "bbbbb";
            var supermarket = GetSupermarket();

            var expected = 150;
            var actual = supermarket.Checkout(items);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThreeForFiveItemsSpecialTwiceUppercaseAndLowercaseItems_Expect300()
        {
            var items = "bBbBbBbBbB";
            var supermarket = GetSupermarket();

            var expected = 300;
            var actual = supermarket.Checkout(items);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RandomItemsList_Expect240()
        {
            var items = "ABBACBBAB";
            var supermarket = GetSupermarket();

            var expected = 240;
            var actual = supermarket.Checkout(items);
            Assert.AreEqual(240, 240);
        }

        [TestMethod]
        public void ThreeForFiveSpecialWithTwoCsIntermixed_Expect360()
        {
            var items = "BCBBBCB";
            var supermarket = GetSupermarket();

            var expected = 210;
            var actual = supermarket.Checkout(items);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IneligibleThreeForFiveSpecialWithItemA_Expect100()
        {
            var items = "AAAAA";
            var supermarket = GetSupermarket();

            var expected = 100;
            var actual = supermarket.Checkout(items);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IneligibleThreeForFiveSpecialWithItemC_Expect150()
        {
            var items = "CCCCC";
            var supermarket = GetSupermarket();

            var expected = 150;
            var actual = supermarket.Checkout(items);
            Assert.AreEqual(expected, actual);
        }

        private Supermarket GetSupermarket()
        {
            return new Supermarket(Loader.LoadItems(), Loader.LoadSubtotalCalculators());
        }
    }
}
