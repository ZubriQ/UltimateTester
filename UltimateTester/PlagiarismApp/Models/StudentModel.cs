﻿using System.ComponentModel.DataAnnotations;

namespace PlagiarismApp.Models
{
    public class StudentModel
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string Surname { get; set; }

        [MaxLength(50)]
        public string? Patronymic { get; set; }

        [Required]
        public int SelectedGroupId { get; set; }

        public StudentModel()
        {

        }
    }
}
