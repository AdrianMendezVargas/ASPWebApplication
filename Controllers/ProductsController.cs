using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPWebApplication.Models;
using ASPWebApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPWebApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase{

        public JsonFileProductService ProductService { get; }

        public ProductsController(JsonFileProductService productService) {
            ProductService = productService;
        }

        [HttpGet]
        public IEnumerable<Product> Get() {
            return ProductService.GetProducts();
        }


        //[HttpPatch] "[FromBody]"
        [Route("Rate")]
        [HttpGet]
        public ActionResult Get(
            [FromQuery]string productId,
            [FromQuery]int rating) {
            ProductService.AddRatings(productId , rating);
            return Ok();

        }

    }
}