using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PipingRockERP.Controllers
{
    public class NutritionController : Controller
    {
        // GET: Nutrition
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add(string param)
        {
            return View(param);
        }

        #region Allergens
        public ActionResult Allergens()
        {
            PipingRockEntities db = new PipingRockEntities();

            var allergens = (from Allergen in db.Allergens select Allergen).ToList();

            return View(allergens);
        }

        public ActionResult EditAllergen(string allergenId)
        {
            PipingRockEntities db = new PipingRockEntities();
            int ID = Int32.Parse(allergenId);

            var allergen = (from Allergen in db.Allergens
                            where Allergen.AllergenId == ID
                      select Allergen).ToList();

            ViewBag.Allergen = allergen;

            return View();
        }

        public ActionResult SubmitAllergenAdd(string allergenName)
        {
            PipingRockEntities db = new PipingRockEntities();

            var allergen = new Allergen()
            {
                Allergen1 = allergenName,
                AllergenAddedDate = DateTime.Now,
                AllergenChangedDate = DateTime.Now,
                AllergenModifiedById = 0,
                isDeleted = false
            };
            db.Allergens.Add(allergen);
            db.SaveChanges();
            return RedirectToAction("Allergens");
        }

        public ActionResult SubmitAllergenUpdate(string allergenId, string allergenName)
        {
            PipingRockEntities db = new PipingRockEntities();

            int ID = Int32.Parse(allergenId);
            var qt = (from Allergen in db.Allergens
                      where Allergen.AllergenId == ID
                      select Allergen).Single();

            qt.Allergen1 = allergenName;
            qt.AllergenChangedDate = DateTime.Now;

            db.Entry(qt).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Allergens");
        }

        public ActionResult ExportAllergen()
        {
            PipingRockEntities db = new PipingRockEntities();

            GridView gv = new GridView();
            gv.DataSource = (from Allergen in db.Allergens
                             select new
                             {
                                 Id = Allergen.AllergenId,
                                 Quarantine = Allergen.Allergen1,
                                 AddedDate = Allergen.AllergenAddedDate,
                                 ChangedDate = Allergen.AllergenChangedDate,
                                 DeletedDate = Allergen.AllergenDeletedDate,
                                 ModifiedById = Allergen.AllergenModifiedById,
                                 isDeleted = (Allergen.isDeleted ? 1 : 0)

                             }).ToList();
            gv.GridLines = GridLines.Both;
            gv.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=Allergens.xls");
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            return RedirectToAction("Allergens");
        }
        #endregion
    }
}