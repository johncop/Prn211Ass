using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Models;
using Repository.Repository;

namespace Prn211Ass.Pages.Club_Page
{
    public class EditEventPageModel : PageModel
    {
        private readonly TblEventRepository _TblEventRepository;
        private readonly TblAdminRepository _TblAdminrepository;
        private readonly TblCategoryRepository _TblCategoryRepository;
        private readonly TblLocationRepository _TblLocationRepository;

        public EditEventPageModel(TblAdminRepository TblAdminrepository, TblEventRepository TblEventRepository, TblCategoryRepository tblCategoryRepository, TblLocationRepository tblLocationRepository)
        {
            _TblAdminrepository = TblAdminrepository;
            _TblEventRepository = TblEventRepository;
            _TblCategoryRepository = tblCategoryRepository;
            _TblLocationRepository = tblLocationRepository;
        }
        [BindProperty]
        public TblAdmin tblAdmin { get; set; } = default!;
        public TblEvent tblEvent { get; set; } = default!;
        public IList<TblCategory> tblCategory { get; set; } = default!;
        public IList<TblLocation> tblLocation { get; set; } = default!;
        public IActionResult OnGet(int id)
        {
            tblEvent = _TblEventRepository.GetById(id);
            tblAdmin = _TblAdminrepository.GetById(tblEvent.AdminId);
            tblCategory = _TblCategoryRepository.GetAll().ToList();
            tblLocation = _TblLocationRepository.GetAll().ToList();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            tblEvent = new TblEvent();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            tblEvent.EventId = id;
            tblEvent.AdminId= int.Parse(Request.Form["tblAdmin.AdminId"]);
            tblEvent.EventStatus = false;
            tblEvent.EventName = Request.Form["tblEvent.EventName"];
            tblEvent.EventContent = Request.Form["tblEvent.EventContent"];
            tblEvent.EventStart = DateTime.Parse(Request.Form["tblEvent.EventStart"]);
            tblEvent.CategoryId = int.Parse(Request.Form["tblEvent.CategoryId"]);
            tblEvent.LocationId = int.Parse(Request.Form["tblEvent.LocationId"]);
            tblEvent.EventEnd = DateTime.Parse(Request.Form["tblEvent.EventEnd"]);
            _TblEventRepository.Update(tblEvent);

            return RedirectToPage("/Club Page/ClubMainPage");
        }
    }
}
