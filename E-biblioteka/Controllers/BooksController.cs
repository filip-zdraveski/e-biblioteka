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
    public class BooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Books
        public ActionResult Index(int? page, string orderBy, string search, string bookGenre)
        {
            var pageNumber = page ?? 1;
            var pageSize = 9;
            var books = db.Books.Include(b => b.Author);

            IQueryable<string> genreQuery = from b in db.Books
                                            orderby b.Genre
                                            select b.Genre;

            if (!string.IsNullOrEmpty(search))
            {
                books = books.Where(iterator => iterator.Name.Contains(search) || iterator.Author.Name.Contains(search));
            }

            if (!string.IsNullOrEmpty(bookGenre))
            {
                books = books.Where(iterator => iterator.Genre == bookGenre);
            }

            switch (orderBy)
            {
                case "title-ascending":
                    books = books.OrderBy(b => b.Name);
                    break;
                case "title-descending":
                    books = books.OrderByDescending(b => b.Name);
                    break;
                case "rating-descending":
                    books = books.OrderByDescending(b => b.Rating);
                    break;
                case "year-ascending":
                    books = books.OrderBy(b => b.Year);
                    break;
                case "year-descending":
                    books = books.OrderByDescending(b => b.Year);
                    break;
                default:
                    books = books.OrderByDescending(b => b.Rating);
                    break;
            }

            var booksVM = new BooksViewModel
            {
                Genres = genreQuery.Distinct().ToList(),
                Books = books.ToPagedList(pageNumber, pageSize)
            };
            ViewBag.OrderBy = orderBy;
            return View(booksVM);
        }

        // GET: Books/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Include(b => b.Author).FirstOrDefault(b => b.BookId == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            var model = new AddAuthorToBook()
            {
                Book = new Book(),
                Authors = db.Authors.ToList(),
                SelectedAuthorId = -1,
                SelectedBookId = -1
            };

            return View(model);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult CreateFromRequest(Request request)
        {
            Book newBook = new Book
            {
                Name = request.Title,
            };
            var model = new AddAuthorToBook()
            {
                Book = newBook,
                Authors = db.Authors.ToList(),
                SelectedAuthorId = -1,
                SelectedBookId = -1
            };
            return View(model);
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create(AddAuthorToBook model)
        {
            if (ModelState.IsValid)
            {
                Book book = new Book()
                {
                    Name = model.Book.Name,
                    Genre = model.Book.Genre,
                    Year = model.Book.Year,
                    Rating = model.Book.Rating,
                    Description = model.Book.Description,
                    ImageUrl = model.Book.ImageUrl
                };

                Author author = db.Authors.Find(model.SelectedAuthorId);
                if (author == null) // mozhe nema da ni treba ova voopshto
                {
                    model = new AddAuthorToBook()
                    {
                        Book = new Book(),
                        Authors = db.Authors.ToList(),
                        SelectedAuthorId = -1,
                        SelectedBookId = -1
                    };

                    return View(model);
                }
                book.Author = author; 

                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Books/Edit/5
        [Authorize(Roles = "Administrator, Employee")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Book book = db.Books.Find(id);
            if (book == null)
                return HttpNotFound();

            var model = new AddAuthorToBook()
            {
                Book = new Book(),
                Authors = db.Authors.ToList(),
                SelectedAuthorId = book.Author.AuthorId,
                SelectedBookId = -1
            };

            model.Book = book;
            return View(model);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Employee")]
        public ActionResult Edit(AddAuthorToBook model)
        {
            if (ModelState.IsValid)
            {
                Book book = db.Books.Find(model.Book.BookId);
                if (book == null)
                    return HttpNotFound();

                book.Name = model.Book.Name;
                book.Description = model.Book.Description;
                book.Genre = model.Book.Genre;
                book.ImageUrl = model.Book.ImageUrl;
                book.Rating = model.Book.Rating;
                book.Year = model.Book.Year;
                book.InStock = model.Book.InStock;

                Author author = db.Authors.Find(model.SelectedAuthorId);
                if (author == null)
                {
                    model = new AddAuthorToBook()
                    {
                        Book = new Book(),
                        Authors = db.Authors.ToList(),
                        SelectedAuthorId = -1,
                        SelectedBookId = -1
                    };
                    return View(model);
                }
                book.Author = author;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Books/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Include(b => b.Author).FirstOrDefault(b => b.BookId == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteConfirmed(long id)
        {
            Book book = db.Books.Include(b => b.Author).FirstOrDefault(b => b.BookId == id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UpVote(long id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Include(b => b.Author).FirstOrDefault(b => b.BookId == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            var rating = book.Rating;
            rating=rating+0.1;
            book.Rating = rating;
            db.SaveChanges();
            return View("Details", book);
        }
        public ActionResult DownVote(long id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Include(b => b.Author).FirstOrDefault(b => b.BookId == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            var rating = book.Rating;
            rating = rating - 0.1;
            book.Rating = rating;
            db.SaveChanges();
            return View("Details", book);
        }
        [Authorize(Roles = "Member, Moderator")]
        public ActionResult Order(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Include(b => b.Author).FirstOrDefault(b => b.BookId == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost]
        [Authorize(Roles = "Member, Moderator")]
        public ActionResult Order(long? id, string unused)
        {
            Book book = db.Books.Include(b => b.Author).FirstOrDefault(b => b.BookId == id);
            book.InStock -= 1;
            db.Entry(book).Property(b => b.InStock).IsModified = true;
            db.SaveChanges();
            return View(book);
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
