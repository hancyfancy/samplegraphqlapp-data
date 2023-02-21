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
                                        lastName
                                        firstName
                                        college {{
                                          name
                                          location
                                          books {{
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
