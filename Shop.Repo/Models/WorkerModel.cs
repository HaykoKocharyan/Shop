using Microsoft.EntityFrameworkCore;
using Shop.Repo.Entities;
using Shop.Repo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Repo.Models
{
    public class WorkerModel
    {
        public string Worker_Name { get; set; }
        public string Worker_LastName { get; set; }
        public string? Worker_Position { get; set; }
        public decimal? Worker_Salary { get; set; }
        public string? Worker_Email { get; set; }
        public string? Worker_Phone { get; set; }
        public string? Worker_Adress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? Work_End_Date { get; set; }
    }
}
