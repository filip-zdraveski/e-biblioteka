using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using E_biblioteka.Models;
using PagedList;

namespace E_biblioteka.Controllers
{
    public class AuthorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Authors
        public ActionResult Index(int? page, string orderBy, string search)
        {
            var pageNumber = page ?? 1;
            var pageSize = 9;
            var authors = from a in db.Authors
                          select a;
            IOrderedQueryable<Author> model;

            if (!string.IsNullOrEmpty(search))
            {
                authors = authors.Where(iterator => iterator.Name.Contains(search));
            }

            switch (orderBy)
            {
                case "name-ascending":
                    model = authors.OrderBy(a => a.Name);
                    break;
                case "name-descending":
                    model = authors.OrderByDescending(a => a.Name);
                    break;
                default:
                    model = authors.OrderBy(a => a.Name);
                    break;
            }
            if (page == null)
                ViewBag.Page = pageNumber;
            else
                ViewBag.Page = page;
            ViewBag.OrderBy = orderBy;
            ViewBag.Search = search;
            return View(model.ToPagedList(pageNumber, pageSize));
        }

        // GET: Authors/Details/5
        public ActionResult Details(long? id, int page, string orderBy, string search)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Page = page;
            ViewBag.OrderBy = orderBy;
            ViewBag.Search = search;
            Author author = db.Authors.Include(a => a.Books).FirstOrDefault(a => a.AuthorId == id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // GET: Authors/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create([Bind(Include = "AuthorId,Name,ImageUrl,Description")] Author author)
        {
            if (ModelState.IsValid)
            {
                db.Authors.Add(author);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: Authors/Edit/5
        [Authorize(Roles = "Administrator, Employee")]
        public ActionResult Edit(long? id, int page, string orderBy, string search)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Page = page;
            ViewBag.OrderBy = orderBy;
            ViewBag.Search = search;
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Employee")]
        public ActionResult Edit([Bind(Include = "AuthorId,Name,ImageUrl,Description")] Author author, int page, string orderBy, string search)
        {
            if (ModelState.IsValid)
            {
                db.Entry(author).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { page, orderBy, search });
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(long? id, int page, string orderBy, string search)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Page = page;
            ViewBag.OrderBy = orderBy;
            ViewBag.Search = search;
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteConfirmed(long id, int page, string orderBy, string search)
        {
            Author author = db.Authors.Find(id);
            db.Authors.Remove(author);
            db.SaveChanges();
            return RedirectToAction("Index", new { page, orderBy, search });
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
