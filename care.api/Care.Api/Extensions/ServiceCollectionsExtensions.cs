using Care.Api.Business.Interfaces;
using Care.Api.Business.Interfaces.Azi;
using Care.Api.Business.Interfaces.ChatbotWhatsApp;
using Care.Api.Business.Interfaces.ChatbotWhatsApp.EmFrente;
using Care.Api.Business.Interfaces.Complementare;
using Care.Api.Business.Interfaces.Cuidaeh;
using Care.Api.Business.Interfaces.DiagnosticoCorreto;
using Care.Api.Business.Interfaces.EmFrente;
using Care.Api.Business.Interfaces.EntreNos;
using Care.Api.Business.Interfaces.Enzimais;
using Care.Api.Business.Interfaces.Independencia;
using Care.Api.Business.Interfaces.Reative;
using Care.Api.Business.Interfaces.Sanofi;
using Care.Api.Business.Interfaces.TakeCare;
using Care.Api.Business.Interfaces.VisionCare;
using Care.Api.Business.Providers;
using Care.Api.Business.Services;
using Care.Api.Business.Services.Azi;
using Care.Api.Business.Services.Enzimais;
using Care.Api.Business.Services.TakeCare;
using Care.Api.Business.Services.HealthProgram.Complementare;
using Care.Api.Business.Services.HealthProgram.Cuidaeh;
using Care.Api.Business.Services.HealthProgram.DiagnosticoCorreto;
using Care.Api.Business.Services.HealthProgram.EmFrente;
using Care.Api.Business.Services.HealthProgram.EmFrente.ChatbotWhatsApp;
using Care.Api.Business.Services.HealthProgram.EmFrente.ChatbotWhatsApp.Schedule;
using Care.Api.Business.Services.HealthProgram.EntreNos;
using Care.Api.Business.Services.HealthProgram.Enzimais;
using Care.Api.Business.Services.HealthProgram.Independencia;
using Care.Api.Business.Services.HealthProgram.Reative;
using Care.Api.Business.Services.HealthProgram.Sanofi;
using Care.Api.Business.Services.HealthProgram.TakeCare;
using Care.Api.Business.Services.HealthProgram.VisionCare;
using Care.Api.Context;
using Care.Api.Repository.Interfaces;
using Care.Api.Repository.Repositories;
using Care.Api.Security;
using Care.Api.Business.Interfaces.KiteConnect;
using Care.Api.Business.Interfaces.Mavacare;
using Care.Api.Business.Services.HealthProgram.KiteConnect;
using Care.Api.Business.Services.HealthProgram.Mavacare;
using Care.Api.Repository.Dapper.Interface;
using Care.Api.Repository.Dapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Care.Api.Business.Interfaces.VidaRara;
using Care.Api.Business.Models.Settings;
using Care.Api.Business.Interfaces.UrlShorteners;
using Care.Api.Business.Services.UrlShorteners;
using AutoMapper;
using Care.Api.Business.AutoMapperConfiguration.Mapper.Resolver.Functional;
using Care.Api.Business.AutoMapperConfiguration.Mapper.Resolver.Interfaces;
using Care.Api.Business.AutoMapperConfiguration;
using Care.Api.Business.Services.VidaRara;

namespace Care.Api.Extensions;

public static class ServiceCollectionsExtensions
{
    public static WebApplicationBuilder AddApiSwagger(this WebApplicationBuilder builder, bool authenticationJwtActive)
    {
        builder.Services.AddSwagger(authenticationJwtActive);
        return builder;
    }

    public static IServiceCollection AddSwagger(this IServiceCollection services, bool authenticationJwtActive)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Care.Api", Version = "v1" });

