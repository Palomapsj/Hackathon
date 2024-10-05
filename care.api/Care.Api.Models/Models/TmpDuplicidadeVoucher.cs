using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TmpDuplicidadeVoucher
{
    public string Voucher { get; set; }

    public int? QtdeVouchers { get; set; }

    public long? OrdemDeletaveis { get; set; }

    public int Deletavel { get; set; }

    public DateTime? CriacaoVoucher { get; set; }

    public string Exame { get; set; }

    public string Codigo { get; set; }

    public Guid? ExameId { get; set; }

    public Guid? DiagnosticId { get; set; }

    public Guid? TreatmentId { get; set; }

    public Guid? InfusionId { get; set; }

    public Guid? BenefitId { get; set; }

    public Guid? DiagnosticExamId { get; set; }

    public Guid? LogisticsScheduleItemId { get; set; }

    public Guid VoucherId { get; set; }
}
