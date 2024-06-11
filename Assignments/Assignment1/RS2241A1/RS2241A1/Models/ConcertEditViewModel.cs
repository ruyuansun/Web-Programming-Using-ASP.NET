using System;
using System.ComponentModel.DataAnnotations;

namespace RS2241A1.Models
{
   public class ConcertEditViewModel
   {
      [Key]
      public int ConcertId { get; set; }

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
      public string Email { get; set; }

      [StringLength(100)]
      public string Website { get; set; }

      public DateTime ConcertDate { get; set; }

      // Additional properties for display and validation
      [StringLength(20)]
      public string TicketSalePassword { get; set; }

      [StringLength(10)]
      public string PromoCode { get; set; }

      [Range(0, 100000)]
      public int Capacity { get; set; }
   }
}
