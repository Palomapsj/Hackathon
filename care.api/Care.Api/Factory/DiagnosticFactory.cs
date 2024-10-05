using Care.Api.Business.Interfaces;


namespace Care.Api.Factory
{
    public static class DiagnosticFactory
    {
        public static IDiagnosticService GetInstance(IServiceProvider serviceProvider, string programCode)
        {
            switch (programCode)
            {
                
                default:
                    return serviceProvider.GetRequiredService<IDiagnosticService>();
            }
        }
    }
}