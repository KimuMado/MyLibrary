using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyLibraryRazor.Data;
using MyLibraryRazor.Model;

namespace MyLibraryRazor.Pages
{
    public class CreateModel : PageModel
    {
        private readonly MyLibraryRazor.Data.MyLibraryRazorContext _context;

        public CreateModel(MyLibraryRazor.Data.MyLibraryRazorContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["AuthorList"] = new SelectList(_context.Author, "AuthorId", "Name");
            Publishers = new List<Publisher>(_context.Publisher);
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        [BindProperty]
        public Publisher Publisher { get; set; }

        [DataType(DataType.Text)]
        public string PublisherInputStr { get; set; } = "";

        public IList<Publisher> Publishers { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPublisherPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Publisher.Add(Publisher);
            await _context.SaveChangesAsync();

            return Page();
        }
    }
}
