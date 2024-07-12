using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RS2241A3.Models
{
    public class PlaylistBaseViewModel
    {
        [Key]
        public int PlaylistId { get; set; }

        [StringLength(120)]
        public string Name { get; set; }

        public int TracksCount { get; set; }
    }

    public class PlaylistEditTracksViewModel : PlaylistBaseViewModel
    {
        public IEnumerable<int> SelectedTracks { get; set; }
    }

    public class PlaylistEditTracksFormViewModel : PlaylistEditTracksViewModel
    {
        public MultiSelectList TrackList { get; set; } // Selection list of all tracks

        public IEnumerable<TrackBaseViewModel> Tracks { get; set; } // Tracks in the current playlist
    }
}