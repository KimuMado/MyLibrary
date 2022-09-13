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

        [Display(Name = "タイトル")]
        public string Title { get; set; }

        [Display(Name = "サブタイトル")]
        public string Subtitle { get; set; }

        [Display(Name = "Leading phrases")]
        public string LeadSentence { get; set; }

        [Display(Name = "出版年月")]
        public DateTime PublishDate { get; set; }

        //カバー画像のURL
        [Display(Name = "カバー画像のURL")]
        public string ImageUrl { get; set; }

        //著者・訳者・編者（複数の場合あり）
        [Display(Name="著者・訳者・編者")]
        public List<BookAuthor> BookAuthors { get; set; }

        //出版レーベル
        [Display(Name="出版レーベル")]
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
    }

    public class Author
    {
        //Primary key
        public int AuthorId { get; set; }

        [Display(Name="名前")]
        public string Name { get; set; }

        [Display(Name="アルファベット表記（Family First）")]
        public string SortName { get; set; }
        public List<BookAuthor> BookAuthors { get; set; }
    }

    public class Publisher
    {
        //Primary key
        public int PublisherId { get; set; }

        public string Label { get; set; }
        
        public string Company { get; set; }

        public ICollection<Book> Books { get; set; }
    }

    //多対多リレーションのための結合エンティティ
    public class BookAuthor
    {
        public DateTime PublicationDate { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }
    }
}
