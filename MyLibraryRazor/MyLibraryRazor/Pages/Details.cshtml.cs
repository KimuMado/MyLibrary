using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyLibraryRazor.Data;
using MyLibraryRazor.Model;

namespace MyLibraryRazor.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly MyLibraryRazor.Data.MyLibraryRazorContext _context;

        public DetailsModel(MyLibraryRazor.Data.MyLibraryRazorContext context)
        {
            _context = context;
        }

        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Book
                .Include(b => b.Publisher).FirstOrDefaultAsync(m => m.BookId == id);

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
