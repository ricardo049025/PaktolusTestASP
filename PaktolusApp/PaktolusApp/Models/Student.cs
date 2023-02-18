﻿using System;
using System.Collections.Generic;

namespace PaktolusApp.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public virtual ICollection<Hobby> Hobbies { get; set; } = new List<Hobby>();
}
