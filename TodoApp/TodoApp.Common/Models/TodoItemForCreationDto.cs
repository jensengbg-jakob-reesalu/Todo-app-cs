﻿using System.ComponentModel.DataAnnotations;

namespace TodoApp.Common.Models
{
    public class TodoItemForCreationDto
    {
        [Required]
        public string Text { get; set; }

        public bool IsDone { get; set; } = false;
    }
}
