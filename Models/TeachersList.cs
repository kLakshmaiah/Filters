using System;
using System.Collections.Generic;

namespace Filters.Models;

public partial class TeachersList
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int Salary { get; set; }

    public string? TeachingClasses { get; set; }
}
