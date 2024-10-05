using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class Configuration
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Value { get; set; }

    public string Type { get; set; }
}
