using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Models;
using Repository.Repository;

namespace Prn211Ass.Pages.Club_Page
{
    public class DeleteEventPageModel : PageModel
    {
        private readonly TblEventRepository _TblEventRepository;
        private readonly TblAdminRepository _TblAdminrepository;
        private readonly TblCategoryRepository _TblCategoryRepository;
        private readonly TblLocationRepository _TblLocationRepository;
        private readonly TblEventParticipatedRepository _TblEventParticipatedRepository;
        public DeleteEventPageModel(TblAdminRepository TblAdminrepository, TblEventRepository TblEventRepository, TblCategoryRepository tblCategoryRepository, TblLocationRepository tblLocationRepository, TblEventParticipatedRepository tblEventParticipatedRepository)
        {
            _TblAdminrepository = TblAdminrepository;
            _TblEventRepository = TblEventRepository;
            _TblCategoryRepository = tblCategoryRepository;
            _TblLocationRepository = tblLocationRepository;
            _TblEventParticipatedRepository = tblEventParticipatedRepository;
        }
        [BindProperty]
        public TblAdmin tblAdmin { get; set; } = default!;
        public TblEvent tblEvent { get; set; } = default!;
        public IList<TblEventParticipated> tblEventParticipated { get; set; } = default!;
        public IActionResult OnGet(int id)
        {
            tblEventParticipated = _TblEventParticipatedRepository.GetEventParticipatedById(id).ToList();
            tblEvent = _TblEventRepository.GetById(id);
            foreach(var item in tblEventParticipated)
            {
                _TblEventParticipatedRepository.Delete(item);
            }
           _TblEventRepository.Delete(tblEvent);
            return Page();
        }
    }
}
