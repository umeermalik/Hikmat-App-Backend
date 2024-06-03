using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Hakeemhikmat.Models;
using Newtonsoft.Json;

namespace Hakeemhikmat.Controllers
{

    public class UsersController : ApiController
    {
        HakeemhikmatAppEntities3 db = new HakeemhikmatAppEntities3();



        //[HttpGet]
        //public IHttpActionResult Login(s)
        //{
        //    try
        //    {

        //        var check = db.Users.Where(u => u.username == name && u.email == email).Select(u => new
        //        {
        //            Email = u.email,
        //            Password = u.password,
        //            Name = u.username,
        //            Id = u.userid
        //        }).FirstOrDefault();
        //        if (check == null)
        //        {
        //            return Ok("no such data found");
        //        }
        //        return Ok(check);

        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalServerError(ex);
        //    }
        //}
        //[HttpPost]
        //public HttpResponseMessage Signup(User data)
        //{
        //    try
        //    {
        //        var use = db.Users.FirstOrDefault(s => s.email == data.email
        //        );
        //        if (use == null)
        //        {
        //            db.Users.Add(data);
        //            db.SaveChanges();
        //            return Request.CreateResponse("data entered");
        //        }
        //        else
        //        {
        //            return Request.CreateResponse("email is in use");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(ex.Message);
        //    }


        //}
        //[HttpGet]
        //public HttpResponseMessage userexist(string emails)
        //{
        //    try
        //    {
        //        var chk = db.Users.Where(u => u.email == emails).Select(u => new
        //        {
        //            u.email,
        //            u.name,
        //            u.password,
        //            u.image

        //        }).FirstOrDefault();
        //        if(chk== null)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.OK,"no data");
        //        }
        //        return Request.CreateResponse(HttpStatusCode.OK,chk);

        //    }
        //    catch(Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError,ex.Message);

        //    }
        //}

        //[HttpGet]
        
        //public IHttpActionResult getUser()
        //{
        //    try
        //    {
        //        var group = db.Users.Select(b => new
        //        {
        //            b.id,
        //            b.name,
                
        //        });
        //        if (group == null)
        //        {
        //            return Ok("No user yet added");
        //        }
        //        return Ok(group);
        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalServerError(ex);
        //    }
        //}
        [HttpGet]
        public HttpResponseMessage Loginn( string email,String password)
        {
            try
            {
                var chk = db.Users.Where(u => u.email == email && u.password == password).FirstOrDefault();         
                if (chk == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "User not Found");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK,chk);
                    
                }

            }
            catch (Exception ex)
            {
                // Return an error response with InternalServerError status and the exception message
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }


        [HttpPost]
        public HttpResponseMessage UuserSignup()
        {
            try
            {
                var request = System.Web.HttpContext.Current.Request;
                if (request == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Request is null");
                }

                string requestedname = request["name"];

                string requestedemail    = request["email"];

                string requestedpassword = request["password"];

                string requestedrol = request["rol"];


                //var image_file = request.Files["image"];
                User newuser = new User();
                {

                    //if (image_file == null)
                    //{
                    //    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(image_file.FileName);
                    //    string imagePath = System.Web.HttpContext.Current.Server.MapPath("~/Content/Images/" + uniqueFileName);


                    //    image_file.SaveAs(imagePath);
                    //    newnushka.image = uniqueFileName;
                    //}
                    newuser.name = requestedname;

                    newuser.email = requestedemail;
                    newuser.password = requestedpassword;
                    newuser.rol = requestedrol;
                    
                };
                db.Users.Add(newuser);
                db.SaveChanges();

                if (newuser.rol == "hakeem")
                {

                    db.Hakeems.Add(new Hakeem { hakeem_id = newuser.id });
                    db.SaveChanges();
                }
                return Request.CreateResponse(HttpStatusCode.OK,newuser.id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }


        }




    }
}

