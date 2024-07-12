using System.ComponentModel.DataAnnotations.Schema;

namespace RegisterLoginPractice.Models
{
   public class Note
   {
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int Id { get; set; }
      public string Name { get; set; }
      public string Description { get; set; }
      public string Title { get; set; }

   }
}
