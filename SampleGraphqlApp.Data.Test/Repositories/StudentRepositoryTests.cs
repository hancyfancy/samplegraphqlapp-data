using Newtonsoft.Json;
using SampleGraphqlApp.Data.Interface.Models;
using SampleGraphqlApp.Data.Interface.Repositories;
using SampleGraphqlApp.Data.Repositories;
using SampleGraphqlApp.Data.Test.Suites;
using System.Text.RegularExpressions;

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
        public async Task ByPropertiesTest(string expectedResult, string email, string firstName, string lastName, string collegeId)
        {
            IEnumerable<Student>? students = await _studentRepository.ByProperties(email, firstName, lastName, collegeId);

            Assert.Equal(JsonConvert.SerializeObject(JsonConvert.DeserializeObject(expectedResult), Formatting.None), JsonConvert.SerializeObject(students));
        }
    }
}
