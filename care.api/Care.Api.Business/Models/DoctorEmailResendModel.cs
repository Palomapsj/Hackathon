﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models;

public class DoctorEmailResendModel
{
    public Guid DoctorId { get; set; }
    public string? Email { get; set; }
}
