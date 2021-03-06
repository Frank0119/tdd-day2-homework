﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ShoppingCart;

namespace ShoppingCart.Tests
{
    [TestClass]
    public class CartTest
    {
        /// <summary>
        /// 加入一本書籍至購物車中並結帳，預期結帳金額應等於其售價 100
        /// </summary>
        [TestMethod]
        public void Test_add_1_book_to_cart_then_checkout_total_should_be_equal_sell_price()
        {
            // Arrange
            var book = new Book { Id = 1, Name = "Harry Potter and the Philosopher's Stone", SellPrice = 100 };
            var expected = 100;

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
            var expected = 190;

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
            var expected = 270;

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
            var expected = 320;

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
            var expected = 375;

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

        /// <summary>
        /// 一二集各買了一本，第三集買了兩本，預期結帳金額應等於其售價 100 * 3 * 0.9 + 100 * 1 * 1
        /// </summary>
        [TestMethod]
        public void Test_add_3_diff_1_same_books_to_cart_then_checkout_total_should_be_equal_370()
        {
            // Arrange
            var book_1 = new Book { Id = 1, Name = "Harry Potter and the Philosopher's Stone", SellPrice = 100 };
            var book_2 = new Book { Id = 2, Name = "Harry Potter and the Chamber of Secrets", SellPrice = 100 };
            var book_3 = new Book { Id = 3, Name = "Harry Potter and the Prisoner of Azkaban", SellPrice = 100 };
            var book_4 = new Book { Id = 3, Name = "Harry Potter and the Prisoner of Azkaban", SellPrice = 100 };
            var expected = 370;

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
        /// 第一集買了一本，第二三集各買了兩本，預期結帳金額應等於其售價 100 * 3 * 0.9 + 100 * 2 * 0.95 = 460
        /// </summary>
        [TestMethod]
        public void Test_add_3_diff_2_same_books_to_cart_then_checkout_total_should_be_equal_460()
        {
            // Arrange
            var book_1 = new Book { Id = 1, Name = "Harry Potter and the Philosopher's Stone", SellPrice = 100 };
            var book_2 = new Book { Id = 2, Name = "Harry Potter and the Chamber of Secrets", SellPrice = 100 };
            var book_3 = new Book { Id = 3, Name = "Harry Potter and the Prisoner of Azkaban", SellPrice = 100 };
            var book_4 = new Book { Id = 2, Name = "Harry Potter and the Chamber of Secrets", SellPrice = 100 };
            var book_5 = new Book { Id = 3, Name = "Harry Potter and the Prisoner of Azkaban", SellPrice = 100 };
            var expected = 460;

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
