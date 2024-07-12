using System.Linq;
using System.Web.Mvc;
using RS2241A3.Controllers;

namespace RS2241A3.Controllers
{
    public class AlbumsController : Controller
    {
      private Manager m = new Manager();

      // GET: Albums
      public ActionResult Index()
      {
         var albums = m.AlbumGetAll();
         return View(albums);
      }
   }
}
