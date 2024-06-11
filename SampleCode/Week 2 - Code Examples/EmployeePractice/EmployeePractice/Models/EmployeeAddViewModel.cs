using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeePractice.Models
{
   public class EmployeeAddViewModel
   {
      [Required]
      [StringLength(100)]
      public string EmpName { get; set; }

      [StringLength(200)]
      public string EmpAddress { get; set; }

      [StringLength(15)]
      public string EmpPhoneNumber { get; set; }

      [StringLength(15)]
      public string EmpFaxNumber { get; set; }
   }
}
