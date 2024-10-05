using System;
using System.Collections.Generic;

namespace Care.Api.Models;

public partial class LogAtualizacaoNonoDigito
{
    public string Entidade { get; set; }

    public Guid? Codigo { get; set; }

    public string Campo { get; set; }

    public string Valoranterior { get; set; }

    public string Valornovo { get; set; }

    public DateTime? Data { get; set; }
}
