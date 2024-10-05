using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class CadastrosTakedum
{
    public Guid TreatmentId { get; set; }

    public string CódigoDoPaciente { get; set; }

    public string NomePaciente { get; set; }

    public string Programa { get; set; }

    public DateTime? DataDeNascimento { get; set; }

    public int? Idade { get; set; }

    public string FaixaEtária { get; set; }

    public string Genero { get; set; }

    public string CidadeDoPaciente { get; set; }

    public string UfPaciente { get; set; }

    public string EstadoDoPaciente { get; set; }

    public string RegiaoDoPaciente { get; set; }

    public string Email1 { get; set; }

    public string Email2 { get; set; }

    public string Patologia { get; set; }

    public DateTime? DataDeCadastro { get; set; }

    public string Situação { get; set; }

    public string FaseAtual { get; set; }

    public string Status { get; set; }

    public string DetalheDoStatus { get; set; }

    public string MotivoDaInativação { get; set; }

    public DateTime? DataDaInativação { get; set; }

    public string Modalidade { get; set; }

    public string NomeDoMédico { get; set; }

    public string Crm { get; set; }

    public string Ufcrm { get; set; }

    public string EmailMedico1 { get; set; }

    public string EmailMedico2 { get; set; }

    public string Consultor { get; set; }

    public string Gerente { get; set; }

    public string NomeDoMedicamento { get; set; }

    public string AceitaParticiparDoPrograma { get; set; }

    public DateTime? DataAceiteParticiparDoPrograma { get; set; }

    public string AceitaReceberLigações { get; set; }

    public DateTime? DataAceiteReceberLigações { get; set; }

    public string AceitaReceberEMail { get; set; }

    public DateTime? DataAceitaReceberEMail { get; set; }

    public string AceitaReceberMateriais { get; set; }

    public DateTime? DataAceitaReceberMateriais { get; set; }

    public string ConsentimentoLgpd { get; set; }

    public DateTime? DataDoConsentimentoLgpd { get; set; }

    public string OrigemConsentimento { get; set; }

    public string OrigemPaciente { get; set; }

    public string ConsentimentoLgpdMedico { get; set; }

    public DateTime? DataDoConsentimentoLgpdMedico { get; set; }

    public string OrigemConsentimentoMedico { get; set; }

    public string AceiteWhatsApp { get; set; }

    public string GrauDeHemofilia { get; set; }

    public string SePossuiPrescricao { get; set; }

    public DateTime? DataPrescricao { get; set; }

    public string SePossuiPrescricaoAnexada { get; set; }
}
