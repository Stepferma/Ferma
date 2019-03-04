using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ferma.BLL.DTO;
using Ferma.BLL.Interfaces;
using Ferma.Models;
using Microsoft.AspNet.Identity;

namespace Ferma.Controllers
{
    public class FarmController : Controller
    {
        private IServiceUsers<UserDTO> userService;

        public FarmController(IServiceUsers<UserDTO> service)
        {
            userService = service;
        }
        // GET: Farm
        public ActionResult Index()
        {
            UserDTO userDto = userService.GetID(User.Identity.GetUserId());
            UserViewModel userView = new UserViewModel {UserName = userDto.UserName, Email = userDto.Email};
            return PartialView(userView);
        }
    }
}