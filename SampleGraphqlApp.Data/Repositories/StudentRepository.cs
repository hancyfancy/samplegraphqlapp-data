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

                return JsonConvert.DeserializeObject<IEnumerable<Student>>(JsonConvert.SerializeObject(response.Data?.students));
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

                return JsonConvert.DeserializeObject<Student>(JsonConvert.SerializeObject(response.Data?.student));
            }
        }

        public async Task<IEnumerable<Student>?> ByProperties(
            string email,
            string firstName,
            string lastName,
            string collegeId
        )
        {
            using (var client = new GraphQLHttpClient("http://localhost:9000/graphql", new NewtonsoftJsonSerializer()))
            {
                var request = new GraphQLRequest
                {
                    Query = @"
                            query StudentsBy(
                                $email: String!
                                $firstName: String!
                                $lastName: String!
                                $collegeId: ID!
                            ) 
                            {
                                studentsBy(search: 
                                {
                                    email: $email
                                    firstName: $firstName
                                    lastName: $lastName
                                    collegeId: $collegeId
                                }) 
                                {
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
                    OperationName = "StudentsBy",
                    Variables = new
                    {
                        email = email,
                        firstName = firstName,
                        lastName = lastName,
                        collegeId = collegeId
                    }
                };

                dynamic response = await client.SendQueryAsync<ExpandoObject>(request);

                return JsonConvert.DeserializeObject<IEnumerable<Student>>(JsonConvert.SerializeObject(response.Data?.studentsBy));
            }
        }

        public async Task<Student?> Add(
            string email,
            string firstName,
            string lastName,
            string collegeId
        )
        {
            using (var client = new GraphQLHttpClient("http://localhost:9000/graphql", new NewtonsoftJsonSerializer()))
            {
                var request = new GraphQLRequest
                {
                    Query = @"mutation AddStudent(
                                $email: String!
                                $firstName: String!
                                $lastName: String!
                                $collegeId: ID!
                            ) 
                            {
                                addStudent(student: 
                                {
                                    email: $email
                                    firstName: $firstName
                                    lastName: $lastName
                                    collegeId: $collegeId
                                }) 
                                {
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
                            OperationName = "AddStudent",
                            Variables = new
                            {
                                email = email,
                                firstName = firstName,
                                lastName = lastName,
                                collegeId = collegeId
                            }
                        };

                dynamic response = await client.SendMutationAsync<ExpandoObject>(request);

                return JsonConvert.DeserializeObject<Student>(JsonConvert.SerializeObject(response.Data?.addStudent));
            }
        }
    }
}
