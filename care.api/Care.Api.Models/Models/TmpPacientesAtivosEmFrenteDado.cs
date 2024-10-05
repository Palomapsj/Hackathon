using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TmpPacientesAtivosEmFrenteDado
{
    public string Codigo { get; set; }

    public string NomeDoPaciente { get; set; }

    public decimal? Peso { get; set; }

    public string FaixaEtaria { get; set; }

    public decimal? Idade { get; set; }

    public DateTime? TratamentoPrograma { get; set; }

    public string Modalidade { get; set; }

    public string Hemcasa { get; set; }

    public string Medicamento { get; set; }

    public string Local { get; set; }

    public string Médico { get; set; }

    public string Cidade { get; set; }

    public string Estado { get; set; }

    public string GrauDeHemofília { get; set; }

    public string Doença { get; set; }

    public int? Infusoes { get; set; }
}
