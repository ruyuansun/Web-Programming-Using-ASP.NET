using System;
using System.ComponentModel.DataAnnotations;

namespace RS2241A1.Models
{
   public class ConcertAddViewModel
   {
      [Required]
      [StringLength(128)]
      public string Name { get; set; }

      [Required]
      [StringLength(80)]
      public string Company { get; set; }

      [StringLength(70)]
      public string Address { get; set; }

      [StringLength(40)]
      public string City { get; set; }

      [StringLength(40)]
      public string State { get; set; }

      [StringLength(40)]
      public string Country { get; set; }

      [StringLength(10)]
      public string PostalCode { get; set; }

      [StringLength(24)]
      public string Phone { get; set; }

      [StringLength(100)]
      [EmailAddress]
      public string Email { get; set; }

      [StringLength(100)]
      [Url]
      public string Website { get; set; }

      [Required]
      public DateTime ConcertDate { get; set; }
   }
}
