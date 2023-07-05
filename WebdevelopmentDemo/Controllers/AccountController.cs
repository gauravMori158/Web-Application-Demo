using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebdevelopmentDemo.Models;
using WebdevelopmentDemo.Interface;

namespace WebdevelopmentDemo.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUserRepo _userRepo;

        public List<User> users = null;
        public AccountController(ILogger<AccountController> logger, IUserRepo userRepo)
        {
            this._logger = logger;
            this._userRepo = userRepo;
            users = _userRepo.GetAlluser();

        }

        public IActionResult Login(string returnurl = "/")
        {
            LoginModel loginModel = new LoginModel();
            loginModel.ReturnUrl = returnurl;
            return View(loginModel);
        }



        [HttpPost]

        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var user = users.Where(u => u.FirstName == loginModel.UserName && u.Password == loginModel.Password).FirstOrDefault();

            if (user != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim (ClaimTypes.NameIdentifier,Convert.ToString(user.Id)),
                    new Claim (ClaimTypes.Name, user.FirstName),
                    new Claim(ClaimTypes.Role , user.Roles.RoleName),
                    new Claim("RoleBased","Code")
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                    new AuthenticationProperties()
                    {
                        IsPersistent = loginModel.RememberLogin
                    }

                   );

                return LocalRedirect(loginModel.ReturnUrl);


            }
            else
            {
                ViewBag.Message = "Invalid Credentials";
                return View(loginModel);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/");

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
