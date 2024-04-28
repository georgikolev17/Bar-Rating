using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bar_Rating.Data;
using Bar_Rating.Models;
using Microsoft.AspNetCore.Identity;

namespace Bar_Rating.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager;

        public UsersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
              return userManager.Users != null ? 
                          View(await userManager.Users.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.DummyUser'  is null.");
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DummyUser == null)
            {
                return NotFound();
            }

            var dummyUser = await _context.DummyUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dummyUser == null)
            {
                return NotFound();
            }

            return View(dummyUser);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.DummyUser == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DummyUser'  is null.");
            }
            var dummyUser = await userManager.FindByIdAsync(id);
            if (dummyUser != null)
            {
                userManager.DeleteAsync(dummyUser);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool DummyUserExists(string id)
        {
          return (_context.DummyUser?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
