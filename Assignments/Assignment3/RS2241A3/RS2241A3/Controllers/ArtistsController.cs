using System.Linq;
using System.Web.Mvc;
using RS2241A3.Controllers;

namespace RS2241A3.Controllers
{
   public class ArtistsController : Controller
   {
      private Manager m = new Manager();

      // GET: Artists
      public ActionResult Index()
      {
         var artists = m.ArtistGetAll();
         return View(artists);
      }
   }
}
