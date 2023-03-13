using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Models;
using Repository.Repository;

namespace Prn211Ass.Pages.User_Page
{
    public class LoginUserModel : PageModel
    {
        [BindProperty]
        public TblUser tbluser { get; set; }
        [BindProperty]
        public string Message { get; set; }
        private readonly TblUserRepository _repository;

        public LoginUserModel(TblUserRepository repository)
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
                        .Where(p => p.UsersEmail.Equals(tbluser.UsersEmail)
                        && p.UsersPassword.Equals(tbluser.UsersPassword)).FirstOrDefault();
            //vo trang management
            //show messsage loi
            if (check != null)
            {
                //khoi tao session de kiem tra login ben index
                HttpContext.Session.SetString("users_email", check.UsersEmail);
                HttpContext.Session.SetString("user_name", check.UsersName);
                HttpContext.Session.SetString("users_id", check.UsersId.ToString());
                return RedirectToPage("UserMainPage", "UserPageLogin", new { UserName = check.UsersName });
            }
            else
            {
                Message = "User name or password is incorrect! Please try again";
                return Page();
            }
        }
    }
}
