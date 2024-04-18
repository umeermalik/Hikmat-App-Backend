using Hakeemhikmat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hakeemhikmat.Models;
using Newtonsoft.Json;

namespace Hakeemhikmat.Controllers
{
    public class AddproductController : ApiController
    {
        HakeemhikmatAppEntities3 db = new HakeemhikmatAppEntities3();
         
            [HttpPost]
        public HttpResponseMessage Signup(Product data)
        {
            try
            {
                db.Products.Add(data);
                db.SaveChanges();
                return Request.CreateResponse("data entered");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(ex.Message);
            }


        }
    }
}
