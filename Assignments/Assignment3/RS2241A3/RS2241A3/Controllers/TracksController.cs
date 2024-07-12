using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RS2241A3.Models;

namespace RS2241A3.Controllers
{
   public class TracksController : Controller
   {
      private Manager m = new Manager();

      // GET: Tracks
      public ActionResult Index()
      {
         var tracks = m.TrackGetAllWithDetail();
         return View(tracks);
      }

      // GET: Tracks/Add
      public ActionResult Create()
      {
         var form = m.TrackAddGet();
         return View(form);
      }

      // POST: Tracks/Add
      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Create(TrackAddViewModel newItem)
      {
         if (ModelState.IsValid)
         {
            var addedTrack = m.TrackAdd(newItem);
            if (addedTrack != null)
            {
               return RedirectToAction("Details", new { id = addedTrack.TrackId });
            }
         }
         // If we got this far, something failed, redisplay form
         var form = m.TrackAddGet();
         return View(form);
      }

      // GET: Tracks/Details/5
      public ActionResult Details(int id)
      {
         var track = m.TrackGetById(id);
         if (track == null)
         {
            return HttpNotFound();
         }
         return View(track);
      }

   }
}
