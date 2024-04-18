using Hakeemhikmat.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hakeemhikmat.Controllers
{
    public class DeleteController : ApiController
    {
        HakeemhikmatAppEntities3 db = new HakeemhikmatAppEntities3();
        [HttpPost]
        public HttpResponseMessage DeleteProduct(string name)
        {
            try
            {
                var productToDelete = db.Products
                .Where(p => p.name == name)
                .FirstOrDefault();

                if (productToDelete != null)
                {
                    db.Products.Remove(productToDelete);
                    db.SaveChanges();
                }
                return Request.CreateResponse(HttpStatusCode.OK, "product deleted");

            }
            catch (Exception ex)
            {
                
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public HttpResponseMessage deleteNuskha(string name)
        {
            try
            {
                var nuskhaToDelete = db.Nuskhas
                .Where(p => p.name == name)
                .FirstOrDefault();

                if (nuskhaToDelete != null)
                {
                    db.Nuskhas.Remove(nuskhaToDelete);
                    db.SaveChanges();
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Nuskha deleted");

            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


    }
}
