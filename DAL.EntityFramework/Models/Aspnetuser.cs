using System;
using System.Collections.Generic;

namespace DAL.EntityFramework.Models;

public partial class Aspnetuser
{
    public string Id { get; set; } = null!;

    public string? UserName { get; set; }

    public string? NormalizedUserName { get; set; }

    public string? Email { get; set; }

    public string? NormalizedEmail { get; set; }

    public ulong EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }
}
