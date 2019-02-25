using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using UserStore.BLL.DTO;
using UserStore.BLL.Interfaces;
using UserStore.BLL.Services;
using UserStore.Models;

namespace UserStore.Controllers
{
    public class HomeController : Controller
    {
        IService<UserDTO> userService;

        public HomeController(IService<UserDTO> serv)
        {
            userService = serv;
        }

        public ActionResult Index()
        {
            var userMapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
            List<UserViewModel> users = userMapper.Map<IEnumerable<UserDTO>, List<UserViewModel>>(userService.GetList()).ToList();

            return View(users);
        }
        [Authorize(Roles="admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            
            return View();
        }
    }
}