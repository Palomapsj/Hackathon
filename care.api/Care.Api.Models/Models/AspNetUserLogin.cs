﻿using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class AspNetUserLogin
{
    public string LoginProvider { get; set; }

    public string ProviderKey { get; set; }

    public string UserId { get; set; }

    public virtual AspNetUser User { get; set; }
}
