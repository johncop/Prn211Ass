using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Repository.Repository;

namespace Prn211Ass.Pages.Club_Page
{
    public class ViewUserParticipatedModel : PageModel
    {
        private readonly TblAdminRepository _TblAdminrepository;
        private readonly TblEventRepository _TblEventRepository;
        private readonly TblEventParticipatedRepository _TblEventParticipatedRepository;
        private readonly TblUserRepository _TblUserRepository;
        public ViewUserParticipatedModel(TblAdminRepository TblAdminrepository, TblEventRepository TblEventRepository, TblUserRepository tblUserRepository, TblEventParticipatedRepository tblEventParticipatedRepository)
        {
            _TblAdminrepository = TblAdminrepository;
            _TblEventRepository = TblEventRepository;
            _TblUserRepository = tblUserRepository;
            _TblEventParticipatedRepository= tblEventParticipatedRepository;
        }
        [BindProperty]
        public TblAdmin tblAdmin { get; set; } = default!;
        public TblEvent tblEvent { get; set; } = default!;
        public IList<TblUser> TblUser { get; set; } = new List<TblUser>();
        public TblEventParticipated tblUserJoinEvent { get; set; }
        public IList<TblEventParticipated> TblEventParticipated { get; set; } = default!;

        public IActionResult OnGet(int id)
        {

            tblEvent = _TblEventRepository.GetById(id);
            tblAdmin = _TblAdminrepository.GetById((int)tblEvent.AdminId);
            TblEventParticipated = _TblEventParticipatedRepository.GetEventParticipatedById(tblEvent.EventId).ToList();
            foreach(var eventpart in TblEventParticipated)
            {
                var user = _TblUserRepository.GetById(eventpart.UsersId);
                TblUser.Add(user);
            }

            if (tblAdmin == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPost(int id)
        {
            int userId = Convert.ToInt32(Request.Form["userid"]);
            if (userId == null || _TblUserRepository == null)
            {
                return NotFound();
            }
            var tbluser = _TblUserRepository.GetById(userId);
            var tbleventparticipated = _TblEventParticipatedRepository.GetEventParticipatedByEventIdAndUserId(userId, id);
            if (tbluser != null)
            {

                _TblEventParticipatedRepository.Delete(tbleventparticipated);
            }

            return RedirectToPage("./ViewUserParticipatedPage",new { id = id });
        }
    }
}
