﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WDP2022A2Win.Data;
using WDP2022A2Win.Models;

namespace WDP2022A2Win.Views.Companies
{
    public class DeleteModel : PageModel
    {
        private readonly WDP2022A2Win.Data.ApplicationDbContext _context;

        public DeleteModel(WDP2022A2Win.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Company Company { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Company == null)
            {
                return NotFound();
            }

            var company = await _context.Company.FirstOrDefaultAsync(m => m.Id == id);

            if (company == null)
            {
                return NotFound();
            }
            else 
            {
                Company = company;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Company == null)
            {
                return NotFound();
            }
            var company = await _context.Company.FindAsync(id);

            if (company != null)
            {
                Company = company;
                _context.Company.Remove(Company);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
