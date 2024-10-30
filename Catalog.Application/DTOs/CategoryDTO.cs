using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.DTOs;

public class CategoryDTO
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Fill with the category name")]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Name { get; set; }
    [Required(ErrorMessage = "Fill with the image name")]
    [MinLength(5)]
    [MaxLength(250)]
    public string? ImageUrl { get; set; }

}
