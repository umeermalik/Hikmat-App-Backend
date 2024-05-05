using Antlr.Runtime.Tree;
using Hakeemhikmat.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace Hakeemhikmat.Controllers
{
    public class AddnushkaController : ApiController
    {
        HakeemhikmatAppEntities3 db = new HakeemhikmatAppEntities3();

       

       
        [HttpPost]

        public HttpResponseMessage AddRemedy()
        {
            try
            {
                var request = System.Web.HttpContext.Current.Request;
                if (request == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Request is null");
                }
              
                string requestedname = request["name"];
              
                var requestedh_id = request["h_id"];
                var requestedpublicity = request["publicity"];

                //var image_file = request.Files["image"];
                Nuskha newnushka = new Nuskha();
                {
                    newnushka.hakeem_id = int.Parse(requestedh_id);
                    //if (image_file == null)
                    //{
                    //    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(image_file.FileName);
                    //    string imagePath = System.Web.HttpContext.Current.Server.MapPath("~/Content/Images/" + uniqueFileName);

                      
                    //    image_file.SaveAs(imagePath);
                    //    newnushka.image = uniqueFileName;
                    //}
                    newnushka.name = requestedname;
                    newnushka.publicity = requestedpublicity;

                };
                db.Nuskhas.Add(newnushka);
                db.SaveChanges(); 
                return Request.CreateResponse(HttpStatusCode.OK, newnushka.id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }


        }
        [HttpPost]
        public HttpResponseMessage AddProduct()
        {
            try
            {
                var request = System.Web.HttpContext.Current.Request;
                if (request == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Request is null");
                }
                string requestedname = request["name"];
                string requestedNushkaid = request["N_id"];
                var requestgender = request["gender"];
                var requestprice = request["price"];

                var requestH_id = request["h_id"];
                var imageFile = request.Files["image"];
                if (imageFile == null || imageFile.ContentLength == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Image file is missing or empty");
                }
               
               
         
                var path = HttpContext.Current.Server.MapPath("~/Content/images/" + imageFile.FileName);
                imageFile.SaveAs(path);
                /*var acc = db.images.Where(s => s.nic == nic).FirstOrDefault();
                acc.profimage = fname;*/
             
                //// Save image file
                //string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                //string imagePath = HttpContext.Current.Server.MapPath("~/Content/Images/" + uniqueFileName);
                //imageFile.SaveAs(imagePath);
                Product newproduct = new Product();

                {

                    newproduct.nuskha_id = int.Parse(requestedNushkaid);
                    newproduct.name = requestedname;
                    newproduct.price = int.Parse(requestprice);
                   
                    newproduct.gender = requestgender;
                    newproduct.hakeem_id = int.Parse(requestH_id);
                    newproduct.image = imageFile.FileName;

                }
                db.Products.Add(newproduct);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, newproduct.id);


            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage AddNushkaData()
        {
            try
            {
                var request = System.Web.HttpContext.Current.Request;
                if (request == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Request is null");
                }

                string requestedN_id = request["n_id"];

            

           

         

              

                var requestedd_id = request["d_id"];
              




                //var image_file = request.Files["image"];
                NuskhaDisease newnushka = new NuskhaDisease();
                {

                    //if (image_file == null)
                    //{
                    //    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(image_file.FileName);
                    //    string imagePath = System.Web.HttpContext.Current.Server.MapPath("~/Content/Images/" + uniqueFileName);


                    //    image_file.SaveAs(imagePath);
                    //    newnushka.image = uniqueFileName;
                    //}
               
                    newnushka.disease_id = int.Parse(requestedd_id);
                    newnushka.nuskha_id = int.Parse(requestedN_id);
                    


                };
                db.NuskhaDiseases.Add(newnushka);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, newnushka.id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }


        }















        [HttpPost]
        public HttpResponseMessage AddIngrdeients()
        {
            try
            {
                var request = System.Web.HttpContext.Current.Request;
                if (request == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Request is null");
                }
                string requestname = request["name"];
                string requestpublicity = request["publicity"];

                Ingredient ing = new Ingredient();
                {
                    ing.name = requestname;
                    ing.Publicity = requestpublicity;
                }
                db.Ingredients.Add(ing);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, ing.id);


            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpPost]

        public HttpResponseMessage ratingcomments()
        {
            try
            {
                var request = System.Web.HttpContext.Current.Request;
                if (request == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Request is null");
                }
                string requestn_id = request["n_id"];
                string requestu_id= request["u_id"];
                string requestrating = request["rating"];
                string requestcomments = request["comments"];

                Rate ing = new Rate();
                {
                    ing.nuskha_id = int.Parse(requestn_id);
                    ing.user_id = int.Parse(requestu_id);
                    ing.rating=int.Parse(requestrating);
                    ing.comment = requestcomments;
                }
                db.Rates.Add(ing);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, ing.id);


            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }






        //sir zahid wala kam
        [HttpGet]
        public HttpResponseMessage SearchNushka(string diseaseIds)
        {
            try
            {
                string[] arr = diseaseIds.Split(',');

                var request = System.Web.HttpContext.Current.Request;

                if (request == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Request is null");
                }

                List<object> result = new List<object>(); 
                foreach (string i in arr)
                {
                    int id = Convert.ToInt32(i);


                    var hello = (
            from n in db.Nuskhas
            join nd in db.NuskhaDiseases on n.id equals nd.nuskha_id
            //join rd in db.Rates on n.id equals rd.nuskha_id
            join nu in db.Users  on n.hakeem_id equals nu.id
            join d in db.Diseases on nd.disease_id equals d.id  // Assuming Diseases table exists
            where nd.disease_id == id &&  n.publicity=="public"
            select new
            {
                Nuskhaid = n.id,
                NuskhaName = n.name,
                DiseaseName = d.name,
                hakeemname=nu.name,
              
               
                
            }
                         ).ToList();
                    result.AddRange(hello);
                }




                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage GetSteps(int Nuskaid)
        {
            try
            {
                var request = System.Web.HttpContext.Current.Request;

                if (request == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Request is null");
                }

                // Assuming 'db' is your Entity Framework DbContext instance
                var chk = (from n in db.Nuskhas
                           join s in db.NuskhaSteps on n.id equals s.nuskha_id
                           where n.id == Nuskaid
                           select new
                           {
                               Nuskhasteps = s.steps,
                               Nuskhaname = n.name,
                               Nuskhausage=s.usage
                           }).ToList();

                if (chk == null || !chk.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No data found for the provided Nuskaid");
                }

                // If data is found, return the response with the data
                return Request.CreateResponse(HttpStatusCode.OK, chk);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage GetIngredients(int Nuskaid)
        {
            try
            {
                var request = System.Web.HttpContext.Current.Request;

                if (request == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Request is null");
                }

          
                var chk = (from n in db.Nuskhas
                           join s in db.NuskhaIngredients on n.id equals s.nuskha_id
                           join i in db.Ingredients on s.ingredient_id equals i.id
                           where n.id == Nuskaid
                           select new
                           {
                             
                               Nuskhaname = n.name,
                               IngredientName = i.name ,
                               ingredientquantity=s.quanity,
                               ingredientunit = s.unit,
                           }).ToList();


                if (chk == null || !chk.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No data found for the provided Nuskaid");
                }

            
                return Request.CreateResponse(HttpStatusCode.OK, chk);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        
        public HttpResponseMessage Getproduct(int Nuskaid)
        {
            try
            {
                var request = System.Web.HttpContext.Current.Request;

                if (request == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Request is null");
                }


                var chk = (from n in db.Nuskhas
                           join s in db.Products on n.id equals s.nuskha_id
                         
                           where n.id == Nuskaid
                           select new
                           {

                               Nuskhaname = n.name,
                               Productname=s.name,
                               productprice=s.price,
                               productimage=s.image,
                           }).ToList();


                if (chk == null || !chk.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No data found for the provided Nuskaid");
                }


                return Request.CreateResponse(HttpStatusCode.OK, chk);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }



        [HttpPost]

        public HttpResponseMessage AddIngrdeintsquantity()
        {
            try
            {
                var request = System.Web.HttpContext.Current.Request;
                if (request == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Request is null");
                }
                string requestquantity = request["quantity"];

                string requestunit = request["unit"];
                string requestr_id = request["r_id"];
                string requesti_id = request["i_id"];


                NuskhaIngredient quantity = new NuskhaIngredient();
                {
                    quantity.nuskha_id = int.Parse(requestr_id);
                    quantity.ingredient_id = int.Parse(requesti_id);
                    quantity.quanity = int.Parse(requestquantity);
                    quantity.unit = requestunit;

                }
                db.NuskhaIngredients.Add(quantity);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK,"added");

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage AddSteps()
        {
            try
            {
                var request = System.Web.HttpContext.Current.Request;
                if (request == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Request is null");
                }
                string requeststeps = request["steps"];
                string requestusage = request["usage"];


                string requestr_id = request["r_id"];
                NuskhaStep steps= new NuskhaStep();
                {
                    steps.nuskha_id = int.Parse(requestr_id);
                    steps.steps = requeststeps;
                    steps.usage = requestusage;



                }
                db.NuskhaSteps.Add(steps);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "added");

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


















        [HttpGet]
        public IHttpActionResult showAllDisease()
        {
            try
            {
                var chk = db.Diseases.Select(u => new
                {
                    u.id,
                    u.name
                });

                if (chk == null || !chk.Any())
                {
                    return Ok("NO DATA");

                }
                return Ok(chk);


            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        public IHttpActionResult GetAllRemedy(int id)
        {
            try
            {
                var request = System.Web.HttpContext.Current.Request;

                if (request == null)
                {
                    return BadRequest("Request is null");
                }

                // Assuming 'db' is your DbContext instance and 'Nuskha' is the DbSet representing the 'Nuskha' table
                string requestID = request["ID"];
                var subquery = db.Nuskhas
    .Where(n => n.hakeem_id == id)
   
    .Select(n=> new
    {
        n.name,
        n.id, 
    });


                if (subquery == null || !subquery.Any())
                {
                    return Ok("User not Found");
                }
                else
                {
                    // Assuming you want to return the results of the subquery
                    return Ok(subquery.ToList());
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
