using Care.Api.Business.Interfaces;
using Care.Api.Business.Models;
using Care.Api.Business.ServicesReturnMessage;
using Care.Api.Repository.Interfaces;

namespace Care.Api.Business.Services
{
    public class SurveyService : ISurveyService
    {
        protected readonly ISurveyRepository _surveyRepository;
        protected readonly IQuestionRepository _questionRepository;
        protected readonly IQuestionOptionsRepository _questionOptionsRepository;
        protected readonly ISurveyQuestionListRepository _surveyQuestionListRepository;
        protected readonly IHealthProgramRepository _healthProgramRepository;
        protected readonly ISurveyResponseRepository _surveyResponseRepository;
        protected readonly IUserRepository _userRepository;
        protected readonly IPatientRepository _patientRepository;
        protected readonly ITreatmentRepository _treatmentRepository;
        protected readonly IDiagnosticRepository _diagnosticRepository;
        protected readonly IDoctorRepository _doctorRepository;

        public SurveyService(
            ISurveyRepository surveyRepository,
            IQuestionRepository questionRepository,
            IQuestionOptionsRepository questionOptionsRepository,
            ISurveyQuestionListRepository surveyQuestionListRepository,
            IHealthProgramRepository healthProgramRepository,
            ISurveyResponseRepository surveyResponseRepository,
            IUserRepository userRepository,
            IPatientRepository patientRepository,
            ITreatmentRepository treatmentRepository,
            IDoctorRepository doctorRepository,
            IDiagnosticRepository diagnosticRepository
            )
        {
            _surveyRepository = surveyRepository;
            _questionRepository = questionRepository;
            _questionOptionsRepository = questionOptionsRepository;
            _surveyQuestionListRepository = surveyQuestionListRepository;
            _healthProgramRepository = healthProgramRepository;
            _surveyResponseRepository = surveyResponseRepository;
            _userRepository = userRepository;
            _patientRepository = patientRepository;
            _treatmentRepository = treatmentRepository;
            _diagnosticRepository = diagnosticRepository;
            _doctorRepository = doctorRepository;
        }

        public async Task<List<QuestionModel>> GetQuestionsSurvey(string name, string programcode)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<ReturnMessage<string>> AddResponseSurvey(List<SurveyResponseModel> surveyResponseModel, string programcode, Guid userId)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<ReturnMessage<string>> AddConsentSurvey(string programcode, bool consentsurvey, Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<SurveyResponseValidationModel> GetLastSurveyResponse(string name, string programcode, Guid userId)
        {
            throw new NotImplementedException();
        }

        public virtual Task<List<QuestionModel>> GetAllFromProgram(string programcode)
        {
            throw new NotImplementedException();
        }
    }
}
