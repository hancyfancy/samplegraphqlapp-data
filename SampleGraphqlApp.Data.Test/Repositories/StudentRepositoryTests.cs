using Newtonsoft.Json;
using SampleGraphqlApp.Data.Interface.Models.Complete;
using SampleGraphqlApp.Data.Interface.Models.Transient;
using SampleGraphqlApp.Data.Interface.Repositories;
using SampleGraphqlApp.Data.Test.Suites;

namespace SampleGraphqlApp.Data.Test.Repositories
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

        [Theory]
        [ClassData(typeof(StudentByIdTestSuite))]
        public async Task ByIdTest(string expectedResult, string id)
        {
            Student? student = await _studentRepository.ById(id);

            Assert.Equal(JsonConvert.SerializeObject(JsonConvert.DeserializeObject(expectedResult), Formatting.None), JsonConvert.SerializeObject(student));
        }

        [Theory]
        [ClassData(typeof(StudentsByPropertiesTestSuite))]
        public async Task ByPropertiesTest(string expectedResult, ProspectiveStudent prospectiveStudent)
        {
            IEnumerable<Student>? students = await _studentRepository.ByProperties(prospectiveStudent);

            Assert.Equal(JsonConvert.SerializeObject(JsonConvert.DeserializeObject(expectedResult), Formatting.None), JsonConvert.SerializeObject(students));
        }

        [Theory]
        [ClassData(typeof(StudentAddTestSuite))]
        public async Task AddTest(string expectedResult, ProspectiveStudent prospectiveStudent)
        {
            Student? student = await _studentRepository.Add(prospectiveStudent);

            Assert.Equal(JsonConvert.SerializeObject(JsonConvert.DeserializeObject(expectedResult), Formatting.None), JsonConvert.SerializeObject(student));
        }
    }
}
