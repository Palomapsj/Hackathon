using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class LanguageMenuMetadatum
{
    public Guid Id { get; set; }

    public Guid? MenuMetadataId { get; set; }

    public int LangId { get; set; }

    public string Translate { get; set; }

    public virtual MenuMetadatum MenuMetadata { get; set; }
}
