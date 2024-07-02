using System.ComponentModel.DataAnnotations;

namespace RS2241A2.Models
{
   public class InvoiceLineWithDetailViewModel : InvoiceLineBaseViewModel
   {
      [Display(Name = "Track")]
      public string TrackName { get; set; }
      public string TrackComposer { get; set; }

      [Display(Name = "Album")]
      public string TrackAlbumTitle { get; set; }

      [Display(Name = "Artist")]
      public string TrackAlbumArtistName { get; set; }

      [Display(Name = "Genre")]
      public string TrackGenreName { get; set; }

      [Display(Name = "MediaType")]
      public string TrackMediaType { get; set; }
   }
}
