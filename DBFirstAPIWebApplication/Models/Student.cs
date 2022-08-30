using System;
using System.Collections.Generic;

namespace DBFirstAPIWebApplication.Models
{
    public partial class Student
    {
        public int StudId { get; set; }
        public string? Name { get; set; }
        public int? DepartId { get; set; }

        public virtual Department? Depart { get; set; }
    }
}
