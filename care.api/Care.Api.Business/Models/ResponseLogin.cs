
using Care.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class ResponseLogin
    {
        public Boolean? Logged { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public string? Role { get; set; }

        public string? Token { get; set; }

        public string? Message { get; set; }

        public Boolean? AcceptedTerm { get; set; }
        public Boolean? HasAcceptedDataSharing { get; set; }
        public Boolean? HasAcceptedContact { get; set; }
        public Boolean? ObrigatorioAlterarSenha { get; set; }

        public int? AmountOfAccesses { get; set; }

        public string? licenseNumber { get; set; }
        public string? licenseState { get; set; }

        public List<HealthProgramLogin> HealthProgramsUser { get; set; } = new List<HealthProgramLogin>();

    }
}
