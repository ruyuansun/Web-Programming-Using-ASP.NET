using System.ComponentModel.DataAnnotations;

namespace RS2241A3.Models
{
   public class ArtistBaseViewModel
   {
      [Key]
      public int ArtistId { get; set; }
      public string Name { get; set; }
   }
}
