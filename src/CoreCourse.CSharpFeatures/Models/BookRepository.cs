using System.Collections;
using System.Collections.Generic;

namespace CoreCourse.CSharpFeatures.Models
{
    public class BookRepository : IEnumerable<Book>
    {
        public IEnumerable<Book> Books { get; set; }

        public IEnumerator<Book> GetEnumerator()
        {
            return this.Books.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }
}

