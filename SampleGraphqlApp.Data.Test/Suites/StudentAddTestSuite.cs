using SampleGraphqlApp.Data.Interface.Models.Transient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleGraphqlApp.Data.Test.Suites
{
    public class StudentAddTestSuite : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            //No fields populated
            yield return new object[] {
                $@"null",
                new ProspectiveStudent() {
                    email = "",
                    firstName = "",
                    lastName = "",
                    collegeId = ""
                }
            };

            //All fields but one populated
            yield return new object[] {
                $@"null",
                new ProspectiveStudent() {
                    email = "tom.bom@gmail.com",
                    firstName = "Tom",
                    lastName = "Bom",
                    collegeId = ""
                }
            };

            //All fields populated, new record
            yield return new object[] {
                $@"{{
	                ""id"": ""25a711ec3da4020ca6a4e6012561124e"",
	                ""firstName"": ""Tom"",
	                ""lastName"": ""Bom"",
	                ""email"": ""tom.bom@gmail.com"",
	                ""college"": 
	                {{
		                ""id"": ""col-101"",
		                ""name"": ""AMU"",
		                ""location"": ""Uttar Pradesh"",
		                ""rating"": 5.0,
		                ""books"": 
		                [
			                {{
				                ""id"": ""bok-103"",
				                ""name"": ""The Last Flair Bender"",
				                ""author"": ""Manny Abuduo"",
                                ""colleges"":null
			                }},
			                {{
				                ""id"": ""bok-105"",
				                ""name"": ""On the wild side"",
				                ""author"": ""Harriett Osbyorne"",
                                ""colleges"":null
			                }}
		                ],
                        ""students"":null
	                }}
                }}",
                new ProspectiveStudent() {
                    email = "tom.bom@gmail.com",
                    firstName = "Tom",
                    lastName = "Bom",
                    collegeId = "col-101"
                }
            };

            //All fields populated, existing record change foreign key collegeId
            yield return new object[] {
                $@"{{
					""id"": ""25a711ec3da4020ca6a4e6012561124e"",
					""firstName"": ""Tom"",
					""lastName"": ""Bom"",
					""email"": ""tom.bom@gmail.com"",
					""college"": 
					{{
						""id"": ""col-102"",
						""name"": ""CUSAT"",
						""location"": ""Kerala"",
						""rating"": 4.5,
						""books"": 
						[
							{{
								""id"": ""bok-102"",
								""name"": ""Knight and Bay"",
								""author"": ""Zon Drekka"",
								""colleges"":null
							}},
							{{
								""id"": ""bok-105"",
								""name"": ""On the wild side"",
								""author"": ""Harriett Osbyorne"",
								""colleges"":null
							}},
							{{
								""id"": ""bok-106"",
								""name"": ""Empty Space"",
								""author"": ""Xelvudi Trilchanov"",
								""colleges"":null
							}}
						],
						""students"":null
					}}
				}}",
                new ProspectiveStudent() {
                    email = "tom.bom@gmail.com",
                    firstName = "Tom",
                    lastName = "Bom",
                    collegeId = "col-102"
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
