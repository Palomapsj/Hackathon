using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class UserAccessProfileHealthProgram
{
    public Guid? HealthProgramId { get; set; }

    public Guid UserId { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }
}
