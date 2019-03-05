﻿using AutoMapper;
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
    public class ProductService : IService<ProductDTO>
    {
        IUnitOfWork Database { get; set; }

        public ProductService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void Create(ProductDTO productDTO)
        {
            Products product = new Products
            {
                IdProduct = productDTO.IdProduct,
                IdTypeProduct = productDTO.IdTypeProduct,
                DateStart = productDTO.DateStart
            };
            Database.Products.Create(product);
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public ProductDTO GetID(int id)
        {
            if (id == 0)
            {
                return null;
            }

            var product = Database.Products.GetID(id);
            if (product == null)
            {
                return null;
            }
            return new ProductDTO { IdProduct = product.IdProduct, IdTypeProduct = product.IdTypeProduct, DateStart = product.DateStart };
        }

        public IEnumerable<ProductDTO> GetList()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Products, ProductDTO>()).CreateMapper();
            var product = mapper.Map<IEnumerable<Products>, List<ProductDTO>>(Database.Products.GetAll());
            return product;
        }


        public bool BuyProduct(ProductDTO productDTO, PlayerDTO playerDTO)
        {
            TypeProducts typeProduct = Database.TypeProducts.GetID(productDTO.IdProduct);

            if (playerDTO.Money > typeProduct.Price)
            {
                playerDTO.Money = playerDTO.Money - typeProduct.Price;
                return true;
            }
            else
            {
                return false;
            }


        }


        public bool SoldProduct(ProductDTO productDTO, PlayerDTO playerDTO)
        {
            TypeProducts typeProduct = Database.TypeProducts.GetID(productDTO.IdProduct);

           
                playerDTO.Money = playerDTO.Money + typeProduct.Price;
                return true;
                   


        }
    }
}
