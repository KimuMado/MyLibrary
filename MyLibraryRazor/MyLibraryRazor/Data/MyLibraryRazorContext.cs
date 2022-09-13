using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyLibraryRazor.Model;

namespace MyLibraryRazor.Data
{
    public class MyLibraryRazorContext : DbContext
    {
        public MyLibraryRazorContext (DbContextOptions<MyLibraryRazorContext> options)
            : base(options)
        {
        }

        public DbSet<MyLibraryRazor.Model.Book> Book { get; set; }

        public DbSet<MyLibraryRazor.Model.Author> Author { get; set; }

        public DbSet<MyLibraryRazor.Model.Publisher> Publisher { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
                .HasKey(t => new { t.BookId, t.AuthorId });

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.AuthorId);
        }
    }
}
