using AppTest.WCFCursosClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AppTest.Controllers
{
    public class HomeController : Controller
    {
        WCFCursosClient.WCFCursosClient service { get; set; }
        public ActionResult Index() {
            return View();
        }
        public JsonResult ListIndex() {
            service = new WCFCursosClient.WCFCursosClient();
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = service.getList() };
        }
        public ActionResult Item() {
            return View();
        }
        public JsonResult ItemSearch(int id) {
            service = new WCFCursosClient.WCFCursosClient();
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = service.getId(id) };
        }

        public ActionResult ItemId(int? id){
            return id.HasValue ? View("Item", id) : View();
        }
        public JsonResult Set(Curso curso){
            service = new WCFCursosClient.WCFCursosClient();
            return new JsonResult { Data = service.Set(curso) };
        }
        public JsonResult Delete(int id){
            service = new WCFCursosClient.WCFCursosClient();
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = service.Delete(id) };
        }

        public JsonResult GetCatalogosModalidades(){
            service = new WCFCursosClient.WCFCursosClient();
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = service.getAllModalidades() };
        }
        public JsonResult GetCatalogosPaises(){
            service = new WCFCursosClient.WCFCursosClient();
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = service.getAllPaises() };
        }
        public JsonResult GetCatalogosCiudades(int id){
            service = new WCFCursosClient.WCFCursosClient();
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = service.getAllCiudades(id) };
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}