﻿using System.ComponentModel.DataAnnotations;

namespace CatchMore.Models
{
    public abstract class DataEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
