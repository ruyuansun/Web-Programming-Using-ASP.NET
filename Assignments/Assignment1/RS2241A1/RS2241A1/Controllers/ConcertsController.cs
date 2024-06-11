using RS2241A1.Models;
using System.Web.Mvc;

namespace RS2241A1.Controllers
{
   public class ConcertsController : Controller
   {
      // Reference to a manager object
      private Manager m = new Manager();

      // GET: Concerts
      public ActionResult Index()
      {
         return View(m.ConcertGetAll());
      }

      // GET: Concerts/Details/5
      public ActionResult Details(int? id)
      {
         // Attempt to get the matching object
         var obj = m.ConcertGetById(id.GetValueOrDefault());

         if (obj == null)
            return HttpNotFound();
         else
            return View(obj);
      }

      // GET: Concerts/Create
      public ActionResult Create()
      {
         // Optionally create and send an object to the view
         return View();
      }

      // POST: Concerts/Create
      [HttpPost]
      public ActionResult Create(ConcertAddViewModel newItem)
      {
         // Validate the input
         if (!ModelState.IsValid)
            return View(newItem);

         try
         {
            // Process the input
            var addedItem = m.ConcertAdd(newItem);

            // If the item was not added, return the user to the Create page
            // otherwise redirect them to the Details page.
            if (addedItem == null)
               return View(newItem);
            else
               return RedirectToAction("Details", new { id = addedItem.ConcertId });
         }
         catch
         {
            return View(newItem);
         }
      }

      // GET: Concerts/Edit/5
      public ActionResult Edit(int? id)
      {
         // Attempt to get the matching object
         var obj = m.ConcertGetById(id.GetValueOrDefault());

         if (obj == null)
            return HttpNotFound();
         else
         {
            var formObj = m.mapper.Map<ConcertBaseViewModel, ConcertEditFormViewModel>(obj);
            return View(formObj);
         }
      }

      // POST: Concerts/Edit/5
      [HttpPost]
      public ActionResult Edit(int? id, ConcertEditViewModel editedItem)
      {
         if (!ModelState.IsValid)
            return RedirectToAction("Edit", new { id = editedItem.ConcertId });

         if (id.GetValueOrDefault() != editedItem.ConcertId)
            return RedirectToAction("Index");

         var edited = m.ConcertEdit(editedItem);

         if (edited == null)
            return RedirectToAction("Edit", new { id = editedItem.ConcertId });
         else
            return RedirectToAction("Details", new { id = editedItem.ConcertId });
      }


      // GET: Concerts/Delete/5
      public ActionResult Delete(int? id)
      {
         // Attempt to get the matching object
         var obj = m.ConcertGetById(id.GetValueOrDefault());

         if (obj == null)
            return HttpNotFound();
         else
            return View(obj);
      }

      // POST: Concerts/Delete/5
      [HttpPost]
      public ActionResult Delete(int id, FormCollection collection)
      {
         try
         {
            // Process the input
            bool deleted = m.ConcertDelete(id);

            if (!deleted)
               return HttpNotFound();
            else
               return RedirectToAction("Index");
         }
         catch
         {
            return View();
         }
      }
   }
}
