using System;
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
    public class IndexModel : PageModel
    {
        private readonly WDP2022A2Win.Data.ApplicationDbContext _context;

        public IndexModel(WDP2022A2Win.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Company> Company { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Company != null)
            {
                Company = await _context.Company.ToListAsync();
            }
        }
    }
}
