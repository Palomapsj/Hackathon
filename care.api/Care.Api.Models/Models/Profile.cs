using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class Profile
{
    public Guid Id { get; set; }

    public string Description { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}
