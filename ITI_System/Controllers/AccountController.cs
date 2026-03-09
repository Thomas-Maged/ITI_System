using ITI_Entities.Data;
using ITI_Entities.Models;
using ITI_Entities.Repo;
using ITI_System.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ITI_System.Controllers
{
    public class AccountController : Controller
    {
        static ITI_Context db = new ITI_Context();
        AccountRepo accountRepo = new AccountRepo(db);
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.type = "Login";
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User model)
        {
            User user = accountRepo.getByUserName(model.UserName);
            if (user!=null && model.Password == user.Password)
            {
                Claim claim_name = new Claim(ClaimTypes.Name, user.UserName);
                ClaimsIdentity claimsIdentity = new ClaimsIdentity("Cookies");
                claimsIdentity.AddClaim(claim_name);
                foreach (var role in user.Roles)
                {
                    Claim claim_role = new Claim(ClaimTypes.Role, role.RoleName);
                    claimsIdentity.AddClaim(claim_role);
                }
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal();
                claimsPrincipal.AddIdentity(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Wrong User Name Or Password ");
                ViewBag.type = "Login";
                return View();
                //return Content("Wrong user name or password");
            }
        }
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.type = "Register";
            return View("Login");
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (CheckUserName(user.UserName))
            {
                Role role = accountRepo.GetRoleByName("Student");
                if (role != null)
                {
                    user.Roles.Add(role);    
                }
                accountRepo.AddUser(user);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("UserName", "This user name already exists, Please choose another one");
                ViewBag.type = "Register";
                return View("Login");
            }
            
        }
        public Boolean CheckUserName(string userName)
        {
            var user = accountRepo.getByUserName(userName);
            if (user != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        //Admin can register new user and give them (Instructor, Admin) roles
        [Authorize(Roles = "Admin")]
        public IActionResult RegisterAdmin()
        {
            ViewBag.type = "Register";
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult RegisterAdmin(ResgisterUserViewModel model)
        {
            if (CheckUserName(model.UserName))
            {
                User user = new User();
                user.UserName = model.UserName;
                user.Password = model.Password;
                foreach (var role in model.Roles)
                {
                    Role r = accountRepo.GetRoleByName(role);
                    user.Roles.Add(r);
                }
                accountRepo.AddUser(user);
                return View();
            }
            else
            {
                ModelState.AddModelError("UserName", "This user name already exists, Please choose another one");
                return View();
            }
        }
    }
}
