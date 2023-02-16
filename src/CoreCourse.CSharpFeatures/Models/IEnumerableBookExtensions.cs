using System;
using System.Collections;
using System.Collections.Generic;

namespace CoreCourse.CSharpFeatures.Models
{
    public static class IEnumerableBookExtensions
    {
        public static int TotalPages(this IEnumerable<Book> bookCollection)
        {
            int totalPages = 0;
            foreach (Book book in bookCollection)
                totalPages += book?.Pages ?? 0;

            return totalPages;
        }

        //public static IEnumerable<Book> GetByFilter(
        //    this IEnumerable<Book> bookCollection, Func<Book, bool> selector)
        //{
        //    foreach (Book book in bookCollection)
        //        if (selector(book))
        //            yield return book;
        //}
    }
}

