using System.ComponentModel.DataAnnotations;

namespace RS2241A3.Models
{
   public class MediaTypeBaseViewModel
   {
      [Key]
      public int MediaTypeId { get; set; }
      public string Name { get; set; }
   }
}
