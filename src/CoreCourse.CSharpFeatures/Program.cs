using CoreCourse.CSharpFeatures.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CoreCourse.CSharpFeatures
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");

            List<string> bookInfos = new List<string>();

            foreach (Book book in Book.GetAll())
            {
                string title = book?.Title ?? "[untitled book]";
                int? pages = book?.Pages ?? 0;
                string sequelTitle = book?.Sequel?.Title ?? "[no sequels]";
                bookInfos.Add($"Title: {title}, Pages: {pages:N0}, Sequel: {sequelTitle}");
            }

            BookRepository bookRepository = new BookRepository { Books = Book.GetAll() };

            //calculate total number of pages
            int totalPages = bookRepository.TotalPages();
            bookInfos.Add($"\r\nTotal pages in repository: {totalPages:N0}");

            var knownBooks = Book.GetAll();

            //calculate total pages of all known books
            int numberOfknownBooksWithOver350p = knownBooks.Count(p => (p?.Pages ?? 0) > 350);
            int numberOfknownBooksWithLetterT = knownBooks.Count(p => p?.Title?[0] == 'T');
            int numberOfKnownBooksLentOut = knownBooks.Count(p => p?.IsLent == true);
            string firstBookLent = knownBooks.FirstOrDefault(p => p?.IsLent == true)?.Title;
            IEnumerable<string> lentOutKnownBooks =
                knownBooks.Where(p => p?.IsLent == true).Select(p => p.Title);
            
            bookInfos.Add($"# books with > 350 pages: {numberOfknownBooksWithOver350p:N0}");
            bookInfos.Add($"# books starting with 'T': {numberOfknownBooksWithLetterT:N0}");
            bookInfos.Add($"# books lent out: {numberOfKnownBooksLentOut:N0}");
            bookInfos.Add($"\r\nFirst book lent out = {firstBookLent}");

            foreach (string title in lentOutKnownBooks)
                bookInfos.Add($">> Lent Out: {title}");
            
            PrintStrings(bookInfos);

            //prevent quitting in debug mode
            Console.WriteLine("\n\rPress any key to exit");
            Console.Read();
        }

        static void PrintStrings(IEnumerable<string> strings)
        {
            foreach (var s in strings)
            {
                Console.WriteLine(s);
            }
        }
    }

}