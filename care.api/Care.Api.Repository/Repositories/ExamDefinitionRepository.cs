using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace Care.Api.Repository.Repositories
{
    public class ExamDefinitionRepository : CommonRepository<ExamDefinition>, IExamDefinitionRepository
    {
        private const string _connectionString = "DefaultConnection";

        private readonly IConfiguration _config;

        public IDbConnection ProfarmaSpecialtyConnection
        {
            get { return new SqlConnection(_config.GetConnectionString(_connectionString)); }
        }

        public ExamDefinitionRepository(CareDbContext careDbContext, IConfiguration configuration) : base(careDbContext)
        {
            _config = configuration;
        }

        public async Task<List<ExamDefinition>> GetExamDefinitionsByDisease(string programCode, Guid diseaseId)
        {
            using (var con = ProfarmaSpecialtyConnection)
            {
                var conditions = new DynamicParameters();
                conditions.Add("ProgramCode", programCode);
                conditions.Add("DiseaseId", diseaseId);

                var result = await con.QueryAsync<ExamDefinition>($@"
                    select 
                        ed.Id as Id,
                        ed.isDeleted as IsDeleted,
                        ed.Name as Name
                    from ExamDefinition ed
                    join HealthProgramDiseaseExam hpde  on ed.Id = hpde.ExamDefinitionId
                    join HealthProgramDisease hpd       on hpde.HealthProgramDiseaseId = hpd.Id
                    join HealthProgram hp               on hpd.HealthProgramId = hp.Id
                    where   hp.Code = @ProgramCode and 
                            hpd.DiseaseId = @DiseaseId
                ", conditions);

                return result.ToList();
            }
        }

        public List<ExamDefinition> GetExamDefinitionsByProgram(string progracode)
        {
            var examDefinitions = _careDbContext.ExamDefinitions
                                                    .Include(_ => _.HealthPrograms).ToList();

            var examDefinitionsByProg = examDefinitions
                                            .Where(_ => _.HealthPrograms.Any(x => x.Code == progracode)).ToList();

            return examDefinitionsByProg;
        }

        public async Task<List<ExamDefinition>> GetExamDefinitionByMedicament(Guid medicamentId)
        {
            var medicament = await _careDbContext.Medicaments
                                                    .Where(_ => _.Id == medicamentId).Include(_ => _.ExamDefinitions).FirstOrDefaultAsync();
            if(medicament is not null) 
            {
                return medicament.ExamDefinitions.ToList();
            }

            return null ;
        }

    }
}
