using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using ContosoUniversity.Models.SchoolViewModels;

namespace ContosoUniversity.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public StudentVM StudentVM { get; set; }
        public EditModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var student = await _context.Student.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }



            StudentVM = new StudentVM
            {
                ID = student.ID,
                LastName = student.LastName,
                FirstMidName = student.FirstMidName,
                EnrollmentDate = student.EnrollmentDate
            };
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var studentToUpdate = await _context.Student.FindAsync(id);

            if (studentToUpdate == null)
            {
                return NotFound();
            }
         
            {
                studentToUpdate.LastName = StudentVM.LastName;
                studentToUpdate.FirstMidName = StudentVM.FirstMidName;
                studentToUpdate.EnrollmentDate = StudentVM.EnrollmentDate;

                
                await _context.SaveChangesAsync();
                Message = $"Customer {StudentVM.LastName} {StudentVM.FirstMidName} edited on {DateTime.Now}";
                return RedirectToPage("./Index");
            
        }

        }
    }
}
