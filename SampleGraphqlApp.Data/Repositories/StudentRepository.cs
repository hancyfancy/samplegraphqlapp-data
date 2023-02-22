using GraphQL.Client.Http;
using GraphQL;
using Newtonsoft.Json;
using SampleGraphqlApp.Data.Interface.Models;
using SampleGraphqlApp.Data.Interface.Repositories;
using GraphQL.Client.Serializer.Newtonsoft;
using Newtonsoft.Json.Linq;
using System.Dynamic;

namespace SampleGraphqlApp.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public async Task<IEnumerable<Student>?> All() 
        {
            using (var client = new GraphQLHttpClient("http://localhost:9000/graphql", new NewtonsoftJsonSerializer()))
            {
                var request = new GraphQLRequest
                {
                    Query = @"
                            query Students {
                                students {
                                    id
                                    firstName
                                    lastName
                                    email
                                    college {
                                        id
                                        name
                                        location
                                        rating
                                        books {
                                        id
                                        name
                                        author
                                        }
                                    }
                                }
                            }",
                    OperationName = "Students"
                };

                dynamic response = await client.SendQueryAsync<ExpandoObject>(request);

                return JsonConvert.DeserializeObject<IEnumerable<Student>>(JsonConvert.SerializeObject(response.Data.students));
            }
        }

        public async Task<Student?> ById(string id)
        {
            using (var client = new GraphQLHttpClient("http://localhost:9000/graphql", new NewtonsoftJsonSerializer()))
            {
                var request = new GraphQLRequest
                {
                    Query = @"
                            query Student($id: ID!) {
                                student(id: $id) {
                                    id
                                    firstName
                                    lastName
                                    email
                                    college {
                                        id
                                        name
                                        location
                                        rating
                                        books {
                                        id
                                        name
                                        author
                                        }
                                    }
                                }
                            }",
                    OperationName = "Student",
                    Variables = new
                    {
                        id = id
                    }
                };

                dynamic response = await client.SendQueryAsync<ExpandoObject>(request);

                return JsonConvert.DeserializeObject<Student>(JsonConvert.SerializeObject(response.Data.student));
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
