using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace eventSchedule.Pages.Users.UserAccount
{
    public class DeleteModel : PageModel
    {
        private readonly Repository.Models.EventScheduleContext _context;

        public DeleteModel(Repository.Models.EventScheduleContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TblUser TblUser { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TblUsers == null)
            {
                return NotFound();
            }

            var tbluser = await _context.TblUsers.FirstOrDefaultAsync(m => m.UsersId == id);

            if (tbluser == null)
            {
                return NotFound();
            }
            else 
            {
                TblUser = tbluser;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TblUsers == null)
            {
                return NotFound();
            }
            var tbluser = await _context.TblUsers.FindAsync(id);

            if (tbluser != null)
            {
                TblUser = tbluser;
                _context.TblUsers.Remove(TblUser);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
