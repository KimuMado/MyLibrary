using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyLibraryRazor.Model
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

        //著者・訳者・編者（複数の場合あり）
        [Display(Name ="Author")]
        public ICollection<Author> Authors { get; set; }

        //出版レーベル
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
    }

    public class Author
    {
        //Primary key
        public int AuthorId { get; set; }

        public string Name { get; set; }

        public string SortName { get; set; }

        public ICollection<Book> Books { get; set; }
    }

    public class Publisher
    {
        //Primary key
        public int PublisherId { get; set; }

        public string Label { get; set; }
        
        public string Company { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
