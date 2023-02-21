using SampleGraphqlApp.Data.Interface.Models;

namespace SampleGraphqlApp.Data.Interface.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>?> All();

        Task<Student?> ById(string id);

        Task<IEnumerable<Student>?> ByProperties(
            string email,
            string firstName,
            string lastName,
            string collegeId
        );
    }
}
