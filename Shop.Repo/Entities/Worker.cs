﻿using System.ComponentModel.DataAnnotations;

namespace Shop.Repo.Entities
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Last_Name { get; set; } = null!;
        public string? Position { get; set; }
        public decimal? Salary { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Adress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Work_Start_Date { get; set; }
        public DateTime? Work_End_Date { get; set;}
    }
}
