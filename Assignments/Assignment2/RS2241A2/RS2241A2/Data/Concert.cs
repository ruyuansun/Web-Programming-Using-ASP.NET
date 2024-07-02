using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS2241A2.Data
{
   [Table("Concert")]
   public class Concert
   {

      #region Columns

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

      #endregion

   }
}
