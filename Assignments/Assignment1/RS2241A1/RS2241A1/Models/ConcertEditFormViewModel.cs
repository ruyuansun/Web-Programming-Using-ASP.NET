using System;
using System.ComponentModel.DataAnnotations;

namespace RS2241A1.Models
{
   public class ConcertEditFormViewModel
   {
      [Key]
      public int ConcertId { get; set; }

      public string Name { get; set; }
      public string Company { get; set; }
      public string Address { get; set; }
      public string City { get; set; }
      public string State { get; set; }
      public string Country { get; set; }
      public string PostalCode { get; set; }
      public string Phone { get; set; }
      public string Email { get; set; }
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