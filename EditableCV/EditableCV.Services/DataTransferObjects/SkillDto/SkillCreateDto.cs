﻿using System.ComponentModel.DataAnnotations;

namespace EditableCV.Services.SkillDto
{
    public class SkillCreateDto
  {
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
  }
}