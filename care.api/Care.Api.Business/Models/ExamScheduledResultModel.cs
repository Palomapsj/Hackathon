using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models;

public class ExamScheduledResultModel
{
    public DateTime CreatedOn { get; set; }
    public string NumberProtocol { get; set; }
    public string NameDoctor { get; set; }
    public string LicenseNumber { get; set; }
    public string LicenseState { get; set; }

    public string NamePatient { get; set; }
    public string CPF { get; set; }
    public string PatientStatus { get; set; }
    public string ExamName { get; set; }
    public string Voucher { get; set; }
    public DateTime ScheduledDate { get; set; }
    public string ExamStatus { get; set; }

}

