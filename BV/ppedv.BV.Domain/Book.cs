using System;

namespace ppedv.BV.Domain
{
    public class Book : Entity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public DateTime PublishedDate { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
    }

}
