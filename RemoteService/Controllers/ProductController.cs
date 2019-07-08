using RemoteService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using static RemoteService.Models.Product;

namespace RemoteService.Controllers
{
    public class ProductController : ApiController
    {
        // GET api/product
        public IEnumerable<Product> Get()
        {
            return ProductData.Products;
        }

        // GET api/product/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult Get(int id)
        {
            Product p = ProductData.Products.SingleOrDefault(x => x.ProductID == id);
            if (p == null)
            {
                return NotFound();
            }
            return Ok(p);
        }

        // POST api/product
        public void Post([FromBody] Product p)
        {
            ProductData.Products.Add(p);
        }
        // DELETE api/product/5
        public void Delete(int id)
        {
            Product p = ProductData.Products.SingleOrDefault(x => x.ProductID == id);
            ProductData.Products.Remove(p);
        }
    }
}
