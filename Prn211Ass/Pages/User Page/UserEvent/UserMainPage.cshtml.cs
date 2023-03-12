using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Repository.Repository;

namespace eventSchedule.Pages.Event
{
    public class IndexUserModel : PageModel
    {
        public string UserName { get; private set; }
        public int UserId { get; set; }

        private readonly TblEventRepository _eventRepo;
        private readonly Repository.Models.EventScheduleContext _context;

        public IndexUserModel(TblEventRepository repo, Repository.Models.EventScheduleContext context)
        {
            _eventRepo = repo;
            _context = context;
        }

        public IList<TblEvent> TblEvent { get;set; } = default!;
        public IList<TblUser> TblUser { get; set; } = default!;
        public IList<TblCategory> TblCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string UserName)
        {
            TblCategory = await _context.TblCategories.ToListAsync();

            this.UserName = UserName;
            if (_context.TblEvents != null)
            {
                TblEvent = await _context.TblEvents
                .Include(t => t.Admin)
                .Include(t => t.Category)
                .Include(t => t.Location).ToListAsync();
            }
            else
            {
                TblEvent = _eventRepo.GetAll().ToList();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? categoryId, string searchString)
{
    if (categoryId == null && string.IsNullOrEmpty(searchString))
    {
        // If no category is selected and search string is null or empty, return all events
        TblEvent = await _context.TblEvents
            .Include(t => t.Admin)
            .Include(t => t.Category)
            .Include(t => t.Location)
            .ToListAsync();
    }
    else if (categoryId != null)
    {
        // Filter events by category
        TblEvent = await _context.TblEvents
            .Include(t => t.Admin)
            .Include(t => t.Category)
            .Include(t => t.Location)
            .Where(t => t.CategoryId == categoryId)
            .ToListAsync();
    }
    else if (!string.IsNullOrEmpty(searchString))
    {
        // Filter events by search string
        TblEvent = await _context.TblEvents
            .Include(t => t.Admin)
            .Include(t => t.Category)
            .Include(t => t.Location)
            .Where(t => t.EventName.Contains(searchString))
            .ToListAsync();
    }

    return Page();
}



    }
}
