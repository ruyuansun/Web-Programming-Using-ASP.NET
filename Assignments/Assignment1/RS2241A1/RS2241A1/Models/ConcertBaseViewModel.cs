using System;
using System.ComponentModel.DataAnnotations;

namespace RS2241A1.Models
{
   public class ConcertBaseViewModel : ConcertAddViewModel
   {
      [Key]
      public int ConcertId { get; set; }

      public string DaysToGo
      {
         get
         {
            var now = DateTime.Now.Date;
            if (ConcertDate < now)
            {
               return "No longer available";
            }
            else
            {
               var days = Math.Floor((ConcertDate - now).TotalDays);
               return days == 1.0 ? "Tomorrow" : $"{days:n0} days to go";
            }
         }
      }

      public string FormattedConcertDate
      {
         get { return ConcertDate.ToString("yyyy-MM-dd"); }
      }
   }
}
