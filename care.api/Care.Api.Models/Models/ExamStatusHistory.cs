using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class ExamStatusHistory
{
    public int Id { get; set; }

    public Guid? Examid { get; set; }

    public Guid? OldExamStatusId { get; set; }

    public Guid? NewExamStatusId { get; set; }

    public DateTime ChangeDate { get; set; }

    public string Command { get; set; }
}
