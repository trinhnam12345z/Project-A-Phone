﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aphone.Models
{
    public class Products
    {
        public int Id { get; set; }
        [Required]
        public string  Name { get; set; }
        [Required]
        public string  Description { get; set; }
        [Required]
        public string  Image { get; set; }
        [Required]
        public int Price { get; set; }
        public int CategoriesId { get; set; }
        public Categories Categories { get; set; }

    }
}
