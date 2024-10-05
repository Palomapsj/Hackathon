using Care.Api.Business.Interfaces;
using Care.Api.Business.Interfaces.ChatbotWhatsApp;
using Care.Api.Repository.Interfaces;

namespace Care.Api.Business.Providers
{
    public class ChatbotWhatsAppScheduleProvider : IChatbotWhatsAppScheduleProvider
    {
        public ChatbotWhatsAppScheduleProvider(IAnnotationRepository annotationRepository, IStringMapRepository stringMapRepository, ITreatmentAddressRepository treatmentAddressRepository, IHealthProgramRepository healthProgramRepository, ITreatmentRepository treatmentRepository,
            ITreatmentAndDiagnosticActionService treatmentAndDiagnosticActionService, ITreatmentAndDiagnosticActionRepository treatmentAndDiagnosticActionRepository, IChatRepository chatRepository)
        {
            AnnotationRepository = annotationRepository;
            StringMapRepository = stringMapRepository;
            TreatmentAddressRepository = treatmentAddressRepository;
            HealthProgramRepository = healthProgramRepository;
            TreatmentRepository = treatmentRepository;
            TreatmentAndDiagnosticActionService = treatmentAndDiagnosticActionService;
            TreatmentAndDiagnosticActionRepository = treatmentAndDiagnosticActionRepository;
            ChatRepository = chatRepository;
        }

        public IAnnotationRepository AnnotationRepository { get; }
        public IStringMapRepository StringMapRepository { get; }
        public ITreatmentAddressRepository TreatmentAddressRepository { get; }
        public IHealthProgramRepository HealthProgramRepository { get; }
        public ITreatmentRepository TreatmentRepository { get; }
        public ITreatmentAndDiagnosticActionService TreatmentAndDiagnosticActionService { get; }
        public ITreatmentAndDiagnosticActionRepository TreatmentAndDiagnosticActionRepository { get; }
        public IChatRepository ChatRepository { get; }
}
}
