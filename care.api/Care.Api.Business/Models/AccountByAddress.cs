using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class AccountByAddress
    {
        public EnderecoModel Endereco { get; set; }
        public string CodigoCampanha { get; set; }
        public Guid CodigoExame { get; set; }
        public int RangeDsitancia { get; set; }
        public string TipoProcedimento { get; set; }
    }
}

