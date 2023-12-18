using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Repo.Entities
{
    public class Workers
    {
        public int Id { get; set; }
        [Required]
        public string Worker_Name { get; set; }
        [Required]
        public string Worker_LastName { get; set; }
        [Required]
        public string? Worker_Position { get; set; }
        [Required]
        public decimal? Worker_Salary { get; set; }
        public string? Worker_Email { get; set; }
        public string? Worker_Phone { get; set; }
        public string? Worker_Adress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Work_Start_Date { get; set; }
        public DateTime? Work_End_Date { get; set;}
    }
}
