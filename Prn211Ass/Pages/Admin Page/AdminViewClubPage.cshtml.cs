using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Models;
using Repository.Repository;

namespace Prn211Ass.Pages.Admin_Page
{
    public class AdminViewClubPageModel : PageModel
    {
        private readonly TblAdminRepository _TblAdminrepository;
        private readonly TblEventRepository _TblEventRepository;
        public AdminViewClubPageModel(TblAdminRepository TblAdminrepository, TblEventRepository TblEventRepository)
        {
            _TblAdminrepository = TblAdminrepository;
            _TblEventRepository = TblEventRepository;
        }
        [BindProperty]
        public TblAdmin TblAdmin { get; set; } = default!;
        public IList<TblEvent> tblEvent { get; set; } = default!;
        public IActionResult OnGet(int id)
        {

            var Admin = _TblAdminrepository.GetById(id);
            tblEvent = _TblEventRepository.GetEventsByAdminId(id).ToList();
            if (Admin == null)
            {
                return NotFound();
            }
            TblAdmin = Admin;
            return Page();
        }
    }
}
