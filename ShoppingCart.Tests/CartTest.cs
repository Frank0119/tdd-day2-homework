using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ShoppingCart;

namespace ShoppingCart.Tests
{
    [TestClass]
    public class CartTest
    {
        private static IList<Book> _books;

        [ClassInitialize()]
        public static void CartTestInitialize(TestContext TestContext)
        {
            _books = new List<Book>();
            _books.Add(new Book { Id = 1, Name = "Harry Potter and the Philosopher's Stone", SellPrice = 100 });
            _books.Add(new Book { Id = 2, Name = "Harry Potter and the Chamber of Secrets", SellPrice = 100 });
            _books.Add(new Book { Id = 3, Name = "Harry Potter and the Prisoner of Azkaban", SellPrice = 100 });
            _books.Add(new Book { Id = 4, Name = "Harry Potter and the Goblet of Fire", SellPrice = 100 });
            _books.Add(new Book { Id = 5, Name = "Harry Potter and the Order of the Phoenix", SellPrice = 100 });
        }

        [ClassCleanup()]
        public static void CartTestCleanup()
        {
            _books = null;
        }

        /// <summary>
        /// 加入一本哈利波特書籍至購物車中並結帳，預期結帳金額應等於其售價 100
        /// </summary>
        [TestMethod]
        public void Test_add_1_book_to_cart_then_checkout_total_should_be_equal_sell_price()
        {
            // Arrange
            var book = new Book { Id = 1, Name = "Harry Potter and the Philosopher's Stone", SellPrice = 100 };
            var expected = book.SellPrice;

            var target = new Cart();
            target.Add(book);
            target.Checkout();

            // Act
            var actual = target.Total;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
