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
    public class updateController : ApiController
    {
        HakeemhikmatAppEntities3 db = new HakeemhikmatAppEntities3();

        //[HttpPost]
        //public HttpResponseMessage updateProductprice(string name, int price)
        //{
        //    try
        //    {
        //        var productToUpdate = db.Products
        //            .Where(p => p.name == name)
        //            .FirstOrDefault();

        //        if (productToUpdate != null)
        //        {
        //            productToUpdate.price = price;
        //            db.SaveChanges();
        //        }
        //        return Request.CreateResponse(HttpStatusCode.OK, "price of product updated");
        //    }
        //    catch (Exception ex)
        //    {
        //        // Return an error response with InternalServerError status and the exception message
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
        //    }
        //}
        //[HttpPost]
        public HttpResponseMessage updateProductname(string name, string newname)
        {
            try
            {
                var productToUpdate = db.Products
                    .Where(p => p.name == name)
                    .FirstOrDefault();

                if (productToUpdate != null)
                {
                    productToUpdate.name = newname;
                    db.SaveChanges();
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Name of product updated");
            }
            catch (Exception ex)
            {
                // Return an error response with InternalServerError status and the exception message
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public HttpResponseMessage updateNuskhaname(string name, string newname)
        {
            try
            {
                var productToUpdate = db.Nuskhas
                    .Where(p => p.name == name)
                    .FirstOrDefault();

                if (productToUpdate != null)
                {
                    productToUpdate.name = newname;
                    db.SaveChanges();
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Name of nuskha updated");
            }
            catch (Exception ex)
            {
                // Return an error response with InternalServerError status and the exception message
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }


        }
    }
}