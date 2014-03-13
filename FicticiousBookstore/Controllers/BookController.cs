using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FicticiousBookstore.Models;
using System.IO;

namespace FicticiousBookstore.Controllers
{
    public class BookController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Book/
        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }

        // GET: /Book/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: /Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Book/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ISBN13,ISBN10,Title,Author,Description,PublicationDate,Image,Price,Stock")] Book book)
        {
            if (ModelState.IsValid)
            {
                var fileName = Path.GetFileName(book.Image.FileName);
                book.ImageName = fileName;

                db.Books.Add(book);
                db.SaveChanges();

                
                var savePath = Path.Combine(Server.MapPath("~/Images/Books"), fileName);
                book.Image.SaveAs(savePath);

                return RedirectToAction("Index");
            }

            return View(book);
        }

        // GET: /Book/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: /Book/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ISBN13,ISBN10,Title,Author,Description,PublicationDate,Image,Price,Stock")] Book book)
        {
            if (ModelState.IsValid)
            {
                string fileName = null;
                
                if (book.Image != null && book.Image.ContentLength > 0)
                {
                    fileName = Path.GetFileName(book.Image.FileName);
                    book.ImageName = fileName;
                }

                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();

                if (!string.IsNullOrWhiteSpace(fileName))
                {
                    var savePath = Path.Combine(Server.MapPath("~/Images/Books"), fileName);
                    book.Image.SaveAs(savePath);
                }

                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: /Book/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: /Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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
