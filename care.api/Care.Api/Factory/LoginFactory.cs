using Care.Api.Business.Interfaces;


namespace Care.Api.Factory
{
    public static class LoginFactory
    {
        public static ILoginService GetInstance(IServiceProvider serviceProvider, string programCode)
        {
            switch (programCode)
            {
                
                default:
                    return serviceProvider.GetRequiredService<ILoginService>();
            }
        }
    }
}
