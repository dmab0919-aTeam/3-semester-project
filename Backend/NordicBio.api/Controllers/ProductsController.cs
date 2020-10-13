﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NordicBio.api.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace NordicBio.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductsService _productsService;
        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public string GetAll()
        {
            return _productsService.Getmovies();
        }
    }
}
