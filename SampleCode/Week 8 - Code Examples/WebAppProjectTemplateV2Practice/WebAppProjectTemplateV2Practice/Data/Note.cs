using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebAppProjectTemplateV2Practice.Data
{
    public class Note
    {      
    }

    public int Id { get; set; }

    [Required, StringLength(100)]
    public string Name { get; set; }

    [Required, StringLength(100)]
    public string Description { get; set; }

    [Required, StringLength(100)]
    public string Title { get; set; }
}