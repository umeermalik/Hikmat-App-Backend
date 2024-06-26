﻿using Antlr.Runtime.Tree;
using Hakeemhikmat.Models;
using Microsoft.Ajax.Utilities;
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
using System.Xml.Linq;

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
        [HttpPut]
        public HttpResponseMessage UpdateIngredient(int id)
        {
            try
            {
                var request = System.Web.HttpContext.Current.Request;
                if (request == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Request is null");
                }

                string requestName = request["name"];
              

               
                var ingredient = db.Ingredients.Find(id);
                if (ingredient == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Ingredient not found");
                }

               
                ingredient.name = requestName;
          

             
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Ingredient updated successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPut]
        public HttpResponseMessage UpdateIngredientquantity(int i_id,int n_id)
        {
            try
            {
                var request = System.Web.HttpContext.Current.Request;
                if (request == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Request is null");
                }

                string requestquantity = request["quanity"];
                string requestunit = request["unit"];



                var ingredient = db.NuskhaIngredients.Where(ni => ni.ingredient_id == i_id && ni.nuskha_id == n_id).FirstOrDefault();
                if (ingredient == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Ingredient not found");
                }


                ingredient.quanity = int.Parse(requestquantity);
                ingredient.unit = requestunit;


                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Ingredient updated successfully");
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
        [HttpGet]
        public HttpResponseMessage Getall (int n_id)
        {
            try {

                var query = from i in db.Ingredients
                            join ni in db.NuskhaIngredients on i.id equals ni.ingredient_id
                            where ni.nuskha_id == n_id
                            select new
                            {   i.id,
                                i.name,
                                ni.quanity,
                                ni.unit
                            };

                var result = query.ToList();

                // Return the result as a JSON response
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an appropriate error message
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
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
                        join nu in db.Users on n.hakeem_id equals nu.id
                        join d in db.Disease on nd.disease_id equals d.id
                        where nd.disease_id == id && n.publicity == "public"
                        select new
                        {
                            Nuskhaid = n.id,
                            NuskhaName = n.name,
                            DiseaseName = d.name,
                            HakeemName = nu.name,
                            hakeemid = nu.id,
                            DiseaseTage=d.Tags,
                            AverageRating = db.Rates
                                                .Where(r => r.nuskha_id == n.id)
                                                .Average(r => r.rating),
                            RatingCount = db.Rates
                                        .Where(r => r.nuskha_id == n.id)
                                        .Count()
                        }
                    ).OrderByDescending(x => x.RatingCount).ToList(); 

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
        public HttpResponseMessage Searchhakeem(string diseaseIds)
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

                    var hakeemNuskhaRatings = (
                        from n in db.Nuskhas
                        join nd in db.NuskhaDiseases on n.id equals nd.nuskha_id
                        join nu in db.Users on n.hakeem_id equals nu.id
                        join d in db.Disease on nd.disease_id equals d.id
                        where nd.disease_id == id && n.publicity == "public"
                        select new
                        {
                            NuskhaId = n.id,
                            NuskhaName = n.name,
                            DiseaseName = d.name,
                            HakeemId = nu.id,
                            HakeemName = nu.name,
                            DiseaseTage = d.Tags,
                            NuskhaRating = db.Rates
                                            .Where(r => r.nuskha_id == n.id)
                                            .Average(r => (double?)r.rating) ?? 0 ,
                            RatingCount = db.Rates
                                    .Where(r => r.nuskha_id == n.id)
                                    .Count()
                        }
                    ).ToList();

                    var hakeemAverageRatings = hakeemNuskhaRatings
                        .GroupBy(x => x.HakeemId)
                        .Select(g => new
                        {
                            HakeemId = g.Key,
                            AverageRating = g.Average(x => x.NuskhaRating),
                           
                        })
                        .ToList();

                    var finalResult = (
                        from nuskha in hakeemNuskhaRatings
                        join hr in hakeemAverageRatings on nuskha.HakeemId equals hr.HakeemId
                        select new
                        {
                            Nuskhaid = nuskha.NuskhaId,
                            NuskhaName = nuskha.NuskhaName,
                            DiseaseName = nuskha.DiseaseName,
                            HakeemName = nuskha.HakeemName,
                            HakeemId = nuskha.HakeemId,
                            AverageRating = hr.AverageRating,
                            RatingCount = nuskha.RatingCount,
                        }
                    ).OrderByDescending(x => x.RatingCount).ToList();

                    result.AddRange(finalResult);
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
        public HttpResponseMessage Getusage(int Nuskaid)
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
                       
                           join u in db.Usages on n.id equals u.nuskha_id
                           where n.id == Nuskaid
                           select new
                           {
                            
                               Nuskhausage = u.usages
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
        public HttpResponseMessage GetCommentOfNuskha(int nid)
        {
            try
            {
                var request = System.Web.HttpContext.Current.Request;

                if (request == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Request is null");
                }

                var comments = (from n in db.Rates
                                join u in db.Users on n.user_id equals u.id
                                where n.nuskha_id == nid
                                select new
                                {   
                                    nuskhaid = n.nuskha_id,
                                    rate = n.rating,
                                    Comment = n.comment,
                                    user = n.user_id,
                                    usermail=u.email,
                                    commentid=n.id
                                }).ToList();

                if (!comments.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No data found for the provided Nuskhaid");
                }

                return Request.CreateResponse(HttpStatusCode.OK, comments);
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
                               productid=s.id,
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



        [HttpPost]
        public HttpResponseMessage AddUsage()
        {
            try
            {
                var request = System.Web.HttpContext.Current.Request;
                if (request == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Request is null");
                }
              
                string requestusage = request["usage"];


                string requestr_id = request["r_id"];
                Usage addusage = new Usage();
                {
                    addusage.nuskha_id = int.Parse(requestr_id);
                    
                    addusage.usages = requestusage;



                }
                db.Usages.Add(addusage);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "added");

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        //[HttpPost]
        //public HttpResponseMessage Productrating()
        //{
        //    try
        //    {
        //        var request = System.Web.HttpContext.Current.Request;
        //        if (request == null)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.BadRequest, "Request is null");
        //        }
        //        string requestp_id = request["p_id"];
        //        string requestu_id = request["u_id"];
        //        string requestrating = request["rating"];


        //        Productrating ing = new Productrating();
        //        {
        //            ing.productid = int.Parse(requestp_id);
        //            ing.userid = int.Parse(requestu_id);
        //            ing.rating = int.Parse(requestrating);

        //        }
        //        db.Productratings.Add(ing);
        //        db.SaveChanges();
        //        return Request.CreateResponse(HttpStatusCode.OK, ing.id);


        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
        //    }

        //}
        [HttpPost]

        public HttpResponseMessage Repliescomment()
        {
            try
            {
                var request = System.Web.HttpContext.Current.Request;
                if (request == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Request is null");
                }

                string requestu_id = request["u_id"];
                string requetcommentid = request["commentid"];
                string requestcomment = request["comment"];

                Comments newcomment = new Comments();
                {
                    newcomment.commentid = int.Parse(requetcommentid);
                    newcomment.user_id = int.Parse(requestu_id);
                    newcomment.Comment = requestcomment;
                }
                db.Comments.Add(newcomment);
                db.SaveChanges();


                return Request.CreateResponse(HttpStatusCode.OK,"ohh yeah");




            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }

        [HttpGet]
        public HttpResponseMessage GetAllCommentReply( int c_id)
        {
            try
            {
                var result= (from n in db.Comments
                             join s in db.Rates on n.commentid equals s.id
                             join u in db.Users on  s.user_id equals u.id
                             
                             where n.commentid == c_id
                             select new
                             {
                                 usermail=u.email,
                                 replycomment=n.Comment
                             }).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, result);

            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        //public HttpResponseMessage Addhakeemrating()
        //{
        //    try
        //    {
        //        var request = System.Web.HttpContext.Current.Request;
        //        if (request == null)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.BadRequest, "Request is null");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

        //    }
        //}

        [HttpGet]
        public IHttpActionResult showAllDisease()
        {
            try
            {
                var chk = db.Disease.Select(u => new
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
        [HttpPost]
        
        public HttpResponseMessage HakeemRating(int user_id, int h_id, int rating)
        {
            try
            {
                Hakeemrate newrate = new Hakeemrate
                {
                    user_id = user_id,
                    h_id = h_id,
                    rating = rating
                };

                db.Hakeemrate.Add(newrate);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, newrate.id);
            }
            catch (Exception ex)
            {
                // Log the detailed error information
                System.Diagnostics.Debug.WriteLine("Error while updating the entries: " + ex.ToString());
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
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
                    return Ok(subquery.ToList());
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpPut]
        public HttpResponseMessage UpdateIngredientquantityAfterUploading(int i_id, int n_id)
        {
            try
            {
                var request = System.Web.HttpContext.Current.Request;
                if (request == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Request is null");
                }

                string requestquantity = request["quanity"];
                string requestunit = request["unit"];



                var ingredient = db.NuskhaIngredients.Where(ni => ni.ingredient_id == i_id && ni.nuskha_id == n_id).FirstOrDefault();
                if (ingredient == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Ingredient not found");
                }


                ingredient.quanity = int.Parse(requestquantity);
                ingredient.unit = requestunit;


                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Ingredient updated successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPut]
        public HttpResponseMessage UpdateIngredientStatus( int n_id)
        {
            try
            {
                var request = System.Web.HttpContext.Current.Request;
                if (request == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Request is null");
                }

                var requestedpublicity = request["publicity"];



                var ingredient = db.Nuskhas.Where(ni => ni.id == n_id).FirstOrDefault();
                if (ingredient == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Ingredient not found");
                }


                ingredient.publicity = requestedpublicity;
               


                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Ingredient updated successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage GetNushkadetailsForUpgrade(int n_id)
        {
            try
            {

                var query = from n in db.Nuskhas
                            join ni in db.NuskhaIngredients on n.id equals ni.nuskha_id
                            join i in db.Ingredients on ni.ingredient_id equals i.id
                            where n.id == n_id
                            select new
                            {
                                IngredientId = i.id,
                                NuskhaName = n.name,
                                NuskhaPublicity = n.publicity,
                                ingredetienid=i.id,
                                IngredientName = i.name,
                                ni.quanity,
                                ni.unit
                            };

                var result = query.ToList();


                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }

}
