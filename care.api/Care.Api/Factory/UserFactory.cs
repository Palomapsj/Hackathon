using Care.Api.Business.Interfaces;

namespace Care.Api.Factory;

public class UserFactory
{
    public static IUserService GetInstance(IServiceProvider serviceProvider, string programcode)
    {
        switch (programcode)
        {
            
            default:
                return serviceProvider.GetRequiredService<IUserService>();
        }
    }
}
