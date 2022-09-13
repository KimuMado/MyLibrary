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

        //著者・訳者・編者（一人のみ対応）
        [Display(Name="著者")]
        public Author Author { get; set; }

        //出版レーベル
        public int PublisherId { get; set; }
        [Display(Name="出版レーベル")]
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

        //著書リスト
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
