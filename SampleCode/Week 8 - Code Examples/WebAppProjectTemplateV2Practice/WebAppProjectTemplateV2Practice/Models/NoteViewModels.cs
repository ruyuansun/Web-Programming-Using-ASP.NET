using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppProjectTemplateV2Practice.Models
{
    public class NoteViewModels
    {
        public NoteAddViewModel()
        {
        }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(100)]
        public string Description { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; }
    }

    public class NoteAddFormViewModel : NoteAddViewModel
    {
        // SelectList for the associated item
        [Display(Name = "Manufacturer Name")]
        public SelectList ManufacturerList { get; set; }

        // Display the name of the associated item, as a composed property name
        public string ManufacturerName { get; set; }
    }
}