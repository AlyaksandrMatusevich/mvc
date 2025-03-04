using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using appmvc.Data;
using appmvc.Models;
using Microsoft.AspNetCore.Authorization;

namespace appmvc.Controllers
{
    public class ContactInfoesController : Controller
    {
        private readonly PhoneBookContext _context;

        public ContactInfoesController(PhoneBookContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var phoneBookContext = _context.ContactInfos.Include(c => c.Contact);
            return View(await phoneBookContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var contactInfo = await _context.ContactInfos
                .Include(c => c.Contact)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactInfo == null)
            {
                return NotFound();
            }

            return View(contactInfo);
        }

        [Authorize]
        public IActionResult Create(int? id)
        {
            ViewData["ContactId"] = id;
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Phone,Note,ContactId")] ContactInfo contactInfo)
        {
            if (ModelState.IsValid)
            {
                _context.ContactInfos.Add(contactInfo);
                await _context.SaveChangesAsync();
            }
            ViewData["ContactId"] = new SelectList(_context.Contacts, "Id", "Id", contactInfo.ContactId);
            return Redirect("~/Contacts/Index");
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var contactInfo = await _context.ContactInfos.FindAsync(id);
            if (contactInfo == null)
            {
                return NotFound();
            }
            return View(contactInfo);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,Phone,Note,ContactId")] ContactInfo contactInfo)
        {
            if (id != contactInfo.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactInfoExists(contactInfo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect("~/Contacts/Index");
            }
            ViewData["ContactId"] = new SelectList(_context.Contacts, "Id", "Id", contactInfo.ContactId);
            return View(contactInfo);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactInfo = await _context.ContactInfos
                .Include(c => c.Contact)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactInfo == null)
            {
                return NotFound();
            }

            return View(contactInfo);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var contactInfo = await _context.ContactInfos.FindAsync(id);
            if (contactInfo == null)
            {
                return RedirectToAction(nameof(Index));
            }
            _context.ContactInfos.Remove(contactInfo);
            await _context.SaveChangesAsync();
            return Redirect("~/Contacts/Index");
        }

        private bool ContactInfoExists(int id)
        {
            return _context.ContactInfos.Any(e => e.Id == id);
        }
    }
}
