using Core.Entity;
using DAL.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Member: BaseEntity, IEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Job { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public string InstagramLink { get; set; }

        [Required]
        public string TwiterLink { get; set; }

        [Required]
        public string FacebookLink { get; set; }

        [Required]
        public string LinkedinLink { get; set; }

        [Required]
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
