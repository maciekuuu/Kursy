﻿namespace Kursy.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Mail { get; set; }
        public Course Course { get; set; }
    }
}
