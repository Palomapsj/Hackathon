using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class RepresentativeAccount
{
    public Guid RepresentativeId { get; set; }

    public Guid AccountId { get; set; }
}
