using Movie_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie_App.Controllers
{
    public class CategoryController : Controller
    {
        db_movieEntities db = new db_movieEntities();
        // GET: Category
        public ActionResult Index()
        {
            var category = db.tb_Categories.ToList();
            return View(category);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Categories categories)
        {
            //var isCategoryExist = db.tb_movies.Any(x => x.name.Equals(categories.name));

            //if (isCategoryExist)
            //{
            //    ModelState.AddModelError("Category name", "Category already exits");
            //    return View(categories);
            //}

            Categories c = new Categories();
            c.name = categories.name;
            db.tb_Categories.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int?id)
        {
            Categories c = new Categories();
            c = db.tb_Categories.Where(x => x.catagory_id == id).SingleOrDefault();
            return View(c);
        }
        [HttpPost]
        public ActionResult Edit(int? id, Categories categories)
        {
            Categories c = new Categories();
            c = db.tb_Categories.Where(x => x.catagory_id == id).SingleOrDefault();
            c.name = categories.name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Categories c = new Categories();
            c = db.tb_Categories.Where(x => x.catagory_id == id).SingleOrDefault();
            return View(c);
        }
        [HttpPost]
        public ActionResult Delete(int? id, Categories categories)
        {
            Categories c = new Categories();
            c = db.tb_Categories.Where(x => x.catagory_id == id).SingleOrDefault();
            c.name = categories.name;
            db.tb_Categories.Remove(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            Categories c = new Categories();
            c = db.tb_Categories.Where(x => x.catagory_id == id).SingleOrDefault();
            return View(c);
        }
    }
}