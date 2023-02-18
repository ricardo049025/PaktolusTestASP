using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PaktolusApp.Interfaces.Services;
using PaktolusApp.Models;

namespace PaktolusApp.Controllers
{
    public class HobbiesController : Controller
    {
        //private readonly DbTestContext _context;
        private IHobbyService service;

        public HobbiesController(IHobbyService service)
        {
            this.service = service;
        }

        // GET: Hobbies
        public async Task<IActionResult> Index()
        {
            var hobbies = await this.service.GetAll();

            if (hobbies == null) Problem("No records found");

            return View(hobbies);
        }

        

        // GET: Hobbies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var hobby = await this.service.GetById(id??0);
            if (hobby == null) return NotFound();

            return View(hobby);
        }

        

        // GET: Hobbies/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Active")] Hobby hobby)
        {
            if (ModelState.IsValid)
            {
                await this.service.Add(hobby); 
                return RedirectToAction(nameof(Index));
            }

            return View(hobby);
        }


        // GET: Hobbies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var hobby = await this.service.GetById(id ?? 0);
            if (hobby == null) return NotFound();
            return View(hobby);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Active")] Hobby hobby)
        {
            if (id != hobby.Id) return NotFound();

            try
            {
                if (ModelState.IsValid)
                {
                    await this.service.Update(hobby);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            
            return View(hobby);
        }

        
        // GET: Hobbies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var hobby = this.service.GetById(id ?? 0);
            if (hobby == null) return NotFound();
            return View(hobby.Result);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hobby = await this.service.GetById(id);
            if (hobby == null) return NotFound();
            await this.service.Delete(id);            
            return RedirectToAction(nameof(Index));
        }
        
    }

}
