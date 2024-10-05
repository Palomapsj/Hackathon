using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class TblRelatorioEntrenosEntyvioGeral2
{
    public string CódPaciente { get; set; }

    public string CódTratamento { get; set; }

    public DateTime? DataCriação { get; set; }

    public DateTime? DataNascimento { get; set; }

    public string FaixaEtaria { get; set; }

    public decimal? Idade { get; set; }

    public string AgingIdade { get; set; }

    public string Sexo { get; set; }

    public string PossuiPlano { get; set; }

    public string OperadoraDeSaúde { get; set; }

    public string Cidade { get; set; }

    public string Estado { get; set; }

    public string Regiao { get; set; }

    public string Produto { get; set; }

    public string Indicação { get; set; }

    public string EtapaAtual { get; set; }

    public string FaseAtual { get; set; }

    public DateTime? DataAdesão { get; set; }

    public string Situação { get; set; }

    public string MotivoInativação { get; set; }

    public DateTime? InativadoEm { get; set; }

    public string Médico { get; set; }

    public string NroCrm { get; set; }

    public string UfCrm { get; set; }

    public string UfNúmeroCrm { get; set; }

    public string LocalExame { get; set; }

    public DateTime? DataResultado { get; set; }

    public string PossuiPrescrição { get; set; }

    public DateTime? DataPrescrição { get; set; }

    public int QuantidadePrescrição { get; set; }

    public string RecebeuIt { get; set; }

    public int? DataUtilizaçãoIt { get; set; }

    public string FrequênciaManutençãoTrat { get; set; }

    public int? TratamentosAnteriores { get; set; }

    public string MedicamentosAnteriores { get; set; }

    public string CanalDeAcesso { get; set; }

    public string OperadoraDeSaúdeAcesso { get; set; }

    public string ÓrgãoPúblico { get; set; }

    public string AcessoVigente { get; set; }

    public string FormaDeAcesso { get; set; }

    public DateTime? DataQueForneceuOrientaçãoSobreAcesso { get; set; }

    public DateTime? DataDeSolicitaçãoDeAcesso { get; set; }

    public string AcessoAprovado { get; set; }

    public DateTime? DataDeRespostaSobreAcesso { get; set; }

    public DateTime? DtÚltimaDoseInduçãoDoTratamento { get; set; }

    public DateTime? DtPrimeiraDoseInduçãoDoTratamento { get; set; }

    public long? QtdDosesInduçãoDoTratamento { get; set; }

    public DateTime? DtPrimeiraDoseManutençãoDoTratamento { get; set; }

    public DateTime? DtÚltimaDoseManutençãoDoTratamento { get; set; }

    public long? QtdDosesManutençãoDoTratamento { get; set; }

    public DateTime? DtRetornoAoMédico { get; set; }

    public DateTime? DtÚltimoContato { get; set; }

    public DateTime? DtÚltimoContatoEfetivo { get; set; }

    public int? QtdeContatos { get; set; }

    public int? QtdeContatosEfetivos { get; set; }
}
