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
    public class IndexModel : PageModel
    {
        private readonly MyLibraryRazor.Data.MyLibraryRazorContext _context;

        public IndexModel(MyLibraryRazor.Data.MyLibraryRazorContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }

        public async Task OnGetAsync()
        {
            Book = await _context.Book
                .Include(b => b.Authors)
                .Include(b => b.Publisher).ToListAsync();
        }
    }
}
