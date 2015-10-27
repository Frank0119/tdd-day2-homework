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
            var distinct = books.GroupBy(x => new { Id = x.Id, SellPrice = x.SellPrice }).Select(x => new GroupSet { ID = x.Key.Id, SellPrice = x.Key.SellPrice, Count = x.Count() }).ToList();
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
                    case 5:
                        Total = books.Sum(x => x.SellPrice) * 0.75;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Total = recursivePreferential(distinct);
            }
        }

        private double recursivePreferential(List<GroupSet> distinct)
        {
            var total = 0d;
            switch (distinct.Count())
            {
                case 1:
                    total = distinct.Sum(x => x.SellPrice);
                    break;
                case 2:
                    total = distinct.Sum(x => x.SellPrice) * 0.95;
                    break;
                case 3:
                    total = distinct.Sum(x => x.SellPrice) * 0.9;
                    break;
                case 4:
                    total = distinct.Sum(x => x.SellPrice) * 0.8;
                    break;
                case 5:
                    total = distinct.Sum(x => x.SellPrice) * 0.75;
                    break;
                default:
                    break;
            }

            for (int i = 0; i < distinct.Count; i++)
            {
                distinct[i].Count--;
            }

            distinct = distinct.Where(x => x.Count > 0).ToList();
            if (distinct.Count > 0)
            {
                return total + recursivePreferential(distinct);
            }
            else
            {
                return total;
            }
        }

        private class GroupSet
        {
            public int ID { get; set; }

            public double SellPrice { get; set; }

            public int Count { get; set; }
        }
    }
}
