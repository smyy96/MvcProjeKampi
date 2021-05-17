using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class istatistikController : Controller
    {
        Context c = new Context();
        // GET: istatistik
        public ActionResult Index()
        {
            var CT = c.Categories.Count().ToString();
            ViewBag.ct = CT;



            var CT2 = c.Headings.Count(x => x.CategoryID == 12).ToString();
            ViewBag.ct2 = CT2;


            var CT3 = (from x in c.Writers select x.WriterName.IndexOf("a"))
                .Distinct().Count().ToString();
            ViewBag.ct3 = CT3;


            var CT4 = c.Categories.Where(x => x.CategoryID == (c.Headings.GroupBy(y => y.CategoryID)
              .OrderByDescending(z => z.Count()).Select(v => v.Key).FirstOrDefault()))
                .Select(q => q.CategoryName).FirstOrDefault();
            ViewBag.ct4 = CT4;



            var CT5 = c.Categories.Count(x => x.CategoryStatus == true);
            var CT55 = c.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.ct5 = Math.Abs(CT55 - CT5).ToString();






            return View();
        }
    }
}