﻿using GraphQL.Client.Http;
using GraphQL;
using Newtonsoft.Json;
using SampleGraphqlApp.Data.Interface.Repositories;
using GraphQL.Client.Serializer.Newtonsoft;
using System.Dynamic;
using SampleGraphqlApp.Data.Interface.Models.Complete;
using SampleGraphqlApp.Data.Interface.Models.Transient;

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

        public async Task<IEnumerable<Student>?> ByProperties(ProspectiveStudent prospectiveStudent)
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
                        email = prospectiveStudent.email,
                        firstName = prospectiveStudent.firstName,
                        lastName = prospectiveStudent.lastName,
                        collegeId = prospectiveStudent.collegeId
                    }
                };

                dynamic response = await client.SendQueryAsync<ExpandoObject>(request);

                return JsonConvert.DeserializeObject<IEnumerable<Student>>(JsonConvert.SerializeObject(response.Data?.studentsBy));
            }
        }

        public async Task<Student?> Add(ProspectiveStudent prospectiveStudent)
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
                                email = prospectiveStudent.email,
                                firstName = prospectiveStudent.firstName,
                                lastName = prospectiveStudent.lastName,
                                collegeId = prospectiveStudent.collegeId
                            }
                        };

                dynamic response = await client.SendMutationAsync<ExpandoObject>(request);

                return JsonConvert.DeserializeObject<Student>(JsonConvert.SerializeObject(response.Data?.addStudent));
            }
        }

        public async Task<IEnumerable<Student>?> AddMultiple(IEnumerable<ProspectiveStudent> prospectiveStudents)
        {
            using (var client = new GraphQLHttpClient("http://localhost:9000/graphql", new NewtonsoftJsonSerializer()))
            {
                var request = new GraphQLRequest
                {
                    Query = @"mutation AddStudents(
                        $students: [StudentMutationParameters!]!
                    ) 
                    {
                        addStudents(students: $students) 
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
                    OperationName = "AddStudents",
                    Variables = new
                    {
                        students = prospectiveStudents
                    }
                };

                dynamic response = await client.SendMutationAsync<ExpandoObject>(request);

                return JsonConvert.DeserializeObject<IEnumerable<Student>>(JsonConvert.SerializeObject(response.Data?.addStudents));
            }
        }

        public async Task<Student?> Update(string id, ExistingStudent existingStudent)
        {
            using (var client = new GraphQLHttpClient("http://localhost:9000/graphql", new NewtonsoftJsonSerializer()))
            {
                var request = new GraphQLRequest
                {
                    Query = @"mutation UpdateStudent(
                        $id: ID!
                        $student: StudentParameters!
                    ) 
                    {
                        updateStudent(
                            id: $id
                            student: $student
                        ) 
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
                    OperationName = "UpdateStudent",
                    Variables = new
                    {
                        id = id,
                        student = existingStudent
                    }
                };

                dynamic response = await client.SendMutationAsync<ExpandoObject>(request);

                return JsonConvert.DeserializeObject<Student>(JsonConvert.SerializeObject(response.Data?.updateStudent));
            }
        }
    }
}
