using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task1.Models
{
    public class Create
    {
        public int Dept_Id { get; set; }
        [Required(ErrorMessage = "Please put your name")]
        [MaxLength(50, ErrorMessage = "Max Length 50")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please put DATE OF BIRTH")]
        public string DOB { get; set; }
        [Required]
        [Range(1, 148)]
        public int Credit { get; set; }
        [Required]
        public double CGPA { get; set; }

        public Department Department { get; set; }
    }
}