using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace RS2241A3.Models
{
    public class TrackBaseViewModel
    {
        [Key]
        public int TrackId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Track name")]
        public string Name { get; set; }

        [StringLength(220)]
        public string Composer { get; set; }

        [Display(Name = "Length (ms)")]
        public int Milliseconds { get; set; }

        [Range(0, 10000)]
        [Display(Name = "Unit price")]
        public decimal UnitPrice { get; set; }

        // Composed read-only property to display full name.
        public string NameFull
        {
            get
            {
                var ms = Math.Round((((double)Milliseconds / 1000) / 60), 1);
                var composer = string.IsNullOrEmpty(Composer) ? "" : ", composer " + Composer;
                var trackLength = (ms > 0) ? ", " + ms.ToString() + " minutes" : "";
                var unitPrice = (UnitPrice > 0) ? ", $ " + UnitPrice.ToString() : "";

                return string.Format("{0}{1}{2}{3}", Name, composer, trackLength, unitPrice);
            }
        }

        // Composed read-only property to display short name.
        public string NameShort
        {
            get
            {
                var ms = Math.Round((((double)Milliseconds / 1000) / 60), 1);
                var trackLength = (ms > 0) ? ms.ToString() + " minutes" : "";
                var unitPrice = (UnitPrice > 0) ? " $ " + UnitPrice.ToString() : "";

                return string.Format("{0} - {1} - {2}", Name, trackLength, unitPrice);
            }
        }
    }

    public class TrackWithDetailViewModel : TrackBaseViewModel
    {
        [Display(Name = "Album title")]
        public string AlbumTitle { get; set; }

        [Display(Name = "Artist name")]
        public string AlbumArtistName { get; set; }

        [Display(Name = "Media type")]
        public MediaTypeBaseViewModel MediaType { get; set; }
    }
    public class TrackAddFormViewModel : TrackAddViewModel
    {
        public TrackAddFormViewModel()
        {
            MediaTypeId = 2; // Default to MPEG audio file
        }

        [Display(Name = "Album")]
        public SelectList AlbumList { get; set; }

        [Display(Name = "Media Type")]
        public SelectList MediaTypeList { get; set; }
    }

    public class TrackAddViewModel : TrackBaseViewModel
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid album")]
        public int AlbumId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid media type")]
        public int MediaTypeId { get; set; }
    }
}