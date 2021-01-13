using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryPattern.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        public int Age { get; set; }

        public DateTime DOJ { get; set; }

        [DataType(DataType.Upload)]
        public string FileName { get; set; }
    }
}
