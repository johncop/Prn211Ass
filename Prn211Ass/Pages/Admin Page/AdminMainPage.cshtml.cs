using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Models;
using Repository.Repository;

namespace Prn211Ass.Pages.Admin_Page
{
    public class AdminMainPageModel : PageModel
    {
        private readonly TblAdminRepository _TblAdminrepository;
        public AdminMainPageModel(TblAdminRepository TblAdminrepository)
        {
            _TblAdminrepository = TblAdminrepository;
        }

        public IList<TblAdmin> TblAdmin { get; set; } = default!;

        public IActionResult OnGet()
        {

            TblAdmin = _TblAdminrepository.GetAll().ToList();
            return Page();
        }
    }
}
