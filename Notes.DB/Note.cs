﻿using System.ComponentModel.DataAnnotations;
namespace Notes.DB
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public string value { get; set; }
    }
}
