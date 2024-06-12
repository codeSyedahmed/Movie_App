using Movie_App.Models;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie_App.Controllers
{
    public class MovieController : Controller
    {
        db_movieEntities db = new db_movieEntities();
        // GET: Movie
        public ActionResult Index()
        {

            return View(db.tb_movies.ToList());

        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CategoriesList = new SelectList(db.tb_Categories, "catagory_id", "name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase imageFile, Movie movie)
        {
            ViewBag.CategoriesList = new SelectList(db.tb_Categories, "catagory_id", "name");
            //var isMovieExist = db.tb_movies.Any(x => x.name.Equals(movie.name));

            //if (isMovieExist)
            //{
            //    ModelState.AddModelError("Movie name", "Movie already exits");
            //    return View(movie);
            //}


            Movie m = new Movie();
            m.name = movie.name;
            m.image = movie.image;
            m.description = movie.description;
            m.cat_id = movie.cat_id;
            string fileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
            string extension = Path.GetExtension(imageFile.FileName);
            fileName = fileName + extension;
            m.image = "~/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
            imageFile.SaveAs(fileName);
            db.tb_movies.Add(m);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Movie m = new Movie();
            m = db.tb_movies.Where(x => x.movie_id == id).SingleOrDefault();
            ViewBag.CategoriesList = new SelectList(db.tb_Categories, "catagory_id", "name");
            Session["Image"] = m.image;
            return View(m);
        }
        [HttpPost]
        public ActionResult Edit(int? id, HttpPostedFileBase imageFile, Movie movie)
        {
            ViewBag.CategoriesList = new SelectList(db.tb_Categories, "catagory_id", "name");

            Movie m = new Movie();
            m = db.tb_movies.Where(x => x.movie_id == id).SingleOrDefault();
            m.name = movie.name;
            m.image = movie.image;
            m.description = movie.description;
            m.cat_id = movie.cat_id;
            if (m.image != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
                string extension = Path.GetExtension(imageFile.FileName);
                fileName = fileName + extension;
                m.image = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                imageFile.SaveAs(fileName);
                db.Entry(m).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                m.image = Session["Image"].ToString();
                db.Entry(m).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Movie m = new Movie();
            m = db.tb_movies.Where(x => x.movie_id == id).SingleOrDefault();
            return View(m);
        }
        [HttpPost]
        public ActionResult Delete(int? id, Movie movie)
        {

            Movie m = new Movie();
            m = db.tb_movies.Where(x => x.movie_id == id).SingleOrDefault();
            m.name = movie.name;
            m.image = movie.image;
            m.description = movie.description;
            m.cat_id = movie.cat_id;
            db.tb_movies.Remove(m);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            Movie m = new Movie();
            m = db.tb_movies.Where(x => x.movie_id == id).SingleOrDefault();
            return View(m);
        }
    }
}