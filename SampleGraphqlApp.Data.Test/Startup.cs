using Microsoft.Extensions.DependencyInjection;
using SampleGraphqlApp.Data.Interface.Repositories;
using SampleGraphqlApp.Data.Repositories;

namespace SampleGraphqlApp.Data.Test
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IStudentRepository, StudentRepository>();
        }
    }
}
