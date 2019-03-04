using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using Ferma.Models;
using Ferma.BLL.DTO;
using System.Security.Claims;
using Ferma.BLL.Interfaces;
using Ferma.BLL.Infrastructure;
using Microsoft.AspNet.Identity;

namespace Ferma.Controllers
{

    public class AccountController : Controller
    {
        private IService<UserDTO> userService;

        public AccountController(IService<UserDTO> service)
        {
            userService = service;
        }
        private IUserServiceAuth UserServiceAuth
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserServiceAuth>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO { UserName = model.UserName, Password = model.Password};
                ClaimsIdentity claim = await UserServiceAuth.Authenticate(userDto);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    userDto = userService.GetID(User.Identity.GetUserId());
                    if (userDto == null)
                    {
                        userService.Create(userDto);
                    }
                    return RedirectToAction("Index", "Farm");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index");
        }

        public ActionResult Register()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO
                {
                    Email = model.Email,
                    Password = model.Password,
                    UserName = model.Name,                   
                };
                OperationDetails operationDetails = await UserServiceAuth.Create(userDto);
                if (operationDetails.Succedeed)
                    return PartialView("SuccessRegister");
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return PartialView(model);
        }
       
    }
}