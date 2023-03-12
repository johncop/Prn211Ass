using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Models;
using Repository.Repository;

namespace Prn211Ass.Pages.User_Page.UserEvent
{
    public class JoinedEventCheckModel : PageModel
    {

        public JoinedEventCheckModel(TblEventParticipatedRepository tblEventParticipatedRepository)
        {

            _TblEventParticipatedRepository = tblEventParticipatedRepository;
        }
        public TblEventParticipated tblEventParticipated { get; set; } = default!;
        public IActionResult OnGet(int id)
        {
            tblEventParticipated = new TblEventParticipated();
            string loginUserId = HttpContext.Session.GetString("users_id");
            DateTime dateJoined = DateTime.Now;
            tblEventParticipated.EventId = id;
            tblEventParticipated.UsersId = int.Parse(loginUserId);
            tblEventParticipated.DateParticipated = dateJoined;
            tblEventParticipated.PaymentStatus = false;
            tblEventParticipated.UsersStatus= false;
            _TblEventParticipatedRepository.Create(tblEventParticipated);
            return Page();
        }
    }
}
