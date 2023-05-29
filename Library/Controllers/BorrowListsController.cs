using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Data;
using Library.Models;

namespace Library.Controllers
{
    public class BorrowListsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BorrowListsController(ApplicationDbContext context)
        {
            _context = context;
        }
        //// GET: BorrowLists
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BorrowLists.Include(b => b.Books).Include(b => b.Customers);
            return View(await applicationDbContext.ToListAsync());
        }
        // GET: BorrowLists/Create
        public IActionResult Create(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            var borrowList = new BorrowBookViewModel { BookId = book.BookId, Title = book.Title, Author = book.Author, Published = book.Published, Genre = book.Genre };
            ViewBag.CustomerId = new SelectList(_context.Customers, "CustomerId", "FullName");
            var cId = Convert.ToInt32(ViewBag.CustomerId.SelectedValue);
            borrowList.CustomerId = cId;
            return View(borrowList);
        }

        // POST: BorrowLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BorrowBookViewModel borrowBook)
        {
            if (ModelState.IsValid)
            {
                var customer = await _context.Customers.FindAsync(borrowBook.CustomerId);
                var book = await _context.Books.FindAsync(borrowBook.BookId);
                var Today = DateTime.Now.Date;
                var borrowedBook = new BorrowList
                {
                    CustomerId = customer.CustomerId,
                    BookId = book.BookId,
                    BorrowDate = DateTime.Now.Date,
                    ReturnDate = Today.AddDays(21),
                };
                _context.BorrowLists.Add(borrowedBook);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "BorrowLists");
            }
            return View(borrowBook);
        }

        // GET: BorrowLists/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return BadRequest();
        //    }

        //    var borrowList = _context.BorrowLists
        //        .Include(b => b.Books)
        //        .Include(c => c.Customers)
        //        .FirstOrDefault(b => b.BookId == id && b.ReturnDate > DateTime.Now.Date);

        //    if (borrowList == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(borrowList);
        //}

        // POST: BorrowLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id)
        {
            if (id != null)
            {
                var borrowListItem = _context.BorrowLists
                    .FirstOrDefault(i => i.BorrowListId == id && i.ReturnDate > DateTime.Now);

                if (borrowListItem == null)
                {
                    return BadRequest();
                }

                borrowListItem.ReturnDate = DateTime.Now;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Books");
            }

            return RedirectToAction("Index", "Books");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}