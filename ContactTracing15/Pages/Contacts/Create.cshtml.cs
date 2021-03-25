﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ContactTracing15.Data;
using ContactTracing15.Models;

namespace ContactTracing15.Pages.Contacts
{
    public class CreateModel : PageModel
    {
        private readonly ContactTracing15.Data.MainDBContext _context;

        public CreateModel(ContactTracing15.Data.MainDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CaseID"] = new SelectList(_context.Cases, "CaseID", "CaseID");
        ViewData["TracerID"] = new SelectList(_context.Tracers, "TracerID", "TracerID");
            return Page();
        }

        [BindProperty]
        public Contact Contact { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Contacts.Add(Contact);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
