using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeesPractice.Models
{
   public class EmployeeBaseViewModel : EmployeeAddViewModel
   {
      [Key]
      public int EmployeeId { get; set; }


   }
}