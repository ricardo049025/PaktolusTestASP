using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PaktolusApp.Interfaces.Services;
using PaktolusApp.Models;
using PaktolusApp.ModelView;

namespace PaktolusApp.Controllers
{
    public class StudentsController : Controller
    {
        //private readonly DbTestContext _context;
        private IStudentService service;
        private IHobbyService hobbyService;

        public StudentsController(IStudentService service, IHobbyService hobbyService)
        {
            this.service = service;
            this.hobbyService = hobbyService;
        }

       
        // GET: Students
        public async Task<IActionResult> Index()
        {
            var students = await this.service.GetStudentWithHobbiesNames();

            if (students == null) Problem("No records found");

            return View(students);

        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var student = this.service.GetById(id ?? 0); 
            if (student == null) return NotFound();
            return View(student.Result);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            StudentVM student = new StudentVM();
            student.Hobbies =  this.hobbyService.GetAll().Result.ToList();
            return View(student);
        }
        
        [HttpPost("/Students/Create")]
        public async Task<IActionResult> Create([FromBody] StudentVM student)
        {
            try
            {
                if (student.Name.Length != 0 && student.Email.Length != 0 && student.Phone.Length != 0 && student.ZipCode.Length != 0)
                {
                    if (this.service.validateEmailPhone(student.Email, student.Phone))
                        throw new Exception("the email or phone already exist !!.");

                    await this.service.SaveStudentWithHobbies(student);
                    return Json(new { result = "Redirect", url = Url.Action("Index", "Students") });
                }

                return View(student);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

            
        }
        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var student =  this.service.GetStudentWithHobbies(id??0).Result;
            if (student == null) return NotFound();

            student.Hobbies = this.hobbyService.GetAll().Result.ToList();
            return View(student);
        }

        
        [HttpPatch("/Students/Edit")]

        public async Task<IActionResult> Edit([FromBody] StudentVM student)
        {
            try
            {

                await this.service.UpdateStudent(student);
                return Json(new { result = "Redirect", url = Url.Action("Index", "Students") });
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
                
            
            return View(student);
        } 

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var student = await this.service.GetById(id ?? 0);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await this.service.GetById(id);
            if (student == null) return NotFound();
            await this.service.Delete(student.Id);

            return RedirectToAction(nameof(Index));
        }

        
    }
}
