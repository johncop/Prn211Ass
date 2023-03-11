using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Repository.Repository;

namespace eventSchedule.Pages.Event
{
    public class JoinedEventModel : PageModel
    {
        private readonly TblEventRepository _eventRepo;
        private readonly Repository.Models.EventScheduleContext _context;
        public JoinedEventModel(TblEventRepository repo, Repository.Models.EventScheduleContext context)
        {
            _eventRepo = repo;
            _context = context;
        }

        public IList<TblEventParticipated> TblEventParticipated { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            if (HttpContext.Session.GetString("users_email") == null)
            {
                return RedirectToPage("/LoginForUser");
            }
            TblEventParticipated = await _context.TblEventParticipateds
                .Include(t => t.Event)
                .Include(t => t.Event.Admin)
                .Include(t => t.Event.Category)
                .Include(t => t.Event.Location)
                .Where(t => t.Users.UsersEmail == HttpContext.Session.GetString("users_email"))
                .ToListAsync();
            return Page();
        }
    }
}