using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookList
{
    internal class Book
    {
        public Book(int ISBN, string title, string author, string category)
        {
            this.ISBN = ISBN;
            this.Title = title;
            this.Author = author;
            this.Category = category;
        }

        public int ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }

        public override string ToString()
        {
            return $"ISBN: {ISBN}\nTítulo: {Title}\nAutor: {Author}" +
                $"\nCategoria: {Category}";
        }
    }
}
