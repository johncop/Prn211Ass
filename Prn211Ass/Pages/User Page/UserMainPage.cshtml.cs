using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Models;
using Repository.Repository;

namespace Prn211Ass.Pages
{
    public class UserMainPageModel : PageModel
    {
        private readonly TblAdminRepository _TblAdminrepository;
        private readonly TblEventRepository _TblEventRepository;
        public UserMainPageModel(TblAdminRepository TblAdminrepository, TblEventRepository TblEventRepository)
        {
            _TblAdminrepository = TblAdminrepository;
            _TblEventRepository = TblEventRepository;
        }
        [BindProperty]
        public TblAdmin TblAdmin { get; set; } = default!;
        public IList<TblEvent> tblEvent { get; set; } = default!;
        public IActionResult OnGet(int id)
        {


            tblEvent = _TblEventRepository.GetAll().ToList();

            return Page();
        }
    }
}
