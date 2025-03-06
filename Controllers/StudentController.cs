using librarymanagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace librarymanagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly LibraryDbContext _context;

        public StudentController(LibraryDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students); 
        }

      

 
        public IActionResult RegisterStudent()
        {
            return View();
        }

     
        [HttpPost]
        public IActionResult RegisterStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Index"); 
            }
            return View(student); 
        }

     
      public IActionResult GetUser(int id)
{
    var student = _context.Students.FirstOrDefault(s => s.Id == id);
    if (student == null)
    {
        return NotFound("Student not found");
    }

    return Json(student);
}


        [HttpPost]
        public IActionResult Update(int uid, string username, int studentid, string semester, string department, string contactnumber)
        {
            var student = _context.Students.FirstOrDefault(x => x.Id == uid);

            if (student == null)
            {
                return NotFound("Student not found");
            }

            student.name = username;
            student.studentid = studentid;
            student.semester = semester;
            student.department = department;
            student.contactnumber = contactnumber;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

           
    }
      




        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
         
    }


