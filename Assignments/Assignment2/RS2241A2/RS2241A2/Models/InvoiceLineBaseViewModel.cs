using System.ComponentModel.DataAnnotations;

namespace RS2241A2.Models
{
   public class InvoiceLineBaseViewModel
   {
      [Key]
      [Display(Name = "Line ID")]
      public int InvoiceLineId { get; set; }

      [Display(Name = "Unit Price")]
      [DisplayFormat(DataFormatString = "{0:C}")]
      public decimal UnitPrice { get; set; }

      [Display(Name = "Quantity")]
      public int Quantity { get; set; }

      [Display(Name = "Line Total")]
      [DisplayFormat(DataFormatString = "{0:C}")]
      public decimal LinePrice
      {
         get
         {
            return Quantity * UnitPrice;
         }
      }
   }
}
