using System;
using System.Collections.Generic;

namespace PaktolusApp.Models;

public partial class Hobby
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool Active { get; set; }

    public virtual ICollection<Student> Students { get; } = new List<Student>();
}
