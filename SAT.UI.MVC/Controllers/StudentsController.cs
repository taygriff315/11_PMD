using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SAT.DATA.EF;
using SAT.UI.MVC.Utilitites;

namespace SAT.UI.MVC.Controllers
{
    public class StudentsController : Controller
    {
        private SATDBEntities db = new SATDBEntities();

        // GET: Students
        [Authorize(Roles = "Admin, Scheduling")]
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.StudentStatus);
            return View(students.ToList());
        }

        // GET: Students/Details/5
        [Authorize(Roles = "Admin, Scheduling")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.SSID = new SelectList(db.StudentStatuses, "SSID", "SSName");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,FirstName,LastName,Major,Address,City,State,ZipCode,Phone,Email,PhotoUrl,SSID")] Student student, HttpPostedFileBase StudentPhoto)
        {
            string file = "noImage.png";
            if (StudentPhoto != null)
            {
                file = StudentPhoto.FileName;

                string ext = file.Substring(file.LastIndexOf("."));
                string[] goodExts = { ".jpg", ".jpeg", ".png", ".gif" };

                if (goodExts.Contains(ext.ToLower()) && StudentPhoto.ContentLength <= 4194304)                {
                    //Create a new file name (use a GUID)
                    file = Guid.NewGuid() + ext;



                    #region Resize Image                    //this informs the program to save the image to this location in our file structure.
                    string savePath = Server.MapPath("~/Content/imgStore/");                    Image convertedImage = Image.FromStream(StudentPhoto.InputStream);                    int maxImageSize = 500;                    int maxThumbSize = 100;                    ImageServices.ResizeImage(savePath, file, convertedImage, maxImageSize, maxThumbSize);


                    #endregion                }


            }

            student.PhotoUrl = file;

            if (ModelState.IsValid)
            {

                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SSID = new SelectList(db.StudentStatuses, "SSID", "SSName", student.SSID);
            return View(student);
        }

        // GET: Students/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.SSID = new SelectList(db.StudentStatuses, "SSID", "SSName", student.SSID);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,FirstName,LastName,Major,Address,City,State,ZipCode,Phone,Email,PhotoUrl,SSID")] Student student, HttpPostedFileBase StudentPhoto)
        {

            if (ModelState.IsValid)
            {
                #region file upload
                #region File Upload
                //1. Added HttpPostedFileBase as a param in the signature for this action that will allow us to capture the file in an obj to manipulate/save this to our file structure.
                //2. We want to store the file name NoImage.png as a string, so we can plug it in where we need this prop to default to.
                //3. Create an if statment, that if the book cover is not null and supplied a cover, reassign the file obj.
                string file = "NoImage.png";
                if (StudentPhoto != null)
                {
                    //The user has uploaded a file to include for that specific book.
                    file = StudentPhoto.FileName;
                    //check that the uploaded file extension matches acepted exts
                    string ext = file.Substring(file.LastIndexOf('.'));
                    string[] goodExts = { ".jpeg", ".jpg", ".png", ".gif" };

                    if (goodExts.Contains(ext.ToLower()) && StudentPhoto.ContentLength <= 4194304)
                    {
                        //Create a new file name (use a GUID)
                        file = Guid.NewGuid() + ext;

                        #region Resize Image
                        //this informs the program to save the image to this location in our file structure.
                        string savePath = Server.MapPath("~/Content/imgStore/");
                        Image convertedImage = Image.FromStream(StudentPhoto.InputStream);
                        int maxImageSize = 500;
                        int maxThumbSize = 100;

                        ImageServices.ResizeImage(savePath, file, convertedImage, maxImageSize, maxThumbSize);
                        #endregion
                        if (student.PhotoUrl != null && student.PhotoUrl != "NoImage.png")
                        {
                            string path = Server.MapPath("~/Content/imgstore/books/");
                            ImageServices.Delete(path, student.PhotoUrl);
                        }
                    }

                }
                //no matter what update the photoUrl with the value of the file variable.
                student.PhotoUrl = file;



                #endregion
                #endregion
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");






                //==========================

          
            }
            ViewBag.SSID = new SelectList(db.StudentStatuses, "SSID", "SSName", student.SSID);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);

            string path = Server.MapPath("~/Content/imgStore/");
            ImageServices.Delete(path, student.PhotoUrl);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult StudentGridView()
        {
            List<Student> students = db.Students.ToList();
            return View(students);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
