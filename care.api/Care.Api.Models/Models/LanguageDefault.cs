using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class LanguageDefault
{
    public Guid Id { get; set; }

    public int SequencialId { get; set; }

    public string Portuguese { get; set; }

    public string English { get; set; }
}
