using Care.Api.Business.Interfaces;

namespace Care.Api.Factory
{
    public class ExamFactory
    {
        public static IExamService GetInstance(IServiceProvider serviceProvider, string programcode)
        {
            switch (programcode)
            {
             
                default:
                    return serviceProvider.GetRequiredService<IExamService>();
            }
        }
    }
}


