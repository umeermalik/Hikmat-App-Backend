//using Hakeemhikmat.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Security.Cryptography;
//using System.Web;
//using System.Web.Http;

//namespace Hakeemhikmat.Controllers
//{
//    public class OrderDataController : ApiController
//    {
//        HakeemhikmatAppEntities3 db = new HakeemhikmatAppEntities3();

//        [HttpPost]
//        public HttpResponseMessage setorder()
//        {
//            try
//            {
//                var request = HttpContext.Current.Request;
//                var form = request.Form;
//                var productName = form["productName"];
//                var unit_price = form["unit_price"];
//                var rating = int.Parse(form["rating"]);
//                var comment = form["comment"];
//                var date = DateTime.Parse(form["date"]);
//                var productid = int.Parse(form["productid"]);
//                var order_id = int.Parse(form["order_id"]);
//                int userid = int.Parse(form["userid"]);
//                int price = GetProductPrice(productid);
//                Order o = new Order();
//                o.date = date;
//                o.user_id = userid;
//                o.order_id = order_id;
//                Order_Detail od = new Order_Detail();
//                od.unit_price = price;
//                od.comment = comment;
//                od.rating = rating;
//                od.product_id = productid;
//                o.Order_Detail.Add(od);
//                if (price < 0)
//                    throw new NotImplementedException();
//                if (!InsertIntOrders(o))
//                    throw new NotImplementedException();
//                return Request.CreateResponse(System.Net.HttpStatusCode.OK,"Data Inserted Successfully");
//            }
//            catch (Exception ex)
//            {
//                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, ex.Message);
//            }
//        }

//        private int GetProductPrice(int pid)
//        {
//            try
//            {
//                int price = (int)db.Products.Where(x => x.id == pid).Select(x => x.price).FirstOrDefault();
//                return price;
//            }
//            catch
//            {
//                return -1;
//            }
//        }

//        private bool InsertIntOrders(Order ord)
//        {
//            try
//            {
//                db.Orders.Add(ord);
//                db.SaveChanges();
//                return true;
//            }
//            catch
//            {
//                return false;
//            }
//        }

//        [HttpGet]
//        public HttpResponseMessage orderdetail(string name)
//        {
//            try
//            {
//                var query = db.Order_Detail
//      .Join(db.Orders, orderDetail => orderDetail.order_id, order => order.order_id, (orderDetail, order) => new { orderDetail, order })
//      .Join(db.Users, x => x.order.user_id, user => user.id, (x, user) => new { x.orderDetail, x.order, user })
//      .Join(db.Products, x => x.orderDetail.product_id, product => product.id, (x, product) => new
//      {
//          product_serial = x.orderDetail.product_id,
//          x.orderDetail.order_id,
//          productName = product.name,
//          x.orderDetail.unit_price,
//          x.orderDetail.rating,
//          x.orderDetail.comment,
//          date = x.order.date,
//          x.user.name
//      })
//      .Where(x => x.productName ==  name);

//                return Request.CreateResponse(System.Net.HttpStatusCode.OK, query.ToList());
//            }

//            catch (Exception ex)
//            {
//                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, ex.Message);
//            }
//        }

//    }
//}
