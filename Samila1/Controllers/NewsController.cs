using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Samila1.Data;
using Samila1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Samila1.Controllers
{
    public class NewsController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<IdentityUser> _userManager;

        public NewsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            db = context;
            _userManager = userManager;
        }

        // GET: NewsController
        public ActionResult Index()
        {
            var result = db.News.Include(x => x.Author).ToList();
            return View(result);
        }

        // GET: NewsController/Details/5
        public ActionResult Details(int id)
        {
            News news = db.News.Find(id);

            return View(news);
        }

        // GET: NewsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> Create(News news)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
                news.Author = new IdentityUser();
                news.Author.Id = user.Id;
                news.CreatedDate = DateTime.Now;
                db.News.Add(news);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NewsController/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            News news = db.News.Find(id);

            return View(news);
        }

        // POST: NewsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> Edit(News news)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
                news.Author = new IdentityUser();
                news.Author.Id = user.Id;
                news.CreatedDate = DateTime.Now;
                db.News.Update(news);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NewsController/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            News news = db.News.Find(id);

            return View(news);
        }

        // POST: NewsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Remove(int id)
        {
            try
            {
                News news = db.News.Find(id);
                db.News.Remove(news);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
