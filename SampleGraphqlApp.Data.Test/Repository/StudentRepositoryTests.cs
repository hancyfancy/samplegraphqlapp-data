using Newtonsoft.Json;
using SampleGraphqlApp.Data.Interface.Models;
using SampleGraphqlApp.Data.Interface.Repositories;

namespace SampleGraphqlApp.Data.Test.Repository
{
    public class StudentRepositoryTests
    {
        private readonly IStudentRepository _studentRepository;

        public StudentRepositoryTests(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [Fact]
        public async Task AllTest()
        {
            IEnumerable<Student>? students = await _studentRepository.All();

            Assert.NotNull(students);

            Assert.NotEqual("[]", JsonConvert.SerializeObject(students));
        }
    }
}
