using librarymanagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LibraryManagement.Controllers
{
    public class BookController : Controller
    {
        private readonly LibraryDbContext _context;

        public BookController(LibraryDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult CheckStatus()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckStatus(int studentId)
        {
            var issuedBooks = _context.IssuedBooks    .Where(b => b.studentid == studentId) .ToList();

            return View(issuedBooks);
        }
    
       
        public IActionResult IssueBook()
        {
            return View();
        }

       
        [HttpPost]
        public IActionResult IssueBook(IssueBook issue)
        {
            if (ModelState.IsValid)
            {
                _context.IssuedBooks.Add(issue); 
                _context.SaveChanges(); 
                return RedirectToAction("IssuedBooks"); 
            }
            return View(issue); 
        }

        
        public IActionResult IssuedBooks()
        {
            var issuedBooks = _context.IssuedBooks.ToList(); 
            return View(issuedBooks); 
        }
       
        public IActionResult ReturnBook()
        {
            return View();
        }
[HttpPost]
public IActionResult ReturnBook(ReturnBook returnBook)
{
    var book = _context.IssuedBooks.FirstOrDefault(b => b.studentid == returnBook.studentid && b.bookname == returnBook.bookname && b.authorname == returnBook.authorname);

 if (book == null)
{
    ViewBag.Message = "Book not found!";
    return View();
}


    DateTime today = DateTime.Now;
    int lateDays = (today - book.duedate).Days;
    decimal fine = 0;

    if (lateDays > 0)
    {
        fine = lateDays * 100;

        _context.FineRecords.Add(new FineRecord
        {
            studentid = returnBook.studentid,
            bookname = returnBook.bookname,
            fineamount = fine,
            finedate = today
        });
    }

    returnBook.returndate = today;
    returnBook.fineamount = fine;

    _context.IssuedBooks.Remove(book);
    _context.ReturnedBooks.Add(returnBook);
    _context.SaveChanges();

    ViewBag.Fine = fine;
    return View();
}



        public IActionResult FineRecords()
        {
            var fines = _context.FineRecords.ToList();
            return View(fines);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var book = _context.IssuedBooks.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.IssuedBooks.Remove(book);
            _context.SaveChanges();

            return RedirectToAction("CheckStatus");
        }
        [HttpPost]
        public IActionResult Remove(int id)
        {
            var issuedBook = _context.IssuedBooks.Find(id); 
            if (issuedBook == null)
            {
                return NotFound();
            }

            _context.IssuedBooks.Remove(issuedBook); 
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        

    }
}
