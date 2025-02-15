﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
   public  class Explore
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(100)]
        public string SubTitle { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        public string ? ImgUrl{ get; set; }
        [NotMapped]
        public IFormFile? PhotoFile { get; set; }

    }
}
