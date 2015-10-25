using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart
{
    public class Cart
    {
        public int Total { get; private set; }

        protected IList<Book> books;

        public Cart()
        {
            books = new List<Book>();
        }

        public void Add(Book book)
        {
            books.Add(book);
        }

        public void Checkout()
        {
            Total = books.Sum(x => x.SellPrice);
        }
    }
}
