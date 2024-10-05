using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class AkkaPublishEvent
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public bool? IsActive { get; set; }

    public Guid? AkkaActorsId { get; set; }

    public virtual AkkaActor AkkaActors { get; set; }
}
