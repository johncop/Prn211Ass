using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Repository.Repository;

namespace eventSchedule.Pages.Users.UserEvent
{
    public class Event : Controller
    {
        private readonly TblEventRepository _eventRepo;
        private readonly Repository.Models.EventScheduleContext _context;

        public Event(TblEventRepository repo, Repository.Models.EventScheduleContext context)
        {
            _eventRepo = repo;
            _context = context;
        }

        public IList<TblEvent> TblEvent { get; set; } = default!;
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> OnPostJoinEventAsync(int eventId)
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
        }

        /* [HttpPost]
         public IActionResult JoinEvent(int eventId)
         {
             var userId = User.Identity.Name;
             var user = _context.TblUsers.FirstOrDefault(u => u.UsersEmail == userId);

             if (user == null)
             {
                 return BadRequest("User not found.");
             }

             var participatedEvent = _context.TblEventParticipateds.FirstOrDefault(ep => ep.UsersId == user.UsersId && ep.EventId == eventId);

             if (participatedEvent != null)
             {
                 return BadRequest("User has already joined this event.");
             }

             var newParticipatedEvent = new TblEventParticipated
             {
                 UsersId = user.UsersId,
                 EventId = eventId,
                 PaymentStatus = false,
                 DateParticipated = DateTime.Now,
                 UsersStatus = true
             };

             _context.TblEventParticipateds.Add(newParticipatedEvent);
             _context.SaveChanges();

             return Ok();
         }*/

    }
}
