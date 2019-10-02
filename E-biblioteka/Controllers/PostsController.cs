using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using E_biblioteka.Models;
using E_biblioteka.Models.Forum;
using Microsoft.AspNet.Identity;

namespace E_biblioteka.Controllers
{
    [Authorize]
    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUser au = new ApplicationUser();

        // GET: AddCommentToPost
        //

        // GET: Posts
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.UserId = User.Identity.GetUserId();
            return View(db.Posts.ToList());
        }

        // GET: Posts/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create(int? BookId)
        {
            List<Book> Books = new List<Book>();

            if (BookId != null)
            {
                Books.Add(db.Books.Find(BookId));
            }
            else
            {
                Books = db.Books.ToList();
            }
            NewPost model = new NewPost();
            {
                model.Books = Books;
            }
            return View(model);
        }


        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,BookId,Title,Content")] NewPost model)
        {
            Post post = new Post();
            if (ModelState.IsValid)
            {
                try
                {
                    post.UserId = User.Identity.GetUserId();
                    post.Title = model.Title;
                    post.BookId = model.BookId;
                    post.Content = model.Content;
                    post.SelectedBook = db.Books.Find(model.BookId);
                    post.User = db.Users.Find(User.Identity.GetUserId());
                }
                catch
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id != null && !IsAuthorized(id.Value))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,BookId,Title,Content")] Post post)
        {
            if (ModelState.IsValid)
            {
                if (!IsAuthorized(post.Id))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
                }
                Post ChangePost = db.Posts.Find(post.Id);
                Book SelectedBook = db.Books.Find(post.BookId);
                ApplicationUser User = db.Users.Find(post.UserId);
                ChangePost.Title = post.Title;
                ChangePost.Content = post.Content;
                //ChangePost.SelectedBook = post.SelectedBook = SelectedBook;
                //ChangePost.User = User;
                //ChangePost.UserId = post.UserId;
                //ChangePost.BookId = post.BookId;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id != null && !IsAuthorized(id.Value))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!IsAuthorized(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
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

        private Boolean IsAuthorized(int id)
        {
            int PostId = id;
            string UserId = User.Identity.GetUserId();
            Post post = db.Posts.Find(PostId);
            ApplicationUser user = db.Users.Find(UserId);
            string RoleId = GetUserRole(UserId);
            if (RoleId == "1" || RoleId == "3" || post.UserId == UserId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private string GetUserRole(string UserId)
        {
            ApplicationUser user = db.Users.Find(UserId);
            try
            {
                string roleId = user.Roles.ToList().FirstOrDefault(m => m.UserId == UserId).RoleId;//1,3
                return roleId;
            }
            catch (Exception)
            {
                return "0";
            }
        }
    }
}
