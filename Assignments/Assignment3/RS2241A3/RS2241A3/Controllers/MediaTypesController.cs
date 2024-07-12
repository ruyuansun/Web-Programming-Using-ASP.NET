using System.Linq;
using System.Web.Mvc;
using RS2241A3.Controllers;

namespace RS2241A3.Controllers
{
   public class MediaTypesController : Controller
   {
      private Manager m = new Manager();

      // GET: MediaTypes
      public ActionResult Index()
      {
         var mediaTypes = m.MediaTypeGetAll();
         return View(mediaTypes);
      }
   }
}
