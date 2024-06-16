using System;
using System.Collections.Generic;

namespace Filters.Models;

public partial class StudentsList
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? StudentId { get; set; }

    public string? StudentDescription { get; set; }
}
