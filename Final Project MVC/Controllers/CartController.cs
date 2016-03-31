using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Final_Project_MVC.Models;

namespace Final_Project_MVC.Controllers
{
    public class CartController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: Cart
        public ActionResult Index()
        {
            return View(db.Carts.ToList());
        }

        // GET: Cart/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // GET: Cart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cart/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CartID")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Carts.Add(cart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cart);
        }

        // GET: Cart/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Cart/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CartID")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cart);
        }


        public ActionResult ConfirmOrder()
        {

            IQueryable<Product> products = from pro in db.Products
                                           from ctr in db.Carts
                                           where ctr.Product.ProductID == pro.ProductID
                                           select pro;
            Product[] productsArray = products.ToArray();
            if (products == null)
            {
                return HttpNotFound();
            }
            else
            {
                
                Order order = new Order();
                order.OrderDate = DateTime.Now;
                order.Status = "Creating";
                Customer c = new Customer();
                c.FirstName = "Safdar";
                c.LastName = "Matches";
                c.Address = "2501 New York Ave";
                c.City = "New York City";
                c.State = "NY";
                c.Country = "USA";
                c.Phone = "7739990172";
                c.Email = "smatches@hawk.iit.edu";
                c.Zipcode = "60645";
                order.Customer = c;

                foreach (Product obj in productsArray)
                {                    
                //order.Product.Add(obj);
                }
                //order.Product.Add(productsArray);

                db.Orders.Add(order);
                db.SaveChanges();
                System.Web.HttpContext.Current.Response.Write("<h1>Your order has been confirmed!</h1>");
                return View(order);
            }

        }


        // GET: Cart/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Cart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cart cart = db.Carts.Find(id);
            db.Carts.Remove(cart);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
