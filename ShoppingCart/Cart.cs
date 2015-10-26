using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart
{
    public class Cart
    {
        public double Total { get; private set; }

        protected IList<Book> books;

        public Cart()
        {
            books = new List<Book>();
            Total = 0;
        }

        public void Add(Book book)
        {
            books.Add(book);
        }

        public void Checkout()
        {
            var distinct = books.Distinct().ToList();
            if (books.Count == distinct.Count)
            {
                switch (books.Count)
                {
                    case 1:
                        Total = books.Sum(x => x.SellPrice);
                        break;
                    case 2:
                        Total = books.Sum(x => x.SellPrice) * 0.95;
                        break;
                    case 3:
                        Total = books.Sum(x => x.SellPrice) * 0.9;
                        break;
                    case 4:
                        Total = books.Sum(x => x.SellPrice) * 0.8;
                        break;
                    default:
                        break;
                }
            }
            else
            {

            }
        }
    }
}
