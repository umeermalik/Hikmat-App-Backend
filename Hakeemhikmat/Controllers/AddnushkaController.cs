using Antlr.Runtime.Tree;
using Hakeemhikmat.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Web.Helpers;
using System.Web.Http;

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
        [HttpGet]//sir zahid wala kam
        public HttpResponseMessage SearchNushka(int diseaseId, int maxAge, string gender)
        {
            try
            {
                var request = System.Web.HttpContext.Current.Request;

                if (request == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Request is null");
                }


                // db.Nuskhas.Where(n => n.id == db.NuskhaDiseases.Where(nd => nd.disease_id == 1).Select(nd=> nd.id)).ToList();


                var result = db.Nuskhas
    .Where(n => db.NuskhaDiseases
        .Where(nd => nd.disease_id == 1)
        .Select(nd => nd.nuskha_id)
        .Contains(n.id))
    .ToList();


                //var result = (from nd in db.NuskhaDiseases
                //              join n in db.Nuskhas on nd.nuskha_id equals n.id
                //              join d in db.Diseases on nd.id equals d.id
                //              where nd.disease_id == diseaseId &&
                //                    nd.maxage == maxAge &&
                //                    nd.gender == gender
                //              select new
                //              {
                //                  NuskhaDisease = nd,
                //                  NuskhaName = n.name,
                //                  DiseaseName = d.name
                //              }).ToList();

                var linqQuery = db.NuskhaDiseases.Join(db.Nuskhas, nuskha => nuskha.nuskha_id, disease => diseaseId, (nuskha, disease) => nuskha);
                Console.WriteLine(linqQuery);
               // var res = db.NuskhaDiseases.Join(db.);
                return Request.CreateResponse(HttpStatusCode.OK, linqQuery);
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


                string requestr_id = request["r_id"];
                NuskhaStep steps= new NuskhaStep();
                {
                    steps.nuskha_id = int.Parse(requestr_id);
                    steps.steps = requeststeps;
                    

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
        public IHttpActionResult GetAllRemedy()
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
    .Where(n => n.hakeem_id.ToString() == requestID)
    .Select(n => n.name);


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
