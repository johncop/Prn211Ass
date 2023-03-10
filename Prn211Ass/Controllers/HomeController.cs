using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prn211Ass.Pages;
using Repository;
using Repository.Models;
using Repository.Repository;

namespace Prn211Ass.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public RepositoryBase<TblAdmin> _repo;
        public TblAdminRepository _AdminRepo;
        private string _StudentSessionKey = "studentKey";
        public HomeController(ILogger<HomeController> logger, RepositoryBase<TblAdmin> repo,
            TblAdminRepository AdminRepo)
        {
            _logger = logger;
            _repo = repo;
            _AdminRepo = AdminRepo;
        }
        public IActionResult Index()
        {
            var list = _repo.GetAll().ToList();

            return View(list);
        }


    }
}
