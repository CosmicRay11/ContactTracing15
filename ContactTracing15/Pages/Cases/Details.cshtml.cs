﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContactTracing15.Data;
using ContactTracing15.Models;

namespace ContactTracing15.Pages.Cases
{
    public class DetailsModel : PageModel
    {
        private readonly ContactTracing15.Data.ApplicationDbContext _context;

        public DetailsModel(ContactTracing15.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Case Case { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Case = await _context.Cases
                .Include(_ => _.Tester).FirstOrDefaultAsync(m => m.CaseID == id);

            if (Case == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