            if (authenticationJwtActive)
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme.\r\n\r\nEnter 'Bearer'[space] and then your token in the text input below\r\nExample: \"Bearer 1234abcdef\"",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            }
        });

        return services;
    }

    public static WebApplicationBuilder AddLoginService(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddTransient<ILoginService, LoginService>();
        builder.Services.AddTransient<ILoginVisionCareService, LoginVisionCareService>();
        builder.Services.AddTransient<ILoginSanofiService, LoginSanofiService>();
        builder.Services.AddTransient<IDoctorSanofiService, DoctorSanofiService>();
        builder.Services.AddTransient<ILoginAziService, LoginAziService>();
        builder.Services.AddTransient<ILoginCuidaehService, LoginCuidaehService>();
        builder.Services.AddTransient<ILoginVidaRaraService, LoginVidaRaraService>();

        builder.Services.AddTransient<ILoginEmFrenteService, LoginEmFrenteService>();
        builder.Services.AddTransient<ILoginEntreNosService, LoginEntreNosService>();
        builder.Services.AddTransient<ILoginEnzimaisService, LoginEnzimaisService>();
        builder.Services.AddTransient<ILoginIndependenciaService, LoginIndependenciaService>();
        builder.Services.AddTransient<ILoginReativeService, LoginReativeService>();
        builder.Services.AddTransient<ILoginTakeCareService, LoginTakeCareService>();
        return builder;
    }

    public static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
        string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        //builder.Services.AddDbContext<CareDbContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Care.Api")));
        builder.Services.AddDbContext<CareDbContext>(options => options.UseSqlServer(connectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

        return builder;
    }
    public static WebApplicationBuilder AddAuthenticationHandler(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(
                CookieAuthenticationDefaults.AuthenticationScheme,
                config =>
                {
                    config.Cookie.Name = "Api.Care.Cookie";
                    config.LoginPath = "/login";
                    config.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                    config.SlidingExpiration = true;
                    config.AccessDeniedPath = "/Forbidden/";
                }
            );

        builder.Services.AddAuthorization();
        builder.AddTokenServices();
        return builder;
    }

    public static WebApplicationBuilder AddSessionMiddle(this WebApplicationBuilder builder)
    {
        try
        {
            int timeoutSessionInMinutes = builder.Configuration["TwoStepLogin:TimeoutInMinutes"] is null ? 1 : Convert.ToInt32(builder.Configuration["TwoStepLogin:TimeoutInMinutes"]);
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(timeoutSessionInMinutes);
            });

            builder.Services.AddDistributedMemoryCache();
        }
        catch (Exception)
        { }

        return builder;
    }

    public static WebApplicationBuilder AddAuthenticationJwt(this WebApplicationBuilder builder)
    {
        string? key = builder.Configuration["Jwt:Key"] is null ? "" : builder.Configuration["Jwt:Key"];
        string? issuer = builder.Configuration["Jwt:Issuer"] is null ? "" : builder.Configuration["Jwt:Issuer"];
        string? audience = builder.Configuration["Jwt:Audience"] is null ? "" : builder.Configuration["Jwt:Audience"];

        if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(issuer) && !string.IsNullOrEmpty(audience))
        {
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                };
            });

            builder.Services.AddAuthorization();
            builder.AddTokenServices();
        }
        return builder;
    }

    public static WebApplicationBuilder AddCryptographyService(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<ICryptographyService, CryptographyService>();
        return builder;
    }

    public static WebApplicationBuilder AddTokenServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<ITokenService, TokenService>();

        builder.Services.AddTransient<IUserService, UserService>();
        builder.Services.AddTransient<IUserVidaRaraService, UserVidaRaraService>();
        builder.Services.AddTransient<ISmsRepository, SmsRepository>();
        builder.Services.AddTransient<ISmsService, SmsService>();

        builder.Services.AddTransient<IEmailRepository, EmailRepository>();
        builder.Services.AddTransient<IEmailService, EmailService>();

        builder.Services.AddTransient<IStringMapRepository, StringMapRepository>();
        builder.Services.AddTransient<IStringMapService, StringMapService>();

        return builder;
    }

    public static WebApplicationBuilder AddUserServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IUserRepository, UserRepository>();
        builder.Services.AddTransient<IUserSystemLogRepository, UserSystemLogRepository>();
        builder.Services.AddTransient<IEmailService, EmailService>();
        builder.Services.AddTransient<IUserVisionCareService, UserVisionCareService>();


        builder.Services.AddTransient<IUserEntreNosService, UserEntreNosService>();
        builder.Services.AddTransient<IUserSanofiService, UserSanofiService>();
        builder.Services.AddTransient<IAccessProfileUserRepository, AccessProfileUserRepository>();
        builder.Services.AddTransient<IHealthProfessionalByProgramRepository, HealthProfessionalByProgramRepository>();
        builder.Services.AddTransient<IHealthProfessionalRepository, HealthProfessionalRepository>();

        builder.Services.AddTransient<IUserReativeService, UserReativeService>();
        builder.Services.AddTransient<IUserKiteConnectService, UserKiteConnectService>();

        builder.Services.AddTransient<IStringMapRepository, StringMapRepository>();
        builder.Services.AddTransient<IStringMapService, StringMapService>();
        builder.Services.AddTransient<IUserPasswordHistoryRepository, UserPasswordHistoryRepository>();
        builder.Services.AddTransient<IUserPasswordHistoryService, UserPasswordHistoryService>();
        builder.Services.AddTransient<IUserPasswordHistorySanofiService, UserPasswordHistorySanofiService>();
        builder.Services.AddTransient<IUnsubscribeRepository, UnsubscribeRepository>();
        builder.Services.AddTransient<IUnsubscribeService, UnsubscribeService>();
        builder.Services.AddTransient<IUnsubscribeSanofiService, UnsubscribeSanofiService>();


        return builder;
    }

    public static WebApplicationBuilder AddPatientServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IPatientRepository, PatientRepository>();
        builder.Services.AddTransient<IPatientService, PatientService>();
        builder.Services.AddTransient<IPatientSanofiService, PatientSanofiService>();
        builder.Services.AddTransient<IPatientService, PatientService>();
        builder.Services.AddTransient<IPatientComplementareService, PatientComplementareService>();
        builder.Services.AddTransient<IPatientVidaRaraService, PatientVidaRaraService>();

        return builder;
    }

    public static WebApplicationBuilder AddRepresentativeServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IRepresentativeRepository, RepresentativeRepository>();
        builder.Services.AddTransient<IRepresentativeService, RepresentativeService>();
        builder.Services.AddTransient<IRepresentativeEnzimaisService, RepresentativeEnzimaisService>();
        builder.Services.AddTransient<IDoctorsRepresentativeRepository, DoctorsRepresentativeRepository>();
        builder.Services.AddTransient<IRepresentativeReativeService, RepresentativeReativeService>();
        builder.Services.AddTransient<IRepresentativeIndependenciaService, RepresentativeIndependenciaService>();
        builder.Services.AddTransient<IRepresentativeCuidaehService, RepresentativeCuidaehService>();
        builder.Services.AddTransient<IRepresentativeEmFrenteService, RepresentativeEmFrenteService>();
        builder.Services.AddTransient<IRepresentativeSanofiService, RepresentativeSanofiService>();

        return builder;
    }

    public static WebApplicationBuilder AddDoctorServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IDoctorRepository, DoctorRepository>();

        builder.Services.AddTransient<IDoctorService, DoctorService>();
        builder.Services.AddTransient<IDoctorAziService, DoctorAziService>();

        builder.Services.AddTransient<ICFMService, CFMService>();

        builder.Services.AddTransient<IMedicalSpecialtyRepository, MedicalSpecialtyRepository>();
        builder.Services.AddTransient<IDoctorByProgramRepository, DoctorByProgramRepository>();

        builder.Services.AddTransient<IEmailService, EmailService>();
        builder.Services.AddTransient<IEmailRepository, EmailRepository>();

        builder.Services.AddTransient<IEntityMetadataRepository, EntityMetadataRepository>();

        builder.Services.AddTransient<IStringMapService, StringMapService>();
        builder.Services.AddTransient<IStringMapRepository, StringMapRepository>();

        builder.Services.AddTransient<IHealthProgramTemplateSettingRepository, HealthProgramTemplateSettingRepository>();

        builder.Services.AddTransient<ISmsRepository, SmsRepository>();
        builder.Services.AddTransient<ISmsService, SmsService>();

        builder.Services.AddTransient<IStringMapRepository, StringMapRepository>();
        builder.Services.AddTransient<IStringMapService, StringMapService>();

        builder.Services.AddTransient<IHealthProgramRepository, HealthProgramRepository>();
        builder.Services.AddTransient<IHealthProgramService, HealthProgramService>();


        builder.Services.AddTransient<ITemplateService, TemplateService>();
        builder.Services.AddTransient<ITemplateRepository, TemplateRepository>();

        builder.Services.AddTransient<IConfigurationRepository, ConfigurationRepository>();
        builder.Services.AddTransient<IDoctorEntreNosService, DoctorEntreNosService>();
        builder.Services.AddTransient<IDoctorEnzimaisService, DoctorEnzimaisService>();
        builder.Services.AddTransient<IDoctorTakeCareService, DoctorTakeCareService>();
        builder.Services.AddTransient<IDoctorReativeService, DoctorReativeService>();
        builder.Services.AddTransient<IDoctorIndependenciaService, DoctorIndependenciaService>();
        builder.Services.AddTransient<IDoctorCuidaehService, DoctorCuidaehService>();
        builder.Services.AddTransient<IDoctorEmFrenteService, DoctorEmFrenteService>();

        builder.Services.AddTransient<IDoctorSanofiService, DoctorSanofiService>();
        builder.Services.AddTransient<IDoctorMavacareService, DoctorMavacareService>();

        builder.Services.AddTransient<IDoctorComplementareService, DoctorComplementareService>();
        builder.Services.AddTransient<IDoctorKiteConnectService, DoctorKiteConnectService>();
        builder.Services.AddTransient<IDoctorVidaRaraService, DoctorVidaRaraService>();
        builder.Services.AddTransient<IDiagnosticVidaRaraService, DiagnosticVidaRaraService>();


        return builder;
    }

    public static WebApplicationBuilder AddCFMServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IDoctorRepository, DoctorRepository>();

        builder.Services.AddTransient<IDoctorService, DoctorService>();
        builder.Services.AddTransient<IDoctorAziService, DoctorAziService>();
        builder.Services.AddTransient<IDoctorEntreNosService, DoctorEntreNosService>();
        builder.Services.AddTransient<IDoctorEnzimaisService, DoctorEnzimaisService>();
        builder.Services.AddTransient<IDoctorReativeService, DoctorReativeService>();
        builder.Services.AddTransient<IDoctorIndependenciaService, DoctorIndependenciaService>();
        builder.Services.AddTransient<IDoctorCuidaehService, DoctorCuidaehService>();
        builder.Services.AddTransient<IDoctorEmFrenteService, DoctorEmFrenteService>();

        builder.Services.AddTransient<ICFMService, CFMService>();

        builder.Services.AddTransient<IMedicalSpecialtyRepository, MedicalSpecialtyRepository>();
        builder.Services.AddTransient<IDoctorByProgramRepository, DoctorByProgramRepository>();


        return builder;
    }

    public static WebApplicationBuilder AddHealthProgramServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IHealthProgramRepository, HealthProgramRepository>();
        builder.Services.AddTransient<IHealthProgramService, HealthProgramService>();

        builder.Services.AddTransient<ITemplateService, TemplateService>();
        builder.Services.AddTransient<ITemplateRepository, TemplateRepository>();

        builder.Services.AddTransient<IAttachmentRepository, AttachmentRepository>();

        builder.Services.AddTransient<IRegardingEntityRepository, RegardingEntityRepository>();

        builder.Services.AddTransient<IAttributeMetadataRepository, AttributeMetadataRepository>();
        builder.Services.AddTransient<ILanguageAttributeRepository, LanguageAttributeRepository>();

        builder.Services.AddTransient<IAccessProfileRepository, AccessProfileRepository>();

        builder.Services.AddTransient<IExamDefinitionService, ExamDefinitionService>();
        builder.Services.AddTransient<IExamDefinitionRepository, ExamDefinitionRepository>();

        builder.Services.AddTransient<IDiseaseService, DiseaseService>();
        builder.Services.AddTransient<IDiseaseRepository, DiseaseRepository>();

        builder.Services.AddTransient<IDiagnosticRepository, DiagnosticRepository>();

        builder.Services.AddTransient<IExamRepository, ExamRepository>();

        builder.Services.AddTransient<IExamDefinitionSettingsByProgramService, ExamDefinitionSettingsByProgramService>();
        builder.Services.AddTransient<IExamDefinitionSettingsByProgramRepository, ExamDefinitionSettingsByProgramRepository>();

        builder.Services.AddTransient<IVoucherConfigurationRepository, VoucherConfigurationRepository>();

        builder.Services.AddTransient<IVoucherRepository, VoucherRepository>();
        builder.Services.AddTransient<IVoucherService, VoucherService>();
        builder.Services.AddTransient<IVoucherVisionCareService, VoucherVisionCareService>();
        builder.Services.AddTransient<IVoucherEntreNosService, VoucherEntreNosService>();
        builder.Services.AddTransient<IVoucherEnzimaisService, VoucherEnzimaisService>();

        builder.Services.AddTransient<IVoucherReativeService, VoucherReativeService>();
        builder.Services.AddTransient<IVoucherIndependenciaService, VoucherIndependenciaService>();
        builder.Services.AddTransient<IVoucherCuidaehService, VoucherCuidaehService>();
        builder.Services.AddTransient<IVoucherEmFrenteService, VoucherEmFrenteService>();
        builder.Services.AddTransient<IVoucherVidaRaraService, VoucherVidaRaraService>();
        builder.Services.AddTransient<IVoucherTakeCareService, VoucherTakeCareService>();

        builder.Services.AddTransient<ITreatmentAndDiagnosticActionService, TreatmentAndDiagnosticActionService>();

        builder.Services.AddTransient<ISchedulingHistoryRepository, SchedulingHistoryRepository>();

        builder.Services.AddTransient<ILogisticsScheduleRepository, LogisticsScheduleRepository>();
        builder.Services.AddTransient<ILogisticStuffRepository, LogisticStuffRepository>();

        builder.Services.AddTransient<IIdentityCodeRepository, IdentityCodeRepository>();

        builder.Services.AddTransient<IAnnotationRepository, AnnotationRepository>();

        builder.Services.AddTransient<IAccountSettingsByProgramService, AccountSettingsByProgramService>();
        builder.Services.AddTransient<IAccountSettingsByProgramRepository, AccountSettingsByProgramRepository>();

        builder.Services.AddTransient<ICustomerAddressRepository, CustomerAddressRepository>();

        builder.Services.AddTransient<ISurveyService, SurveyService>();
        builder.Services.AddTransient<ISurveyRepository, SurveyRepository>();
        builder.Services.AddTransient<ISurveyEntreNosService, SurveyEntreNosService>();
        builder.Services.AddTransient<IHealthProgramFileService, HealthProgramFileService>();
        builder.Services.AddTransient<IHealthProgramFileRepository, HealthProgramFileRepository>();
        builder.Services.AddTransient<ISurveyReativeService, SurveyReativeService>();

        builder.Services.AddTransient<ILogisticService, LogisticService>();

        builder.Services.AddTransient<IPurchaseRepository, PurchaseRepository>();
        builder.Services.AddTransient<IPurchaseService, PurchaseService>();

        builder.Services.AddTransient<IMedicamentService, MedicamentService>();
        builder.Services.AddTransient<IMedicamentRepository, MedicamentRepository>();

        return builder;
    }

    public static WebApplicationBuilder AddDiagnosticServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IDiagnosticRepository, DiagnosticRepository>();
        builder.Services.AddTransient<IDiagnosticService, DiagnosticService>();
        builder.Services.AddTransient<IDiagnosticDiagnosticoCorretoService, DiagnosticLillyService>();
        builder.Services.AddTransient<IDiagnosticVisionCareService, DiagnosticVisionCareService>();

        builder.Services.AddTransient<IDiagnosticEntreNosService, DiagnosticEntreNosService>();
        builder.Services.AddTransient<IDiagnosticEnzimaisService, DiagnosticEnzimaisService>();
        builder.Services.AddTransient<IDiagnosticTakeCareService, DiagnosticTakeCareService>();

        builder.Services.AddTransient<IDiagnosticReativeService, DiagnosticReativeService>();
        builder.Services.AddTransient<IDiagnosticIndependenciaService, DiagnosticIndependenciaService>();
        builder.Services.AddTransient<IDiagnosticCuidaehService, DiagnosticCuidaehService>();
        builder.Services.AddTransient<IDiagnosticEmFrenteService, DiagnosticEmFrenteService>();

        builder.Services.AddTransient<IHealthProgramRepository, HealthProgramRepository>();
        builder.Services.AddTransient<IHealthProgramService, HealthProgramService>();

        builder.Services.AddTransient<IAccessProfileRepository, AccessProfileRepository>();
        builder.Services.AddTransient<IAccessProfileService, AccessProfileService>();

        builder.Services.AddTransient<ISmsRepository, SmsRepository>();
        builder.Services.AddTransient<ISmsService, SmsService>();

        builder.Services.AddTransient<IStringMapRepository, StringMapRepository>();
        builder.Services.AddTransient<IStringMapService, StringMapService>();

        builder.Services.AddTransient<IUserRepository, UserRepository>();
        builder.Services.AddTransient<IUserService, UserService>();
        builder.Services.AddTransient<IUserVisionCareService, UserVisionCareService>();

        builder.Services.AddTransient<IVisitRepository, VisitRepository>();

        builder.Services.AddTransient<ITreatmentRepository, TreatmentRepository>();
        builder.Services.AddTransient<ITreatmentAndDiagnosticActionService, TreatmentAndDiagnosticActionService>();

        return builder;
    }

    public static WebApplicationBuilder AddExamServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IExamRepository, ExamRepository>();
        builder.Services.AddTransient<IExamService, ExamService>();
        builder.Services.AddTransient<IExamDefinitionRepository, ExamDefinitionRepository>();
        builder.Services.AddTransient<IExamSanofiService, ExamSanofiService>();
        builder.Services.AddTransient<IExamService, ExamService>();
        return builder;
    }

    public static WebApplicationBuilder AddVoucherServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IVoucherRepository, VoucherRepository>();
        builder.Services.AddTransient<IVoucherService, VoucherService>();

        builder.Services.AddTransient<IVoucherEntreNosService, VoucherEntreNosService>();
        builder.Services.AddTransient<IVoucherEnzimaisService, VoucherEnzimaisService>();
        builder.Services.AddTransient<IVoucherVisionCareService, VoucherVisionCareService>();

        builder.Services.AddTransient<IVoucherReativeService, VoucherReativeService>();
        builder.Services.AddTransient<IVoucherIndependenciaService, VoucherIndependenciaService>();
        builder.Services.AddTransient<IVoucherCuidaehService, VoucherCuidaehService>();
        builder.Services.AddTransient<IVoucherEmFrenteService, VoucherEmFrenteService>();
        builder.Services.AddTransient<IVoucherTakeCareService, VoucherTakeCareService>();

        builder.Services.AddTransient<ITreatmentAndDiagnosticActionService, TreatmentAndDiagnosticActionService>();
        builder.Services.AddTransient<IDiagnosticRepository, DiagnosticRepository>();
        builder.Services.AddTransient<ITreatmentRepository, TreatmentRepository>();
        builder.Services.AddTransient<IExamRepository, ExamRepository>();
        builder.Services.AddTransient<IInfusionRepository, InfusionRepository>();
        builder.Services.AddTransient<IExamDefinitionRepository, ExamDefinitionRepository>();

        return builder;
    }

    public static WebApplicationBuilder AddAddressServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IAddressService, AddressService>();

        return builder;
    }

    public static WebApplicationBuilder AddAccountServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IAccountRepository, AccountRepository>();
        builder.Services.AddTransient<IAccountService, AccountService>();
        builder.Services.AddTransient<IAccountVisionCareService, AccountVisionCareService>();

        builder.Services.AddTransient<ICryptographyService, CryptographyService>();

        builder.Services.AddTransient<IStringMapRepository, StringMapRepository>();
        builder.Services.AddTransient<IStringMapService, StringMapService>();

        builder.Services.AddTransient<IHealthProgramRepository, HealthProgramRepository>();
        builder.Services.AddTransient<IHealthProgramService, HealthProgramService>();

        builder.Services.AddTransient<IAccessProfileRepository, AccessProfileRepository>();
        builder.Services.AddTransient<IAccessProfileService, AccessProfileService>();

        builder.Services.AddTransient<IUserRepository, UserRepository>();
        builder.Services.AddTransient<IUserService, UserService>();
        builder.Services.AddTransient<IUserVisionCareService, UserVisionCareService>();

        builder.Services.AddTransient<IAccountSettingsByProgramRepository, AccountSettingsByProgramRepository>();
        builder.Services.AddTransient<IAccountSettingsByProgramService, AccountSettingsByProgramService>();

        builder.Services.AddTransient<ICredentialsService, CredentialsService>();

        return builder;
    }

    public static WebApplicationBuilder AddVisitServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<ITreatmentRepository, TreatmentRepository>();
        builder.Services.AddTransient<IVisitService, VisitService>();
        builder.Services.AddTransient<IVisitRepository, VisitRepository>();
        builder.Services.AddTransient<ITreatmentEntreNosService, TreatmentEntreNosService>();
        builder.Services.AddTransient<ITreatmentEnzimaisService, TreatmentEnzimaisService>();
        builder.Services.AddTransient<IHealthProfessionalRepository, HealthProfessionalRepository>();
        builder.Services.AddTransient<IVisitSanofiService, VisitSanofiService>();
        builder.Services.AddTransient<ISmsRepository, SmsRepository>();
        builder.Services.AddTransient<ISmsService, SmsService>();
        builder.Services.AddTransient<IHealthProfessionalByProgramRepository, HealthProfessionalByProgramRepository>();
        builder.Services.AddTransient<IStringMapRepository, StringMapRepository>();
        builder.Services.AddTransient<IStringMapService, StringMapService>();

        builder.Services.AddTransient<IHealthProgramRepository, HealthProgramRepository>();
        builder.Services.AddTransient<IHealthProgramService, HealthProgramService>();
        builder.Services.AddTransient<IMedicamentRepository, MedicamentRepository>();

        builder.Services.AddTransient<ITemplateService, TemplateService>();
        builder.Services.AddTransient<ITemplateRepository, TemplateRepository>();

        builder.Services.AddTransient<ITokenService, TokenService>();

        return builder;
    }

    public static WebApplicationBuilder AddIncidentServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<ITreatmentRepository, TreatmentRepository>();
        builder.Services.AddTransient<IVisitService, VisitService>();
        builder.Services.AddTransient<IVisitRepository, VisitRepository>();
        builder.Services.AddTransient<ITreatmentEntreNosService, TreatmentEntreNosService>();
        builder.Services.AddTransient<ITreatmentEnzimaisService, TreatmentEnzimaisService>();
        builder.Services.AddTransient<IHealthProfessionalRepository, HealthProfessionalRepository>();
        builder.Services.AddTransient<IVisitSanofiService, VisitSanofiService>();
        builder.Services.AddTransient<ISmsRepository, SmsRepository>();
        builder.Services.AddTransient<ISmsService, SmsService>();
        builder.Services.AddTransient<IHealthProfessionalByProgramRepository, HealthProfessionalByProgramRepository>();
        builder.Services.AddTransient<IStringMapRepository, StringMapRepository>();
        builder.Services.AddTransient<IStringMapService, StringMapService>();
        builder.Services.AddTransient<IIncidentRepository, IncidentRepository>();
        builder.Services.AddTransient<IIncidentService, IncidentService>();
        builder.Services.AddTransient<IIncidentSanofiService, IncidentSanofiService>();
        builder.Services.AddTransient<IHealthProgramRepository, HealthProgramRepository>();
        builder.Services.AddTransient<IIncidentEnzimaisService, IncidentEnzimaisService>();
        builder.Services.AddTransient<IIncidentEntreNosService, IncidentEntreNosService>();
        builder.Services.AddTransient<IIncidentTakeCareService, IncidentTakeCareService>();
        builder.Services.AddTransient<IHealthProgramService, HealthProgramService>();
        builder.Services.AddTransient<IMedicamentRepository, MedicamentRepository>();

        builder.Services.AddTransient<ITemplateService, TemplateService>();
        builder.Services.AddTransient<ITemplateRepository, TemplateRepository>();

        builder.Services.AddTransient<ITokenService, TokenService>();

        return builder;
    }

    public static WebApplicationBuilder AddMedicamentServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<ITreatmentRepository, TreatmentRepository>();
        builder.Services.AddTransient<IMedicamentService, MedicamentService>();
        builder.Services.AddTransient<IVisitRepository, VisitRepository>();
        builder.Services.AddTransient<ITreatmentEntreNosService, TreatmentEntreNosService>();
        builder.Services.AddTransient<ITreatmentEnzimaisService, TreatmentEnzimaisService>();
        builder.Services.AddTransient<IHealthProfessionalRepository, HealthProfessionalRepository>();
        builder.Services.AddTransient<IMedicamentSanofiService, MedicamentSanofiService>();
        builder.Services.AddTransient<ISmsRepository, SmsRepository>();
        builder.Services.AddTransient<ISmsService, SmsService>();
        builder.Services.AddTransient<IHealthProfessionalByProgramRepository, HealthProfessionalByProgramRepository>();
        builder.Services.AddTransient<IStringMapRepository, StringMapRepository>();
        builder.Services.AddTransient<IStringMapService, StringMapService>();

        builder.Services.AddTransient<IHealthProgramRepository, HealthProgramRepository>();
        builder.Services.AddTransient<IHealthProgramService, HealthProgramService>();
        builder.Services.AddTransient<IMedicamentRepository, MedicamentRepository>();

        builder.Services.AddTransient<ITemplateService, TemplateService>();
        builder.Services.AddTransient<ITemplateRepository, TemplateRepository>();

        builder.Services.AddTransient<ITokenService, TokenService>();
        builder.Services.AddTransient<ITreatmentCustomDataRepository, TreatmentCustomDataRepository>();        

        return builder;
    }


    public static WebApplicationBuilder AddTreatmentServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<ITreatmentRepository, TreatmentRepository>();
        builder.Services.AddTransient<ITreatmentService, TreatmentService>();
        builder.Services.AddTransient<IVisitRepository, VisitRepository>();
        builder.Services.AddTransient<ITreatmentEntreNosService, TreatmentEntreNosService>();
        builder.Services.AddTransient<ITreatmentEnzimaisService, TreatmentEnzimaisService>();
        builder.Services.AddTransient<ITreatmentTakeCareService, TreatmentTakeCareService>();

        builder.Services.AddTransient<ITreatmentReativeService, TreatmentReativeService>();
        builder.Services.AddTransient<ITreatmentIndependenciaService, TreatmentIndependenciaService>();
        builder.Services.AddTransient<ITreatmentCuidaehService, TreatmentCuidaehService>();
        builder.Services.AddTransient<ITreatmentEmFrenteService, TreatmentEmFrenteService>();

        builder.Services.AddTransient<IHealthProfessionalRepository, HealthProfessionalRepository>();
        builder.Services.AddTransient<ITreatmentSanofiService, TreatmentSanofiService>();
        builder.Services.AddTransient<ITreatmentMavacareService, TreatmentMavacareService>();

        builder.Services.AddTransient<ISmsRepository, SmsRepository>();
        builder.Services.AddTransient<ISmsService, SmsService>();


        builder.Services.AddTransient<ICaregiverRepository, CaregiverRepository>();
        builder.Services.AddTransient<ICaregiverTreatmentRepository, CaregiverTreatmentRepository>();

        builder.Services.AddTransient<IStringMapRepository, StringMapRepository>();
        builder.Services.AddTransient<IStringMapService, StringMapService>();

        builder.Services.AddTransient<IHealthProgramRepository, HealthProgramRepository>();
        builder.Services.AddTransient<IHealthProgramService, HealthProgramService>();
        builder.Services.AddTransient<IMedicamentRepository, MedicamentRepository>();

        builder.Services.AddTransient<ITemplateService, TemplateService>();
        builder.Services.AddTransient<ITemplateRepository, TemplateRepository>();

        builder.Services.AddTransient<ITokenService, TokenService>();
        builder.Services.AddTransient<ITreatmentAndDiagnosticActionService, TreatmentAndDiagnosticActionService>();

        builder.Services.AddTransient<IRepresentativeRepository, RepresentativeRepository>();
        builder.Services.AddTransient<IRepresentativeService, RepresentativeService>();
        builder.Services.AddTransient<IRepresentativeEnzimaisService, RepresentativeEnzimaisService>();

        builder.Services.AddTransient<IRepresentativeReativeService, RepresentativeReativeService>();
        builder.Services.AddTransient<IRepresentativeIndependenciaService, RepresentativeIndependenciaService>();
        builder.Services.AddTransient<IRepresentativeCuidaehService, RepresentativeCuidaehService>();
        builder.Services.AddTransient<IRepresentativeEmFrenteService, RepresentativeEmFrenteService>();
        builder.Services.AddTransient<IRepresentativeKiteConnectService, RepresentativeKiteConnectService>();
        builder.Services.AddTransient<IRepresentativeSanofiService, RepresentativeSanofiService>();
        

        builder.Services.AddTransient<IDoctorsRepresentativeRepository, DoctorsRepresentativeRepository>();

        builder.Services.AddTransient<ITreatmentAddressRepository, TreatmentAddressRepository>();


        builder.Services.AddTransient<ITreatmentAddressRepository, TreatmentAddressRepository>();
        builder.Services.AddTransient<ITreatmentKiteConnectService, TreatmentKiteConnectService>();

        builder.Services.AddTransient<IPhaseRepository, PhaseRepository>();

        return builder;
    }

    public static WebApplicationBuilder AddAccountSettingsByProgramServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IAccountSettingsByProgramRepository, AccountSettingsByProgramRepository>();
        builder.Services.AddTransient<IAccountSettingsByProgramService, AccountSettingsByProgramService>();

        builder.Services.AddTransient<IAccountSettingsByProgramEntreNosService, AccountSettingsByProgramEntreNosService>();
        builder.Services.AddTransient<IAccountSettingsByProgramEnzimaisService, AccountSettingsByProgramEnzimaisService>();

        builder.Services.AddTransient<IAccountSettingsByProgramReativeService, AccountSettingsByProgramReativeService>();
        builder.Services.AddTransient<IAccountSettingsByProgramIndependenciaService, AccountSettingsByProgramIndependenciaService>();
        builder.Services.AddTransient<IAccountSettingsByProgramCuidaehService, AccountSettingsByProgramCuidaehService>();
        builder.Services.AddTransient<IAccountSettingsByProgramEmFrenteService, AccountSettingsByProgramEmFrenteService>();

        return builder;
    }

    public static WebApplicationBuilder AddSurveyServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<ISurveyRepository, SurveyRepository>();
        builder.Services.AddTransient<ISurveyService, SurveyService>();

        builder.Services.AddTransient<ISurveyEntreNosService, SurveyEntreNosService>();
        builder.Services.AddTransient<ISurveySanofiService, SurveySanofiService>();
        builder.Services.AddTransient<ISurveyVisionCareService, SurveyVisionCareService>();
        builder.Services.AddTransient<ISurveyReativeService, SurveyReativeService>();
        builder.Services.AddTransient<ISurveyVidaRaraService, SurveyVidaRaraService>();

        return builder;
    }

    public static WebApplicationBuilder AddQuestionServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IQuestionRepository, QuestionRepository>();

        return builder;
    }

    public static WebApplicationBuilder AddQuestionOptionServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IQuestionOptionsRepository, QuestionOptionsRepository>();

        return builder;
    }

    public static WebApplicationBuilder AddSurveyQuestionListServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<ISurveyQuestionListRepository, SurveyQuestionListRepository>();

        return builder;
    }

    public static WebApplicationBuilder AddSurveyResponseServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<ISurveyResponseRepository, SurveyResponseRepository>();

        return builder;
    }

    public static WebApplicationBuilder AddInfusionServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IInfusionRepository, InfusionRepository>();

        return builder;
    }

    public static WebApplicationBuilder AddEmailServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IEmailRepository, EmailRepository>();
        builder.Services.AddTransient<IEmailService, EmailService>();

        builder.Services.AddTransient<IStringMapRepository, StringMapRepository>();
        builder.Services.AddTransient<IStringMapService, StringMapService>();

        builder.Services.AddTransient<IHealthProgramRepository, HealthProgramRepository>();
        builder.Services.AddTransient<IHealthProgramService, HealthProgramService>();

        builder.Services.AddTransient<ITemplateRepository, TemplateRepository>();
        builder.Services.AddTransient<ITemplateService, TemplateService>();

        return builder;
    }

    public static WebApplicationBuilder AddCalendarServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IResourceWorkSettingRepository, ResourceWorkSettingRepository>();
        builder.Services.AddTransient<IResourceWorkSettingService, ResourceWorkSettingService>();

        builder.Services.AddTransient<IStringMapService, StringMapService>();

        builder.Services.AddTransient<IHealthProgramService, HealthProgramService>();

        return builder;
    }

    public static WebApplicationBuilder AddLogisticsScheduleServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<ILogisticsScheduleRepository, LogisticsScheduleRepository>();
        builder.Services.AddTransient<ILogisticsScheduleService, LogisticsScheduleService>();

        builder.Services.AddTransient<ILogisticsScheduleEnzimaisService, LogisticsScheduleEnzimaisService>();
        builder.Services.AddTransient<ILogisticsScheduleTakeCareService, LogisticsScheduleTakeCareService>();

        builder.Services.AddTransient<ILogisticsScheduleReativeService, LogisticsScheduleReativeService>();
        builder.Services.AddTransient<ILogisticsScheduleIndependenciaService, LogisticsScheduleIndependenciaService>();
        builder.Services.AddTransient<ILogisticsScheduleCuidaehService, LogisticsScheduleCuidaehService>();
        builder.Services.AddTransient<ILogisticsScheduleEmFrenteService, LogisticsScheduleEmFrenteService>();

        builder.Services.AddTransient<ISchedulingHistoryRepository, SchedulingHistoryRepository>();
        builder.Services.AddTransient<IStringMapRepository, StringMapRepository>();
        builder.Services.AddTransient<IConfigurationRepository, ConfigurationRepository>();
        builder.Services.AddTransient<IDiagnosticRepository, DiagnosticRepository>();

        builder.Services.AddTransient<IHealthProfessionalRepository, HealthProfessionalRepository>();

        builder.Services.AddTransient<IIncidentRepository, IncidentRepository>();

        return builder;
    }

    public static WebApplicationBuilder AddTreatmentAndDiagnosticActionServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<ITreatmentAndDiagnosticActionRepository, TreatmentAndDiagnosticActionRepository>();
        builder.Services.AddTransient<ITreatmentAndDiagnosticActionService, TreatmentAndDiagnosticActionService>();

        builder.Services.AddTransient<ITreatmentAndDiagnosticActionService, TreatmentAndDiagnosticActionService>();
        builder.Services.AddTransient<ITreatmentRepository, TreatmentRepository>();
        builder.Services.AddTransient<IActionConfigurationRepository, ActionConfigurationRepository>();
        builder.Services.AddTransient<IHealthProgramRepository, HealthProgramRepository>();
        builder.Services.AddTransient<IStringMapRepository, StringMapRepository>();

        return builder;
    }

    public static WebApplicationBuilder AddReportActionServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IReportRepository, ReportRepository>();
        builder.Services.AddTransient<IReportService, ReportService>();
        builder.Services.AddTransient<IDapperReportRepository, DapperReportRepository>();
        return builder;
    }
    public static WebApplicationBuilder AddCalendarResourceWorkSettingsServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IResourceWorkSettingRepository, ResourceWorkSettingRepository>();
        builder.Services.AddTransient<IResourceWorkSettingService, ResourceWorkSettingService>();

        builder.Services.AddTransient<IStringMapService, StringMapService>();

        builder.Services.AddTransient<IHealthProgramService, HealthProgramService>();

        builder.Services.AddTransient<IVisitRepository, VisitRepository>();

        return builder;
    }

    public static WebApplicationBuilder AddLogisticServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<ILogisticsRepository, LogisticsRepository>();
        builder.Services.AddTransient<ILogisticsService, LogisticsService>();

        builder.Services.AddTransient<ILogisticEnzimaisService, LogisticsEnzimaisService>();

        builder.Services.AddTransient<ILogisticReativeService, LogisticsReativeService>();
        builder.Services.AddTransient<ILogisticIndependenciaService, LogisticsIndependenciaService>();
        builder.Services.AddTransient<ILogisticCuidaehService, LogisticsCuidaehService>();
        builder.Services.AddTransient<ILogisticEmFrenteService, LogisticsEmFrenteService>();

        builder.Services.AddTransient<ISchedulingHistoryRepository, SchedulingHistoryRepository>();
        builder.Services.AddTransient<IStringMapRepository, StringMapRepository>();
        builder.Services.AddTransient<IConfigurationRepository, ConfigurationRepository>();
        builder.Services.AddTransient<IDiagnosticRepository, DiagnosticRepository>();

        return builder;
    }

    public static WebApplicationBuilder AddChatServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IChatRepository, ChatRepository>();

        return builder;
    }

    public static WebApplicationBuilder AddChatbotWhatsAppServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IChatbotWhatsAppService, ChatbotWhatsAppService>();
        builder.Services.AddTransient<IChatbotWhatsAppScheduleProvider, ChatbotWhatsAppScheduleProvider>();
        builder.Services.AddTransient<IChatbotWhatsAppEmFrenteService, ChatbotWhatsAppEmFrenteService>();
        builder.Services.AddTransient<IScheduleEmFrenteStatup, ScheduleEmFrenteStatup>();

        builder.Services.AddTransient<IIncidentReativeService, IncidentReativeService>();
        builder.Services.AddTransient<IIncidentIndependenciaService, IncidentIndependenciaService>();
        builder.Services.AddTransient<IIncidentCuidaehService, IncidentCuidaehService>();
        builder.Services.AddTransient<IIncidentEmFrenteService, IncidentEmFrenteService>();
        builder.Services.AddTransient<IIncidentEnzimaisService, IncidentEnzimaisService>();

        builder.Services.AddTransient<ITreatmentAndDiagnosticActionService, TreatmentAndDiagnosticActionService>();
        builder.Services.AddTransient<ITreatmentAndDiagnosticActionRepository, TreatmentAndDiagnosticActionRepository>();

        return builder;
    }

    public static WebApplicationBuilder AddVivaServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IVivaService, VivaService>();
        builder.Services.AddTransient<IVivaRepository, VivaRepository>();

        return builder;
    }

    //AutoMapper
    public static WebApplicationBuilder AddAutoMapperConfig(this WebApplicationBuilder builder)
    {
        AutoMapperConfig.ConfigureMappings(builder.Services);

        return builder;
    }

    public static WebApplicationBuilder AddRepresentativeDoctorByProgramServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IRepresentativeDoctorByProgramRepository, RepresentativeDoctorByProgramRepository>();
        
        return builder;
    }
    
    public static WebApplicationBuilder AddStockServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IStockService, StockService>();
        builder.Services.AddTransient<IStockHistoryService, StockHistoryService>();

        builder.Services.AddTransient<IStockEnzimaisService, StockEnzimaisService>();
        builder.Services.AddTransient<IStockHistoryEnzimaisService, StockHistoryEnzimaisService>();

        builder.Services.AddTransient<IStockRepository, StockRepository>();
        builder.Services.AddTransient<IStockHistoryRepository, StockHistoryRepository>();

        builder.Services.AddTransient<IStockIndependenciaService, StockIndependenciaService>();
        builder.Services.AddTransient<IStockHistoryIndependenciaService, StockHistoryIndependenciaService>();




        return builder;
    }

    public static WebApplicationBuilder UrlShortenerServices(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<ShortLinkSettings>(builder.Configuration.GetSection("UrlShortenerSettings"));

        builder.Services.Configure<UrlClickTrackingSettings>(builder.Configuration.GetSection("UrlClickTrackingSettings"));

        builder.Services.AddTransient<IUrlShortenerService, UrlShortenerService>();
        builder.Services.AddTransient<IUrlShortenerRepository, UrlShortenerRepository>();

        builder.Services.AddTransient<IClickTrackingService, ClickTrackingService>();

        builder.Services.AddTransient<ITemplateConfigurationRepository, TemplateConfigurationRepository>();

        builder.Services.AddTransient<IClickTrackingRepository, ClickTrackingRepository>();

        builder.Services.AddTransient<IShortenerBaseService, ShortenerBaseService>();

        builder.Services.AddTransient<IShortenerEmailService, ShortenerEmailService>();

        builder.Services.AddTransient<IShortenerSmsService, ShortenerSmsService>();


        return builder;
    }
}