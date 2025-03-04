using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using appmvc.Data;
using appmvc.Models;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Hosting;

namespace appmvc.Controllers
{
    public class ContactsController : Controller
    {
        private readonly PhoneBookContext _context;
        private IWebHostEnvironment appEnvironment;

        public ContactsController(PhoneBookContext context, IWebHostEnvironment AppHostingEnvironment)
        {
            _context = context;
            appEnvironment = AppHostingEnvironment;
        }

        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["FNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "fname_desc" : "";
            ViewData["LNameSortParm"] = sortOrder == "LName" ? "lname_desc" : "LName";
            ViewData["CurrentFilter"] = searchString;

            var contacts = from c in _context.Contacts
                           select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                contacts = contacts.Where(c => c.LName.Contains(searchString)
                                       || c.FName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "fname_desc":
                    contacts = contacts.OrderByDescending(c => c.FName);
                    break;
                case "LName":
                    contacts = contacts.OrderBy(c => c.LName);
                    break;
                case "lname_desc":
                    contacts = contacts.OrderByDescending(c => c.LName);
                    break;
                default:
                    contacts = contacts.OrderBy(c => c.FName);
                    break;
            }
            return View(await contacts.AsNoTracking().ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                        .Include(c => c.Infos)
                        .AsNoTracking()
                        .FirstOrDefaultAsync(i => i.Id == id);

            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("FName,LName,MName")] Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Contacts.Add(contact);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(contact);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id, [Bind("Id,FName,LName,MName")] Contact contact)
        {
            if (id != contact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return RedirectToAction(nameof(Index));
            }
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }
    }
}
