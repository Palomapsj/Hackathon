using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class Profarmaacesso
{
    public string Source { get; set; }

    public Guid Formularioid { get; set; }

    public string TipoDeAcesso { get; set; }

    public string MotivoDaDificuldadeDeAcesso { get; set; }

    public string MotivoNãoAcesso { get; set; }

    public string Via { get; set; }

    public string TypeOfCoverage { get; set; }

    public string FormaDeAcesso { get; set; }

    public string IdLocalDeAcesso { get; set; }

    public string LocalDeAcesso { get; set; }

    public string StatusdoAcesso { get; set; }

    public string SubStatus { get; set; }

    public string DataDaTentativaDoAcessoSistema { get; set; }

    public string DataDeAcesso { get; set; }

    public int? DiasAcesso { get; set; }

    public string Programa { get; set; }

    public string Estado { get; set; }

    public string Cidade { get; set; }

    public string Cep { get; set; }

    public string CodPaciente { get; set; }

    public string FaseDoPaciente { get; set; }

    public string Situação { get; set; }

    public string Acesso { get; set; }

    public string Medicamento { get; set; }
}
