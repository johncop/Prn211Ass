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
    public class IndexModel : PageModel
    {
        private readonly Repository.Models.EventScheduleContext _context;

        public IndexModel(Repository.Models.EventScheduleContext context)
        {
            _context = context;
        }

        public IList<TblUser> TblUser { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TblUsers != null)
            {
                TblUser = await _context.TblUsers.ToListAsync();
            }
        }
    }
}
