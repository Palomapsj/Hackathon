using AutoMapper;
using Care.Api.Business.AutoMapperConfiguration.Mapper;
using Care.Api.Business.Models;
using Care.Api.Models.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Care.Api.Business.AutoMapperConfiguration
{
    public static class AutoMapperConfig
    {
        public static void ConfigureMappings(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ShortLinkModel, UrlShortener>().ReverseMap();
                cfg.CreateMap<UrlShortener, ShortLinkModel>().ReverseMap();

                cfg.CreateMap<ClickTracking, ClickTrackingModel>().ReverseMap();
                cfg.CreateMap<ClickTrackingModel, ClickTracking>().ReverseMap();

                cfg.AddProfile(new TreatmentFunctionalMappings(services.BuildServiceProvider().GetRequiredService<IStringMapRepository>(),
                                           services.BuildServiceProvider().GetRequiredService<ITreatmentCustomDataRepository>(),
                                           services.BuildServiceProvider().GetRequiredService<ITreatmentAddressRepository>(),
                                           services.BuildServiceProvider().GetRequiredService<IDoctorRepository>(),
                                           services.BuildServiceProvider().GetRequiredService<IHealthProgramRepository>(),
                                           services.BuildServiceProvider().GetRequiredService<ICaregiverRepository>()));
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
