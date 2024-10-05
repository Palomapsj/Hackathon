using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TblRelatorioComparativoPatientmapEnzimai
{
    public Guid Id { get; set; }

    public string FriendlyCode { get; set; }

    public string Programa { get; set; }

    public string Cidade { get; set; }

    public string Estado { get; set; }

    public string Medico { get; set; }

    public string Crm { get; set; }

    public string Medicamento { get; set; }

    public string Doenca { get; set; }

    public string Gerente { get; set; }

    public string Representante { get; set; }

    public string SituacaoTratamento { get; set; }

    public string Fase { get; set; }

    public string StatusDoTratamento { get; set; }

    public string DetalheDoStatusDoTratamento { get; set; }

    public string DataEntrada { get; set; }

    public string PatientId { get; set; }

    public string Sexo { get; set; }

    public string AceitaVisita { get; set; }

    public string PossuiPlanoDeSaude { get; set; }

    public string NomeOperadoraDeSaude { get; set; }

    public string UltimoContatoComSucesso { get; set; }

    public string UltimoContatoSemSucesso { get; set; }

    public string DataConclusaoCadastro { get; set; }

    public string DataProximaAcao { get; set; }

    public string OrigemDoCadastro { get; set; }

    public string DataInativacao { get; set; }

    public string MotivoInativacao { get; set; }

    public string Região { get; set; }

    public string DataNascimento { get; set; }

    public string FaixaEtaria { get; set; }
}
