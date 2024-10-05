using Care.Api.Extensions;
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);

bool authenticationJwtActive = false;

try
{
    authenticationJwtActive = Convert.ToBoolean(builder.Configuration["Jwt:AuthenticationJwtActive"]);
}
catch (Exception) { }


builder.Services
    .AddControllersWithViews()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

builder.AddApiSwagger(authenticationJwtActive);

builder.AddPersistence();

if (authenticationJwtActive)
    builder.AddAuthenticationJwt();
else
    builder.AddAuthenticationHandler();

builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(config =>
{
    config.AddPolicy("CorsPolicy", option =>
    {
        option
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(_ => true)
            .AllowCredentials();
    });

    config.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("https://enzimais.viveo.com.br")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials());

    config.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("https://entrenos.viveo.com.br")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials());

    config.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("https://visioncare.viveo.com.br")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                           .AllowCredentials());

    config.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("https://programaviva.viveo.com.br")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                           .AllowCredentials());
    config.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("https://rarobuscador.com.br")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                           .AllowCredentials());

});

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.None;
    options.HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always;

    options.Secure = CookieSecurePolicy.Always;
});

builder.AddSessionMiddle();

builder.AddCryptographyService();

builder.AddUserServices();

builder.AddLoginService();

builder.AddPatientServices();
builder.AddRepresentativeServices();

builder.AddDoctorServices();

builder.AddCFMServices();

builder.AddHealthProgramServices();

builder.AddDiagnosticServices();

builder.AddExamServices();

builder.AddVoucherServices();
builder.AddIncidentServices();
builder.AddVisitServices();
builder.AddMedicamentServices();

builder.AddAddressServices();

builder.AddAccountServices();

builder.AddTreatmentServices();

builder.AddAccountSettingsByProgramServices();

builder.AddSurveyServices();

builder.AddQuestionServices();

builder.AddQuestionOptionServices();

builder.AddSurveyQuestionListServices();

builder.AddSurveyResponseServices();

builder.AddInfusionServices();

builder.AddEmailServices();

builder.AddCalendarServices();

builder.AddCalendarResourceWorkSettingsServices();

builder.AddLogisticsScheduleServices();

builder.AddTreatmentAndDiagnosticActionServices();

builder.AddLogisticServices();

builder.AddChatbotWhatsAppServices();

builder.AddChatServices();

builder.AddIncidentServices();

builder.AddReportActionServices();

builder.AddVivaServices();

builder.AddRepresentativeDoctorByProgramServices();

builder.AddStockServices();

builder.UrlShortenerServices();



//O mapeamento dos repositorios devem ficar acima desse middleware
builder.AddAutoMapperConfig();

var app = builder.Build();
var environment = app.Environment;

app.UseSession();

app.UseExceptionHandling(environment)
    .UseSwaggerMiddleware(environment);

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("CorsPolicy");

app.UseCors("AllowSpecificOrigin");

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseHttpsRedirection();

var maxRequestBodySize = builder.Configuration.GetValue<long>("MaxRequestBodySize");
if (maxRequestBodySize <= 0)
{
    maxRequestBodySize = 10_737_418_240;
}

app.Use((context, next) =>
{
    context.Features.Get<IHttpMaxRequestBodySizeFeature>().MaxRequestBodySize = maxRequestBodySize;
    return next();
});

app.MapControllers();

app.Run();
