using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TblInfusoesPrevista
{
    public long? Linha { get; set; }

    public int? LinhaAtual { get; set; }

    public Guid TreatmentId { get; set; }

    public Guid? InfusionId { get; set; }

    public string IniciaisDoPaciente { get; set; }

    public string CódigoDoPaciente { get; set; }

    public string FaseDoTratamento { get; set; }

    public string DataDaPrimeiraInfusão { get; set; }

    public DateTime? DataRealizada { get; set; }

    public string DataPrevista { get; set; }

    public DateTime? DataReferencia { get; set; }

    public string Situação { get; set; }

    public string Doença { get; set; }

    public string ModalidadeDeFornecimento { get; set; }

    public string ModalidadeDaInfusão { get; set; }

    public string StatusDaInfusão { get; set; }

    public string CidadeDoPaciente { get; set; }

    public string EstadoDoPaciente { get; set; }

    public string LocalDaInfusão { get; set; }

    public string MotivoDaFalta { get; set; }

    public string Medico { get; set; }

    public string Crm { get; set; }

    public string Ufcrm { get; set; }

    public string EmailMedico { get; set; }

    public string Representante { get; set; }

    public string Gerente { get; set; }

    public decimal? QtdeAmpolas { get; set; }

    public decimal? QtdeAmpolasIdeais { get; set; }

    public string NomeDoPaciente { get; set; }
}
