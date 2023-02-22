using SampleGraphqlApp.Data.Interface.Models.Complete;
using SampleGraphqlApp.Data.Interface.Models.Transient;

namespace SampleGraphqlApp.Data.Interface.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>?> All();

        Task<Student?> ById(string id);

        Task<IEnumerable<Student>?> ByProperties(ProspectiveStudent prospectiveStudent);

        Task<Student?> Add(ProspectiveStudent prospectiveStudent);

        Task<IEnumerable<Student>?> AddMultiple(IEnumerable<ProspectiveStudent> prospectiveStudents);
    }
}
