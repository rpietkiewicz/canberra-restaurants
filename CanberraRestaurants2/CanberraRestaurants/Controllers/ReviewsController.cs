using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CanberraRestaurants.Data;
using CanberraRestaurants.Models;

namespace CanberraRestaurants.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reviews
        public async Task<IActionResult> Index()
        {
            return View(await _context.Review.ToListAsync());
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Review
                .SingleOrDefaultAsync(m => m.Id == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // GET: Reviews/Create
        public IActionResult Create()
        {
            Review review = new Review();
            review.Rating = "0";
            review.Date = DateTime.Now;
            /*review.Name = Name.Now;*----need to add method in the Create.cshtml its not a get method*/
            return View(review);                 
        }
        
        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Name,Heading,Restaurant,Comment,Rating")] Review review)
        {
            if (ModelState.IsValid)
            {
                review.Date = DateTime.Now.ToLocalTime();

                _context.Add(review);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(review);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }       

            var review = await _context.Review.SingleOrDefaultAsync(m => m.Id == id);
            if (review == null)
            {
                return NotFound();
            }
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Name,Heading,Restaurant,Comment,Rating")] Review review)
        {
            if (id != review.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            { /*review.Date = DateTime.Now.ToLocalTime(); - need to add method for DateTime into the POST:Review/Edit*/
                try
                {
                    _context.Update(review);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewExists(review.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(review);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Review
                .SingleOrDefaultAsync(m => m.Id == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var review = await _context.Review.SingleOrDefaultAsync(m => m.Id == id);
            _context.Review.Remove(review);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ReviewExists(int id)
        {
            return _context.Review.Any(e => e.Id == id);
        }


       /*No View: Reviews/Agree/5 for increaing rating on Agree button*/
        public async Task<IActionResult> Disagree(int? id)
        {
            var review = await _context.Review.SingleOrDefaultAsync(m => m.Id == id);
       
            if (ModelState.IsValid && review.IsClicked == false && User.Identity.IsAuthenticated)
            {
                review.Disagree++;
                review.IsClicked = true;
                _context.Update(review);
                await _context.SaveChangesAsync();
            }
           
            return RedirectToAction("Index", "Reviews");
        }
        public async Task<IActionResult> Agree(int? id)
        {
            var review = await _context.Review.SingleOrDefaultAsync(m => m.Id == id);

            if (ModelState.IsValid && review.IsClicked == false && User.Identity.IsAuthenticated)
            {
                review.Agree++;
                review.IsClicked = true;
                _context.Update(review);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Reviews");
        }

    }
}
/*No View: Reviews/DisAgree/5 for increaing rating on DisAgree button*/

