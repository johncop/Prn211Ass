using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Models;
using Repository.Repository;

namespace Prn211Ass.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public TblAdmin Admin { get; set; }
        [BindProperty]
        public string Message { get; set; }
        private readonly TblAdminRepository _repository;

        public LoginModel(TblAdminRepository repository)
        {
            _repository = repository;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            //kiem tra username pass validate, role 
            var check = _repository.GetAll()
                        .Where(p => p.AdminEmail.Equals(Admin.AdminEmail)
                        && p.AdminPassword.Equals(Admin.AdminPassword)).FirstOrDefault();
            //vo trang management
            //show messsage loi
            if (check != null)
            {
                //khoi tao session de kiem tra login ben index
                //HttpContext.Session.SetString("Email", check.AdminEmail);
                HttpContext.Session.SetString("LOGIN_USER", check.AdminRole);
                HttpContext.Session.SetString("LOGIN_USER_ID", check.AdminId.ToString());
                if (check.AdminRole.Equals("admin"))
                {

                    return RedirectToPage("./AdminMainPage");
                }else
                if (check.AdminRole.Equals("club"))
                {

                    return RedirectToPage("/Club Page/ClubMainPage");
                }
                else
                {
                    return Page();
                }
            }
            else
            {
                Message = "Permission denied";
                return Page();
            }
        }
    }
}
