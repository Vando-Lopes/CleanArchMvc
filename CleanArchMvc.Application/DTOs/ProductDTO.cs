﻿using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "The Description is required")]
        [MinLength(5)]
        [MaxLength(200)]
        [DisplayName("Name")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "The Price is required")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public required decimal Price { get; set; }

        [Required(ErrorMessage = "The Stock is required")]
        [Range(1, 9999)]
        [DisplayName("Stock")]
        public required int Stock { get; set; }

        [MaxLength(250)]
        [DisplayName("Product Image")]
        public required string Image { get; set; }

        public Category? Category { get; set; }

        public int CategoryId { get; set; }
    }
}
