using Newtonsoft.Json;
using SampleGraphqlApp.Data.Interface.Models;
using SampleGraphqlApp.Data.Interface.Repositories;

namespace SampleGraphqlApp.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public async Task<IEnumerable<Student>?> All() 
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9000");
                string query = $@"{{
                                    students {{
                                        id
                                        firstName
                                        lastName
                                        email
                                        college {{
                                          id
                                          name
                                          location
                                          rating
                                          books {{
                                            id
                                            name
                                            author
                                          }}
                                        }}
                                    }}
                                }}";
                HttpContent content = new StringContent(query);
                var result = await client.PostAsync("/graphql", content);
                string resultContent = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Student>>(resultContent);
            }
        }

        public async Task<Student?> ById(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9000");
                string query = $@"{{
                                  student(id: ""{id}"") {{
                                    firstName
                                    lastName
                                    email
                                    college {{
                                      id
                                      name
                                      location
                                      rating
                                      books {{
                                        id
                                        name
                                        author
                                      }}
                                    }}
                                  }}
                                }}";
                HttpContent content = new StringContent(query);
                var result = await client.PostAsync("/graphql", content);
                string resultContent = await result.Content.ReadAsStringAsync();
                dynamic? resultContentObj = JsonConvert.DeserializeObject<dynamic>(resultContent);
                return resultContentObj?.data.studentsBy;
            }
        }

        public async Task<IEnumerable<Student>?> ByProperties(
            string email,
            string firstName,
            string lastName,
            string collegeId
        )
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9000");

                string queryEmail = string.IsNullOrWhiteSpace(email)
                                    ? ""
                                    : $@"email: {email}";
                string queryFirstName = string.IsNullOrWhiteSpace(firstName)
                                    ? ""
                                    : $@"firstName: {firstName}";
                string queryLastName = string.IsNullOrWhiteSpace(lastName)
                                    ? ""
                                    : $@"lastName: {lastName}";
                string queryCollegeId = string.IsNullOrWhiteSpace(collegeId)
                                    ? ""
                                    : $@"collegeId: {collegeId}";

                string query = $@"{{
                                  studentsBy(search: {{
                                      {queryEmail}
                                      {queryFirstName}
                                      {queryLastName}
                                      {queryCollegeId}
                                    }})
                                    {{
                                        id
                                        firstName
                                        lastName
                                        email
                                        college {{
                                          id
                                          name
                                          location
                                          rating
                                          books {{
                                            id
                                            name
                                            author
                                          }}
                                        }}
                                      }}
                                    }}";
                HttpContent content = new StringContent(query);
                var result = await client.PostAsync("/graphql", content);
                string resultContent = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Student>>(resultContent);
            }
        }
    }
}
