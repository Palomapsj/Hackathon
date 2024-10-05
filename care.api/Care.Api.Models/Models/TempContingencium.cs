using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TempContingencium
{
    public Guid? RegardingObjectIdTarget { get; set; }

    public int? QtdeAnexos { get; set; }

    public string NoteText { get; set; }
}
