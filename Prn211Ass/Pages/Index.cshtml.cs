using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Models;
using Repository.Repository;
using Microsoft.AspNetCore.Http;

namespace Prn211Ass.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TblAdminRepository _TblAdminrepository;
        public IndexModel(TblAdminRepository TblAdminrepository)
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