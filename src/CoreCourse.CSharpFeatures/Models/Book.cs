
namespace CoreCourse.CSharpFeatures.Models
{
    public class Book
    {
        public string Title { get; set; }
        public int? Pages { get; set; }
        public string Genre { get; set; } = "Novel";
        public bool IsLent { get; }
        public Book Sequel { get; set; }

        public Book(bool islent = false)
        {
            IsLent = islent;
        }

        public static Book[] GetAll()
        {
            Book lotr3 = new Book {
                Title = "The Return of the King",
                Pages = 490,
                Genre = "Fantasy",
                Sequel = null
            };
            Book lotr2 = new Book(true) {
                Title = "The Two Towers",
                Pages = 322,
                Genre = "Fantasy",
                Sequel = lotr3
            };
            Book lotr1 = new Book {
                Title = "The Fellowship of the Ring",
                Pages = 398,
                Genre = "Fantasy",
                Sequel = lotr2
            };
            Book littleprince = new Book(true) {
                Title = "The Little Prince",
                Pages = 83,
                Sequel = null
            };
            Book warandpeace = new Book {
                Title = "War and Peace",
                Pages = 1392,
                Sequel = null
            };
            Book programming = new Book {
                Title = "C# Programming",
                Pages = null,
                Genre = "Programming",
                Sequel = null
            };
            return new Book[] { lotr1, lotr2, lotr3, littleprince, programming, warandpeace, null };
        }
    }
}
