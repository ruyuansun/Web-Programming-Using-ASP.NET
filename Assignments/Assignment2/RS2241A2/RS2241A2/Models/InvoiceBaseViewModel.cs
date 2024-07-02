using System;
using System.ComponentModel.DataAnnotations;

namespace RS2241A2.Models
{
   public class InvoiceBaseViewModel
   {
      [Key]
      public int InvoiceId { get; set; }

      [Display(Name = "Customer ID")]
      public int CustomerId { get; set; }

      [StringLength(70)]
      [Display(Name = "Billing Address")]
      public string BillingAddress { get; set; }

      [StringLength(40)]
      [Display(Name = "City")]
      public string BillingCity { get; set; }

      [StringLength(40)]
      [Display(Name = "State")]
      public string BillingState { get; set; }

      [StringLength(40)]
      [Display(Name = "Country")]
      public string BillingCountry { get; set; }

      [StringLength(10)]
      [Display(Name = "Postal/Zip")]
      public string BillingPostalCode { get; set; }

      [DisplayFormat(DataFormatString = "{0:MMM d, yyyy}")]
      [Display(Name = "Date")]
      public DateTime InvoiceDate { get; set; }

      [DisplayFormat(DataFormatString = "{0:C}")]
      [Display(Name = "Total")]
      public decimal Total { get; set; }
   }
}
