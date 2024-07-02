using System;
using System.ComponentModel.DataAnnotations;

namespace RS2241A2.Models
{
   public class TrackBaseViewModel
   {
      [Key]
      public int TrackId { get; set; }

      [Required, StringLength(200)]
      [Display(Name = "Track Name")]
      public string Name { get; set; }

      [StringLength(220)]
      [Display(Name = "Composer Name")]
      public string Composer { get; set; }

      [Range(0, 10000)]
      [DisplayFormat(DataFormatString = "{0:C}")]
      [Display(Name = "Price")]
      public decimal UnitPrice { get; set; }

      [Display(Name = "Length (ms)")]
      public int Milliseconds { get; set; }

      [Display(Name = "Size (bytes)")]
      public int? Bytes { get; set; }

      [Display(Name = "Album")]
      public string AlbumTitle { get; set; }

      [Display(Name = "Genre")]
      public string GenreName { get; set; }
   }
}
