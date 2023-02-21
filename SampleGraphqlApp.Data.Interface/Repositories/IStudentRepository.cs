using SampleGraphqlApp.Data.Interface.Models;

namespace SampleGraphqlApp.Data.Interface.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>?> All();
    }
}
