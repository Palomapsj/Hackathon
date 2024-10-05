using AutoMapper;
using Care.Api.Business.Models;

public class MapperConfig : Profile
{
    public static IMapper Initialize()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<IDictionary<string, object>, ReportDoctor>()
                .ForMember(dest => dest.TreatmentId, opt => opt.MapFrom(src => GetValueOrDefault<Guid>(src, "Id")))
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => GetValueOrDefault<string>(src, "Nome")))
                .ForMember(dest => dest.PatientCpf, opt => opt.MapFrom(src => GetValueOrDefault<string>(src, "CPF")))
                .ForMember(dest => dest.MedicamentName, opt => opt.MapFrom(src => GetValueOrDefault<string>(src, "Medicamento")))
                .ForMember(dest => dest.PhaseName, opt => opt.MapFrom(src => GetValueOrDefault<string>(src, "Fase")))
                .ForMember(dest => dest.RegisterDate, opt => opt.MapFrom(src => GetValueOrDefault<DateTime>(src, "DataCadastro")))
                .ForMember(dest => dest.Patologia, opt => opt.MapFrom(src => GetValueOrDefault<string>(src, "Patologia")))
                .ForMember(dest => dest.DosagemAtual, opt => opt.MapFrom(src => GetValueOrDefault<string>(src, "Dosagem Atual")))
                .ForMember(dest => dest.DosagemInicial, opt => opt.MapFrom(src => GetValueOrDefault<string>(src, "Dosagem Inicial")))
                .ForMember(dest => dest.UF, opt => opt.MapFrom(src => GetValueOrDefault<string>(src, "UF")))
                .ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => GetValueOrDefault<string>(src, "Cidade")))
                .ForMember(dest => dest.StatusPaciente, opt => opt.MapFrom(src => GetValueOrDefault<string>(src, "StatusPaciente")))
                .ForMember(dest => dest.ReportExam, opt => opt.MapFrom(src => MapResults(src)));
        });

        return config.CreateMapper();
    }


    private static T GetValueOrDefault<T>(IDictionary<string, object> dictionary, string key)
    {
        if (dictionary.TryGetValue(key, out object value) && value is T result)
        {
            return result;
        }
        return default;
    }

    private static List<ReportExam> MapResults(IDictionary<string, object> src)
    {
        var exam = GetValueOrDefault<string>(src, "Exame");
        var status = GetValueOrDefault<string>(src, "Status");
        var local = GetValueOrDefault<string>(src, "Local");
        var dataExame = GetValueOrDefault<DateTime?>(src, "DataExame");

        if (string.IsNullOrEmpty(exam))
        {
            return null;
        }

        return new List<ReportExam>
        {
            new ReportExam
            {
                ExamDefinitionName = exam,
                ExamStatusName = status,
                LocalName = local,
                StartDate = dataExame
            }
        };
    }
}
