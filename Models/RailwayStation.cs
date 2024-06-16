using System;
using System.Collections.Generic;

namespace Filters.Models;

public partial class RailwayStation
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? StationCode { get; set; }

    public int? NumberOfTracks { get; set; }
}
