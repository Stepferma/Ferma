using AutoMapper;
using Ferma.BLL.DTO;
using Ferma.BLL.Interfaces;
using Ferma.DAL.Entities;
using Ferma.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Security.Claims;

namespace Ferma.BLL.Services
{
    public class TypeProductsService : IService<TypeProductsDTO>
    {
        IUnitOfWork Database { get; set; }

        public TypeProductsService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Create(TypeProductsDTO typeProductsDTO)
        {
            TypeProducts typeProduct = new TypeProducts
            {
                IdTypeProducts = typeProductsDTO.IdTypeProducts,
                Name = typeProductsDTO.Name
            };

            Database.TypeProducts.Create(typeProduct);
        }

        public TypeProductsDTO GetID(int id)
        {
            if (id == 0)
            {
                return null;
            }

            var typeProduct = Database.TypeProducts.GetID(id);
            if (typeProduct == null)
            {
                return null;
            }
            return new TypeProductsDTO {
                IdTypeProducts = typeProduct.IdTypeProducts,
                Name = typeProduct.Name
            };
        }

        public IEnumerable<TypeProductsDTO> GetList()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TypeProducts, TypeProductsDTO>()).CreateMapper();
            var typeProduct = mapper.Map<IEnumerable<TypeProducts>, List<TypeProductsDTO>>(Database.TypeProducts.GetAll());
            return typeProduct;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
