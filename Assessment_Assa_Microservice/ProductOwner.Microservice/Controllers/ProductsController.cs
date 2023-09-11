﻿using Microsoft.AspNetCore.Mvc;
using ProductOwner.Microservice.Model;
using ProductOwner.Microservice.Services;

namespace ProductOwner.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService _productService)
        {
            productService = _productService;
        }

        [HttpGet("list")]
        public Task<IEnumerable<ProductDetails>> ProductListAsync()
        {
            var productList = productService.GetProductListAsync();
            return productList;

        }
        [HttpGet("filterlist")]
        public Task<ProductDetails> GetProductByIdAsync(int Id)
        {
            return productService.GetProductByIdAsync(Id);
        }

        [HttpPost("addproduct")]
        public Task<ProductDetails> AddProductAsync(ProductDetails product)
        {
            var productData = productService.AddProductAsync(product);
            return productData;
        }

        [HttpPost("sendoffer")]
        public logexection SendProductOfferAsync(ProductOfferDetail productOfferDetails)
        {
            logexection logexection = new logexection();
            bool isSent = false;
            if (productOfferDetails != null)
            {
                logexection = productService.SendProductOffer(productOfferDetails);

                return logexection;
            }
            return logexection;
        }
    }
}
