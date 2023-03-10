using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Models;
using Repository.Repository;

namespace Prn211Ass.Pages.Admin_Page
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
        public TblAdmin TblAdmin { get; set; } = default!;
        public TblEvent tblEvent { get; set; } = default!;
        public IList<TblUser> TblUser { get; set; } = new List<TblUser>();
        public IList<TblEventParticipated> TblEventParticipated { get; set; } = default!;

        public IActionResult OnGet(int id)
        {

            TblAdmin = _TblAdminrepository.GetById(id);
            tblEvent = _TblEventRepository.GetEventByAdminId(id);
            TblEventParticipated = _TblEventParticipatedRepository.GetEventParticipatedById(tblEvent.EventId).ToList();
            foreach(var eventpart in TblEventParticipated)
            {
                var user = _TblUserRepository.GetById(eventpart.UsersId);
                TblUser.Add(user);
            }

            if (TblAdmin == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
