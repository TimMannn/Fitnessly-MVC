﻿using System;
using System.Collections.Generic;

namespace DAL.EntityFramework.Models;

public partial class Aspnetuserclaim
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public string? ClaimType { get; set; }

    public string? ClaimValue { get; set; }

    public virtual Aspnetuser User { get; set; } = null!;
}
