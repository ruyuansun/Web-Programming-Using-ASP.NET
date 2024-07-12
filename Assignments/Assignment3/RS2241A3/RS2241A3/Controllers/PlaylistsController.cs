using System.Linq;
using System.Web.Mvc;
using RS2241A3.Controllers;
using RS2241A3.Models;

namespace RS2241A3.Controllers
{
   public class PlaylistsController : Controller
   {
      private Manager m = new Manager();

      // GET: Playlists
      public ActionResult Index()
      {
         var playlists = m.PlaylistGetAll();
         return View(playlists);
      }

        // GET: Playlists/Edit/5
        public ActionResult Edit(int id)
        {
            var playlist = m.PlaylistGetById(id);
            if (playlist == null)
            {
                return HttpNotFound();
            }
            return View(playlist);
        }

        // POST: Playlists/Edit/5
        public ActionResult Edit(PlaylistEditTracksFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                m.PlaylistEditTracks(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Playlists/Details/5
        public ActionResult Details(int id)
      {
         var playlist = m.PlaylistGetById(id);
         if (playlist == null)
         {
            return HttpNotFound();
         }
         return View(playlist);
      }

   }
}
