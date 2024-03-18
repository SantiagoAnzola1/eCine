﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCine.Models
{
    public class OrderItem
    {

        [Key]
        public int Id { get; set; }

        public int Amount { get; set; }
        public double Price { get; set; }

        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public virtual NewMovieModel  Movie { get; set; }
        
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order  Order { get; set; }


    }
}
