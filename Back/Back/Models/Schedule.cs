﻿using System.ComponentModel.DataAnnotations.Schema;

namespace back.Models
{
    public class Schedule
    {
        public int Id { get; set; }     // Идентификатор записи
        public string Subject_Name { get; set; } = null!;
        public string Day { get; set; } = null!;
        public string Time { get; set; } = null!;

        // Navigation properties
        public Group Group { get; set; } = null!;
    }
}
