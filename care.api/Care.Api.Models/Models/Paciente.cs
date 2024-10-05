using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class Paciente
{
    public string Programa { get; set; }

    public Guid PacienteId { get; set; }

    public string CodigoPaciente { get; set; }

    public string Cpfpaciente { get; set; }

    public string NomePaciente { get; set; }

    public string Fase { get; set; }

    public string Patologia { get; set; }

    public string FaseDaPatologia { get; set; }

    public string Medicamento { get; set; }

    public Guid? DoctorId { get; set; }

    public string TipoAnalise { get; set; }

    public DateTime? DataAniversario { get; set; }

    public string Genero { get; set; }

    public string NecessitaDevolucao { get; set; }

    public Guid? InstituicaoPacienteId { get; set; }

    public Guid? Healthprogramid { get; set; }

    public string TelefonePaciente { get; set; }

    public string EmailPaciente { get; set; }

    public string CidadeDoPaciente { get; set; }

    public string UfDoPaciente { get; set; }

    public bool? AlteraçãoManual { get; set; }

    public string PrecisaDeLogística { get; set; }

    public string TipoAnaliseMédico { get; set; }

    public string CreatedByName { get; set; }

    public DateTime? Criadoem { get; set; }
}
