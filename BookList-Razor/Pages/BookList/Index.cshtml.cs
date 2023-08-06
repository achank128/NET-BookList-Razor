using BookList_Razor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookList_Razor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        public readonly ApplicationDBContext _db;

        public IndexModel(ApplicationDBContext db)
        {
            _db = db;
        }

        public IEnumerable<Book> Books { get; set; }

        public async Task OnGet()
        {
            Books = await _db.Book.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            if (ModelState.IsValid)
            {
                var BookDelete = await _db.Book.FindAsync(id);

                if(BookDelete == null)
                {
                    return NotFound();
                }
                _db.Book.Remove(BookDelete);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }

    }
}
