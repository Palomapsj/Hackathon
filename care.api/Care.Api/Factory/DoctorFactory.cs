using Care.Api.Business.Interfaces;

namespace Care.Api.Factory
{
    public class DoctorFactory
    {
        public static IDoctorService GetInstance(IServiceProvider serviceProvider, string programcode)
        {
            switch (programcode)
            {
                default:
                    return serviceProvider.GetRequiredService<IDoctorService>();
            }
        }
    }
}
