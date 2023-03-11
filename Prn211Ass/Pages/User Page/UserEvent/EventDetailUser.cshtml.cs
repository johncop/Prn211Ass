using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace eventSchedule.Pages.Event
{
    public class EventDetailUser : PageModel
    {
        private readonly EventScheduleContext _context;

        public EventDetailUser(EventScheduleContext context)
        {
            _context = context;
        }

        public TblEvent TblEvent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TblEvents == null)
            {
                return NotFound();
            }

            var tblevent = await _context.TblEvents
                .Include(e => e.Category)
                .Include(e => e.Location)
                .Include(e => e.Admin)
                .FirstOrDefaultAsync(m => m.EventId == id);

            if (tblevent == null)
            {
                return NotFound();
            }

            TblEvent = tblevent;
            return Page();
        }
    }

}
