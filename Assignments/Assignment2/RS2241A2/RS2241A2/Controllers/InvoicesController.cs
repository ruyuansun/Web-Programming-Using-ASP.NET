using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RS2241A2.Data;

namespace RS2241A2.Controllers
{
   public class InvoicesController : Controller
   {
      private Manager m = new Manager();

      // GET: Invoices
      public ActionResult Index()
      {
         var invoices = m.InvoiceGetAll();
         return View(invoices.ToList());
      }

      // GET: Invoices/Details/5
      public ActionResult Details(int? id)
      {
         if (id == null)
         {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }
         var invoice = m.InvoiceGetByIdWithDetail(id.Value);
         if (invoice == null)
         {
            return HttpNotFound();
         }
         return View(invoice);
      }
   }
}
