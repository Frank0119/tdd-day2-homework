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
        /// 加入一本書籍至購物車中並結帳，預期結帳金額應等於其售價 100
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

        /// <summary>
        /// 加入兩本不同書籍至購物車中並結帳，預期結帳金額應等於其售價 100 * 2 * 0.95
        /// </summary>
        [TestMethod]
        public void Test_add_2_different_books_to_cart_then_checkout_total_should_be_equal_sell_price_5_percent_save_off()
        {
            // Arrange
            var book_1 = new Book { Id = 1, Name = "Harry Potter and the Philosopher's Stone", SellPrice = 100 };
            var book_2 = new Book { Id = 2, Name = "Harry Potter and the Chamber of Secrets", SellPrice = 100 };
            var expected = (book_1.SellPrice + book_2.SellPrice) * 0.95;

            var target = new Cart();
            target.Add(book_1);
            target.Add(book_2);
            target.Checkout();

            // Act
            var actual = target.Total;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 加入三本不同書籍至購物車中並結帳，預期結帳金額應等於其售價 100 * 3 * 0.9
        /// </summary>
        [TestMethod]
        public void Test_add_3_different_books_to_cart_then_checkout_total_should_be_equal_sell_price_10_percent_save_off()
        {
            // Arrange
            var book_1 = new Book { Id = 1, Name = "Harry Potter and the Philosopher's Stone", SellPrice = 100 };
            var book_2 = new Book { Id = 2, Name = "Harry Potter and the Chamber of Secrets", SellPrice = 100 };
            var book_3 = new Book { Id = 3, Name = "Harry Potter and the Prisoner of Azkaban", SellPrice = 100 };
            var expected = (book_1.SellPrice + book_2.SellPrice + book_3.SellPrice) * 0.9;

            var target = new Cart();
            target.Add(book_1);
            target.Add(book_2);
            target.Add(book_3);
            target.Checkout();

            // Act
            var actual = target.Total;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 加入四本不同書籍至購物車中並結帳，預期結帳金額應等於其售價 100 * 4 * 0.8
        /// </summary>
        [TestMethod]
        public void Test_add_4_different_books_to_cart_then_checkout_total_should_be_equal_sell_price_20_percent_save_off()
        {
            // Arrange
            var book_1 = new Book { Id = 1, Name = "Harry Potter and the Philosopher's Stone", SellPrice = 100 };
            var book_2 = new Book { Id = 2, Name = "Harry Potter and the Chamber of Secrets", SellPrice = 100 };
            var book_3 = new Book { Id = 3, Name = "Harry Potter and the Prisoner of Azkaban", SellPrice = 100 };
            var book_4 = new Book { Id = 4, Name = "Harry Potter and the Goblet of Fire", SellPrice = 100 };
            var expected = (book_1.SellPrice + book_2.SellPrice + book_3.SellPrice + book_4.SellPrice) * 0.8;

            var target = new Cart();
            target.Add(book_1);
            target.Add(book_2);
            target.Add(book_3);
            target.Add(book_4);
            target.Checkout();

            // Act
            var actual = target.Total;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 加入五本不同書籍至購物車中並結帳，預期結帳金額應等於其售價 100 * 5 * 0.75
        /// </summary>
        [TestMethod]
        public void Test_add_5_different_books_to_cart_then_checkout_total_should_be_equal_sell_price_25_percent_save_off()
        {
            // Arrange
            var book_1 = new Book { Id = 1, Name = "Harry Potter and the Philosopher's Stone", SellPrice = 100 };
            var book_2 = new Book { Id = 2, Name = "Harry Potter and the Chamber of Secrets", SellPrice = 100 };
            var book_3 = new Book { Id = 3, Name = "Harry Potter and the Prisoner of Azkaban", SellPrice = 100 };
            var book_4 = new Book { Id = 4, Name = "Harry Potter and the Goblet of Fire", SellPrice = 100 };
            var book_5 = new Book { Id = 5, Name = "Harry Potter and the Order of the Phoenix", SellPrice = 100 };
            var expected = (book_1.SellPrice + book_2.SellPrice + book_3.SellPrice + book_4.SellPrice + book_5.SellPrice) * 0.75;

            var target = new Cart();
            target.Add(book_1);
            target.Add(book_2);
            target.Add(book_3);
            target.Add(book_4);
            target.Add(book_5);
            target.Checkout();

            // Act
            var actual = target.Total;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
