using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        ApplicationDbContext db;
        public NewsController(ApplicationDbContext context)
        {
            db = context;
        }

        // GET: NewsController
        public ActionResult Index()
        {
            return View(db.News.ToList());
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
        public ActionResult Create(News news)
        {
            try
            {
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
        public ActionResult Edit(int id)
        {
            News news = db.News.Find(id);

            return View(news);
        }

        // POST: NewsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(News news)
        {
            try
            {
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
        public ActionResult Delete(int id)
        {
            News news = db.News.Find(id);

            return View(news);
        }

        // POST: NewsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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
