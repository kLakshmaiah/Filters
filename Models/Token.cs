﻿using System;
using System.Collections.Generic;

namespace Filters.Models;

public partial class Token
{
    public string? RefreshToken { get; set; }

    public DateTime? RefreshTokenExpiryTime { get; set; }

    public int? RoleId { get; set; }

    public string? UserName { get; set; }

    public int Id { get; set; }
}
