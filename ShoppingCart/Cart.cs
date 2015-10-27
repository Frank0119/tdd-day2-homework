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
            var distinct = books
                .GroupBy(x => new { Id = x.Id, SellPrice = x.SellPrice })
                .Select(x => new GroupSet { ID = x.Key.Id, SellPrice = x.Key.SellPrice, Count = x.Count() }).ToList();
            if (books.Count == distinct.Count)
            {
                Total = books.Sum(x => x.SellPrice) * this.getDiscount(books.Count);
            }
            else
            {
                while (distinct.Count > 0)
                {
                    Total += preferential(ref distinct);
                }
            }
        }

        private double getDiscount(int booksCount)
        {
            var result = 1.0;
            switch (booksCount)
            {
                    case 2:
                        result = 0.95;
                        break;
                    case 3:
                        result = 0.9;
                        break;
                    case 4:
                        result = 0.8;
                        break;
                    case 5:
                        result = 0.75;
                        break;
            }

            return result;
        }

        private double preferential(ref List<GroupSet> distinct)
        {
            var total = 0d;
            total = distinct.Sum(x => x.SellPrice) * this.getDiscount(distinct.Count);

            for (int i = 0; i < distinct.Count; i++)
            {
                distinct[i].Count--;
            }

            distinct = distinct.Where(x => x.Count > 0).ToList();

            return total;
        }

        private class GroupSet
        {
            public int ID { get; set; }

            public double SellPrice { get; set; }

            public int Count { get; set; }
        }
    }
}
