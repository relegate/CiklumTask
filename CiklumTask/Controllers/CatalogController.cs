using AutoMapper;
using CiklumTask.Models;
using CiklumTask.Modules.ItemsParser;
using CiklumTask.Repository;
using CiklumTask.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Helpers;
using System.Web.Mvc;

namespace CiklumTask.Controllers
{
    public class CatalogController : Controller
    {
        IUnitOfWork db;

        public CatalogController()
        {
            db = new UnitOfWork();
        }

        public CatalogController(IUnitOfWork db)
        {
            this.db = db;
        }

        [HttpGet]
        public JsonResult FillIndex()
        {
            var products = db.ProductRepository.GetAll().ToList();
            foreach (var p in products)
            {
                if (p.Pics.Count == 0)
                {
                    p.Pics.Add(new Pics { url_pic = "/Content/Images/Serp/no-image.png" });
                }
            }

            List<ProductVM> viewModels = Mapper.Map<List<ProductVM>>(products);

            return Json(viewModels, JsonRequestBehavior.AllowGet);
        }

        // GET: Products
        public ActionResult Index()
        {
            return View("Index");
        }

        // GET: Products/Details/5
        public ActionResult ViewDetails(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction(actionName: nameof(Index), controllerName: "CatalogController");
            }
            ProductVM product = Mapper.Map<ProductVM>(db.ProductRepository.Get((int)id));
            if (product == null)
            {
                return HttpNotFound();
            }

            if (product.Images.Count == 0)
            {
                product.Images.Add("/Content/Images/Serp/no-image.png");
            }
            return View("Details", product);
        }

        public ActionResult EfficiencyChart(ProductVM product)
        {
            var prices =  db.PriceRepository.GetAll().Where(p => p.id_product == product.Id).ToList();
            var myChart = new Chart(width: 500, height: 300)
            .AddTitle("Динамика изменения цен")
            .AddSeries(
                name: "Employee",
                xValue: prices.Select(p => p.date).ToList(),
                yValues: prices.Select(p => p.price).ToList())
            .Write();

            myChart.Save("~/Content/chart" + prices.First().id_product, "jpeg");
            // Return the contents of the Stream to the client
            return File("~/Content/chart" + prices.First().id_product, "jpeg");
        }
    }
}
