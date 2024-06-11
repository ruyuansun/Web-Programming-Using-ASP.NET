using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeesPractice.Models 
{
   public class EmployeeAddViewModel
   {
      [Required]
      [StringLength(20)]
      public string LastName { get; set; }

      [Required]
      [StringLength(20)]
      public string FirstName { get; set; }

      [StringLength(70)]
      public string Address { get; set; }

      [StringLength(24)]
      public string Phone { get; set; }

      [StringLength(24)]
      public string Fax { get; set; }
   }
}
