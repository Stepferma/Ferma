using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Ferma.BLL.DTO;
using Ferma.BLL.Interfaces;
using Ferma.Models;
using Microsoft.AspNet.Identity;

namespace Ferma.Controllers
{
    public class FarmController : Controller
    {
        private IServiceUsers<UserDTO> userService;
        private IService<TypeProductsDTO> typeProductService;
        private IService<TypeBuildingsDTO> typeBuildingService;

        public FarmController(IServiceUsers<UserDTO> service, IService<TypeProductsDTO> service2, IService<TypeBuildingsDTO> service3)
        {
            userService = service;
            typeProductService = service2;
            typeBuildingService = service3;

        }
        // GET: Farm
        public ActionResult Index()
        {
            UserDTO userDto = userService.GetID(User.Identity.GetUserId());
            UserViewModel userView = new UserViewModel {UserName = userDto.UserName, Email = userDto.Email};
            return PartialView(userView);
        }

        public ActionResult Building()
        {
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PhoneDTO, PhoneViewModel>()).CreateMapper();
            //var phones = mapper.Map<IEnumerable<PhoneDTO>, List<PhoneViewModel>>(phoneDtos);
            return PartialView(typeBuildingService.GetList().ToList());
        }

        [HttpPost]
        public ActionResult Building(TypeBuildingsModel typeBuildingModel)
        {
            return View("Index");
        }
    }
}