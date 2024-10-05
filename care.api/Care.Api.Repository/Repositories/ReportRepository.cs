using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Models.Models;
using Care.Api.Repository.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Care.Api.Repository.Repositories
{
    public  class ReportRepository : CommonRepository<Diagnostic>, IReportRepository
    {
        private const string _connectionString = "DefaultConnection";
        private readonly IConfiguration _config;

        public IDbConnection ProfarmaSpecialtyConnection
        {
            get { return new SqlConnection(_config.GetConnectionString(_connectionString)); }
        }

        public ReportRepository(CareDbContext careDbContext, IConfiguration configuration) : base(careDbContext)
        {
            _config = configuration;
        }

        public async Task<List<ExamReport>> GetDiagnosticsByProgram(string programCode, string? patientName, bool? statusPaciente, DateTime? initialDateSolicitation, DateTime? endDateSolicitation, DateTime? initialDateScheduling, DateTime? endDateScheduling, Guid? pathologyId, Guid? examDefinitionId, string? examStatus, string? voucher, string? cpf)
        {
            var healthProgram = await _careDbContext.HealthPrograms.FirstOrDefaultAsync(hp => hp.Code == programCode) ?? throw new Exception("Programa não encontrado para o código informado...");

            using var con = ProfarmaSpecialtyConnection;

            var conditions = new DynamicParameters();
            conditions.Add("HealthProgramId", healthProgram.Id);
            conditions.Add("PatientName", patientName);
            conditions.Add("StatusPaciente", statusPaciente);
            conditions.Add("InitialDateSolicitation", initialDateSolicitation);
            conditions.Add("EndDateSolicitation", endDateSolicitation);
            conditions.Add("InitialDateScheduling", initialDateScheduling);
            conditions.Add("EndDateScheduling", endDateScheduling);
            conditions.Add("PathologyId", pathologyId);
            conditions.Add("ExamDefinitionId", examDefinitionId);
            conditions.Add("ExamStatus", examStatus);
            conditions.Add("Voucher", voucher);
            conditions.Add("Cpf", cpf);

            var result = await con.QueryAsync<ExamReport>("PR_RELATORIO_FOLLOW_UP @HealthProgramId, @PatientName, @StatusPaciente, @InitialDateSolicitation, @EndDateSolicitation, @InitialDateScheduling, @EndDateScheduling, @PathologyId, @ExamDefinitionId, @ExamStatus, @Voucher, @Cpf", conditions);

            return result.ToList();
        }

        public async Task<List<Diagnostic>> Teste(Guid healthProgramId)
        {
            try
            {
                var resultSet1 = await _careDbContext.Diagnostics
                    .Include(diag => diag.DiagnosticStatusStringMap)
                    .Select(diag => new Diagnostic
                    {
                        Id = diag.Id,
                        Name = diag.Name,
                        CreatedOn = diag.CreatedOn,
                        DiagnosticStatusStringMap = new StringMap
                        {
                            OptionName = diag.DiagnosticStatusStringMap != null ? diag.DiagnosticStatusStringMap.OptionName : ""
                        }
                    })
                .Where(diag => diag.HealthProgramId == healthProgramId)
                .ToListAsync();

                //var resultSet2 = await _careDbContext.Diagnostics
                //    .Include(diag => diag.DiagnosticStatusStringMap)
                //    .Select(diag => new Diagnostic
                //    {
                //        Id = diag.Id,
                //        Name = diag.Name,
                //        CreatedOn = diag.CreatedOn,
                //        DiagnosticStatusStringMap = new StringMap
                //        {
                //            OptionName = diag.DiagnosticStatusStringMap != null ? diag.DiagnosticStatusStringMap.OptionName : ""
                //        }
                //    })
                //    .Where(diag => diag.HealthProgramId == healthProgramId)
                //    .ToListAsync();

                //resultSet1.Concat(resultSet2);

                return resultSet1;
            }
            catch (Exception EX)
            {
                throw EX;
            }

        }
    }
}
