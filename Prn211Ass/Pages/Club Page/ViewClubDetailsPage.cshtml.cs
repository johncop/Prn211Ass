using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Models;
using Repository.Repository;

namespace Prn211Ass.Pages.Club_Page
{
    public class ViewClubDetailsModel : PageModel
    {
        private readonly TblAdminRepository _TblAdminrepository;
        private readonly TblEventRepository _TblEventRepository;
        private readonly TblCategoryRepository _TblCategoryRepository;
        private readonly TblLocationRepository _TblLocationRepository;
        public ViewClubDetailsModel(TblAdminRepository TblAdminrepository, TblEventRepository TblEventRepository, TblCategoryRepository TblCategoryRepository, TblLocationRepository tblLocationRepository)
        {
            _TblAdminrepository = TblAdminrepository;
            _TblEventRepository = TblEventRepository;
            _TblCategoryRepository = TblCategoryRepository;
            _TblLocationRepository = tblLocationRepository;
        }
        [BindProperty]
        public TblAdmin TblAdmin { get; set; } = default!;
        public TblEvent tblEvent { get; set; } = default!;
        public TblCategory tblCategory { get; set; } = default!;
        public TblLocation tblLocation { get; set; } = default!;
        public IActionResult OnGet(int id)
        {

            tblEvent = _TblEventRepository.GetById(id);
            TblAdmin = _TblAdminrepository.GetById((int)tblEvent.AdminId);
            tblCategory = _TblCategoryRepository.GetById((int)tblEvent.CategoryId);
            tblLocation = _TblLocationRepository.GetById((int)tblEvent.LocationId);
            if (TblAdmin == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
