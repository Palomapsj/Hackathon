using Azure;
using Care.Api.Repository.Dapper.Interface;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Repository.Dapper
{
    public class DapperReportRepository : IDapperReportRepository, IDisposable
    {

        private readonly IConfiguration _config;
        private string Connectionstring = "DefaultConnection";

        public DapperReportRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection ProfarmaSpecialtyConnection
        {
            get { return new SqlConnection(_config.GetConnectionString(Connectionstring)); }
        }

        public void Dispose()
        {

        }

        public IEnumerable<dynamic> GetReportDoctors(string patientName, string patientCpf, Guid healthProgramId, Guid doctorId, int page, int pageSize)
        {
     
                using (var cn = ProfarmaSpecialtyConnection)
                {
                    string sql = @"
                                                           SELECT 
                            TRE.Id AS Id,
                            TRE.FullName AS Nome,
                            TRE.CPF AS CPF,
	                          CASE 
                                WHEN TRE.StateCode = 1 THEN 'Ativo'
                                ELSE 'Inativo'
                            END AS StatusPaciente,
	                        D.Name AS Patologia,
                            MD.Name AS Medicamento,
	                        SM.Name AS [Dosagem Atual],
	                        SMH.DosagemInicial AS [Dosagem Inicial],
                            PHS.Name AS Fase,
                            TRE.CreatedOn AS DataCadastro,
	                        TRED.AddressState AS UF,
	                        TRED.AddressCity AS Cidade,
                            EXD.Name AS Exame,
                            STRM.OptionName AS Status,
                            ACC.Name AS Local,
                            EX.ScheduleDate AS DataExame
                        FROM 
                            Treatment TRE
                        INNER JOIN 
                            HealthProgram HTP ON HTP.Id = TRE.HealthProgramId
                        INNER JOIN 
                            Doctor DCT ON DCT.Id = TRE.DoctorId
                        INNER JOIN 
                            Phase PHS ON PHS.Id = TRE.PhaseId
                        LEFT JOIN 
	                        StrengthMedicament SM ON SM.Id = TRE.StrengthMedicamentId
                        OUTER APPLY 
                                        (SELECT TOP 1 
                                            Name AS DosagemInicial
                                         FROM 
                                            StrengthMedicamentHistory
                                         WHERE 
                                            TreatmentId = TRE.Id
                                         ORDER BY 
                                            CreatedOn ASC
                                        ) AS SMH
                        LEFT JOIN 
                            Exam EX ON EX.TreatmentId = TRE.Id
                        LEFT JOIN 
                            ExamDefinition EXD ON EXD.Id = EX.ExamDefinitionId
                        LEFT JOIN 
                            Medicament MD ON MD.Id = TRE.MedicamentId
                        LEFT JOIN 
                            Account ACC ON ACC.Id = EX.LocalId
                        LEFT JOIN 
                            StringMap STRM ON STRM.StringMapId = EX.ExamStatusStringMapId
                        LEFT JOIN
	                        Disease D on D.Id = TRE.DiseaseId
                          CROSS APPLY (
                            SELECT TOP 1 
                                   TA.AddressState, 
                                   TA.AddressCity
                            FROM TreatmentAddress TA
                            WHERE TA.TreatmentId = TRE.Id
                            ORDER BY TA.CreatedOn DESC
                        ) AS TRED
                        WHERE 
                            (TRE.FullName LIKE '%' + @PatientName + '%' OR @PatientName IS NULL)
                            AND (TRE.CPF LIKE '%' + @PatientCpf + '%' OR @PatientCpf IS NULL)
                            AND TRE.HealthProgramId = @HealthProgramId
                            AND TRE.DoctorId = @DoctorId
                            AND TRE.ConsentToSendDataToDoctor = 1
                        ORDER BY 
                            TRE.FullName, EX.ScheduleDate DESC
                        OFFSET (@Page - 1) * @PageSize ROWS
                        FETCH NEXT @PageSize ROWS ONLY;";

                    var results = cn.Query(sql, new
                    {
                        PatientName = patientName,
                        PatientCpf = patientCpf,
                        HealthProgramId = healthProgramId,
                        DoctorId = doctorId,
                        Page = page,
                        PageSize = pageSize
                    });

                    return results;
                }
            }
        }

}
