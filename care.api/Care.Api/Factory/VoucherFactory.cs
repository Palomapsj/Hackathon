using Care.Api.Business.Interfaces;

namespace Care.Api.Factory;

public class VoucherFactory
{
    public static IVoucherService GetInstance(IServiceProvider serviceProvider, string? programcode)
    {
        switch (programcode)
        {
            
            default:
                return serviceProvider.GetRequiredService<IVoucherService>();
        }
    }
}
