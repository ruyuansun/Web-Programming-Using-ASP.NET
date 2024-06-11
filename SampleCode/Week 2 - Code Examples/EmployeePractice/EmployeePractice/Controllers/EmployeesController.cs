using EmployeePractice.Models;
using GetAllGetOne.Models;
using System.Web.Mvc;

namespace EmployeePractice.Controllers
{
   public class EmployeesController : Controller
   {
      private Manager m = new Manager();

      public ActionResult Index()
      {
         return View(m.EmployeeGetAll());
      }

      public ActionResult Details(int? id)
      {
         var obj = m.EmployeeGetById(id.GetValueOrDefault());
         if (obj == null)
            return HttpNotFound();
         else
            return View(obj);
      }

      public ActionResult Create()
      {
         return View();
      }

      [HttpPost]
      public ActionResult Create(EmployeeAddViewModel newItem)
      {
         if (!ModelState.IsValid)
            return View(newItem);

         try
         {
            var addedItem = m.EmployeeAdd(newItem);
            if (addedItem == null)
               return View(newItem);
            else
               return RedirectToAction("Details", new { id = addedItem.EmpId });
         }
         catch
         {
            return View(newItem);
         }
      }

      public ActionResult Edit(int? id)
      {
         var obj = m.EmployeeGetById(id.GetValueOrDefault());
         if (obj == null)
            return HttpNotFound();
         else
         {
            var formObj = m.mapper.Map<EmployeeBaseViewModel, EmployeeEditViewModel>(obj);
            return View(formObj);
         }
      }

      [HttpPost]
      public ActionResult Edit(int? id, EmployeeEditViewModel editedItem)
      {
         if (!ModelState.IsValid)
            return RedirectToAction("Edit", new { id = editedItem.EmpId });

         if (id.GetValueOrDefault() != editedItem.EmpId)
            return RedirectToAction("Index");

         var edited = m.EmployeeEdit(editedItem);

         if (edited == null)
            return RedirectToAction("Edit", new { id = editedItem.EmpId });
         else
            return RedirectToAction("Details", new { id = editedItem.EmpId });
      }

      public ActionResult Delete(int? id)
      {
         var obj = m.EmployeeGetById(id.GetValueOrDefault());
         if (obj == null)
            return HttpNotFound();
         else
            return View(obj);
      }

      [HttpPost]
      public ActionResult Delete(int id, FormCollection collection)
      {
         try
         {
            bool deleted = m.EmployeeDelete(id);
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
