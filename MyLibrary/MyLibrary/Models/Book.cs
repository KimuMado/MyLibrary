using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Models
{
    public class Book
    {
        //Primary key
        public int BookId { get; set; }
        
        public string Title { get; set; }
        
        public string Subtitle { get; set; }

        public string LeadSentence { get; set; }

        public DateTime PublishDate { get; set; }

        //カバー画像のURL
        public string ImageUrl { get; set; }

        //著者（複数の場合もある）
        public ICollection<Author> Authors { get; set; }

        //出版レーベル
        public Publisher Publisher { get; set; }
    }

    public class Author
    {
        //Primary key
        public int AuthorId { get; set; }

        public string Name { get; set; }
        
        //著書
        public ICollection<Book> Books { get; set; }
    }

    public class Publisher
    {
        //Primary key
        public int PublisherId { get; set; }

        public string Label { get; set; }

        //出版書籍
        public ICollection<Book> Books { get; set; }
    }
}
