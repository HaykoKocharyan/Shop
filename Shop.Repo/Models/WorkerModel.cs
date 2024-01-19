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
        public string Name { get; set; } = null!;
        public string Last_Name { get; set; } = null!;
        public string? Position { get; set; }
        public decimal? Salary { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Adress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? Work_End_Date { get; set; }
    }
}
