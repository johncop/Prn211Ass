using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Models;
using Repository.Repository;

namespace Prn211Ass.Pages.Club_Page
{
    public class ClubMainPageModel : PageModel
    {
        private readonly TblEventRepository _TblEventRepository;
        private readonly TblAdminRepository _TblAdminrepository;
        public ClubMainPageModel(TblAdminRepository TblAdminrepository, TblEventRepository TblEventRepository)
        {
            _TblAdminrepository = TblAdminrepository;
            _TblEventRepository = TblEventRepository;
        }
        [BindProperty]
        public TblAdmin tblAdmin { get; set; } = default!;
        public IList<TblEvent> tblEvent { get; set; } = default!;

        public IActionResult OnGet()
        {
            string id = HttpContext.Session.GetString("LOGIN_USER_ID");
            var Admin = _TblAdminrepository.GetById(int.Parse(id));
            tblEvent = _TblEventRepository.GetEventsByAdminId(int.Parse(id)).ToList();
            if (Admin == null)
            {
                return NotFound();
            }
            tblAdmin = Admin;
            return Page();
        }
    }
}
