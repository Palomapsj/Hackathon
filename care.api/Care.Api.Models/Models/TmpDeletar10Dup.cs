using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TmpDeletar10Dup
{
    public string FriendlyCode { get; set; }

    public string ImportCode { get; set; }

    public Guid Id { get; set; }

    public DateTime? Data { get; set; }

    public string OptionName { get; set; }
}
