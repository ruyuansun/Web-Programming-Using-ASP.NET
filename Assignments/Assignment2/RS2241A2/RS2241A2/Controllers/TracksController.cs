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
   public class TracksController : Controller
   {
      private Manager m = new Manager();

      // GET: Tracks
      public ActionResult Index()
      {
         var tracks = m.TrackGetAll();
         return View(tracks.ToList());
      }

      // GET: Tracks/BluesJazz
      public ActionResult BluesJazz()
      {
         var tracks = m.TrackGetBluesJazz();
         return View("Index", tracks);
      }

      // GET: Tracks/CantrellStaley
      public ActionResult CantrellStaley()
      {
         var tracks = m.TrackGetCantrellStaley();
         return View("Index", tracks);
      }

      // GET: Tracks/Top50Longest
      public ActionResult Top50Longest()
      {
         var tracks = m.TrackGetTop50Longest();
         return View("Index", tracks);
      }

      // GET: Tracks/Top50Smallest
      public ActionResult Top50Smallest()
      {
         var tracks = m.TrackGetTop50Smallest();
         return View("Index", tracks);
      }
   }
}
