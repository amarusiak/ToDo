using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ToDo.Entities;

namespace ToDo.WebUI.Models
{
    public class TaskModel
    {
            [Required(ErrorMessage = "Please enter Id")]
            public int Id { get; set; }

            [Required(ErrorMessage = "Please enter Title")]
            [RegularExpression(".+\\@.+\\..+",
                ErrorMessage = "Please enter a valid Title address")]
            public string Title { get; set; }

            [Required(ErrorMessage = "Please specify IsDone")]
            public bool IsDone { get; set; }
    }
}