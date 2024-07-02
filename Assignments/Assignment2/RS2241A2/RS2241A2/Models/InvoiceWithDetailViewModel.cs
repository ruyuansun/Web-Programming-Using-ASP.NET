using System.Collections.Generic;

namespace RS2241A2.Models
{
   public class InvoiceWithDetailsViewModel : InvoiceBaseViewModel
   {
      // Customer properties
      public string CustomerFirstName { get; set; }
      public string CustomerLastName { get; set; }
      public string CustomerState { get; set; }
      public string CustomerCountry { get; set; }

      // Employee properties (customer's sales rep)
      public string CustomerEmployeeFirstName { get; set; }
      public string CustomerEmployeeLastName { get; set; }

      // Invoice lines
      public IEnumerable<InvoiceLineWithDetailViewModel> InvoiceLines { get; set; }

   }
}
