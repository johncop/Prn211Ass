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

        public async Task<IActionResult> OnGetAsync(string UserName)
        {
            this.UserName = UserName;
            /*if (HttpContext.Session.GetString("users_email") == null)
            {
                return RedirectToPage("./loginForUser");
            }*/
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

        public async Task<IActionResult> OnPostAsync(string searchString)
        {
            // Get all events if the search string is null or empty
            if (string.IsNullOrEmpty(searchString))
            {
                TblEvent = await _context.TblEvents.ToListAsync();
            }
            else
            {
                TblEvent = await _context.TblEvents.Where(e => e.EventName.Contains(searchString)).ToListAsync();
            }

            return Page();
        }


        /*public async Task<IActionResult> OnPostJoinEventAsync(int eventId)
        {
            var userEmail = HttpContext.Session.GetString("users_email");
            if (userEmail == null)
            {
                return RedirectToPage("/LoginForUser");
            }

            var user = await _context.TblUsers.FirstOrDefaultAsync(u => u.UsersEmail == userEmail);
            if (user == null)
            {
                return NotFound();
            }

            var @event = await _context.TblEvents.FindAsync(eventId);
            if (@event == null)
            {
                return NotFound();
            }

            if (_context.TblEventParticipateds.Any(je => je.EventId == eventId && je.UsersId == user.UsersId))
            {
                // User has already joined the event
                return new JsonResult("Already joined");
            }

            // Add the user to the JoinedEvents table
            var joinedEvent = new TblEventParticipated
            {
                EventId = eventId,
                UsersId = user.UsersId,
                DateParticipated = DateTime.Now,
                PaymentStatus = false,
                UsersStatus = true
            };
            _context.TblEventParticipateds.Add(joinedEvent);
            await _context.SaveChangesAsync();

            return new JsonResult("Success");
        }*/

    }
}
