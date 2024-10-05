using Care.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models;

public class RepresentativeResultModel : CommonModel
{
    public Guid? RepresentativeId { get; set; }
    public string? ProfessionalName { get; set; }
    public string? Telefone1 { get; set; }
    public string? Mobilephone1 { get; set; }
    public string? EmailAddress1 { get; set; }
    public string? LicenseNumber { get; set; }
    public string? LicenseState { get; set; }
    public string? ProgramCode { get; set; }
    public string? CRMNumber { get; set; }
    public string? CRMState { get; set; }
    public string? TypeProfessional { get; set; }
    public string? CPF { get; set; }
    public string? StatusNurse { get; set; }
    public bool? IsAcceptTerm { get; set; }
}
