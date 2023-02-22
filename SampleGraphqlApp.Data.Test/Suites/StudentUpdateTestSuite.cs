using SampleGraphqlApp.Data.Interface.Models.Transient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleGraphqlApp.Data.Test.Suites
{
    public class StudentUpdateTestSuite : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            //Non-existent id
            yield return new object[] {
                $@"null",
                "",
                new ExistingStudent() {
                    email = "tom.bom@gmail.com",
                    firstName = "Tom",
                    lastName = "Bom",
                    collegeId = "col-102"
                }
            };

            //Existent id, empty properties
            yield return new object[] {
                $@"{{
	                ""id"": ""8c22b428da28ace9ccb4a7ca7ef27170"",
	                ""firstName"": ""Tom"",
	                ""lastName"": ""Panigrahi"",
	                ""email"": ""kiran.panigrahi@tutorialpoint.org"",
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
                "S1003",
                new ExistingStudent() {
                    email = "",
                    firstName = "Tom",
                    lastName = "",
                    collegeId = ""
                }
            };

            //Existent id, single property
            yield return new object[] {
                $@"{{
					""id"": ""8c22b428da28ace9ccb4a7ca7ef27170"",
					""firstName"": ""Tom"",
					""lastName"": ""Panigrahi"",
					""email"": ""kiran.panigrahi@tutorialpoint.org"",
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
                "8c22b428da28ace9ccb4a7ca7ef27170",
                new ExistingStudent() {
                    firstName = "Tom"
                }
            };

            //Existent id, no properties
            yield return new object[] {
                $@"{{
					""id"": ""8c22b428da28ace9ccb4a7ca7ef27170"",
					""firstName"": ""Tom"",
					""lastName"": ""Panigrahi"",
					""email"": ""kiran.panigrahi@tutorialpoint.org"",
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
                "8c22b428da28ace9ccb4a7ca7ef27170",
                new ExistingStudent() {}
            };

            //Existent id, single null property
            yield return new object[] {
                $@"{{
					""id"": ""8c22b428da28ace9ccb4a7ca7ef27170"",
					""firstName"": ""Tom"",
					""lastName"": ""Panigrahi"",
					""email"": ""kiran.panigrahi@tutorialpoint.org"",
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
                "8c22b428da28ace9ccb4a7ca7ef27170",
                new ExistingStudent() {
                    email = null
                }
            };

            //Existent id, single empty string property
            yield return new object[] {
                $@"{{
					""id"": ""8c22b428da28ace9ccb4a7ca7ef27170"",
					""firstName"": ""Tom"",
					""lastName"": ""Panigrahi"",
					""email"": ""kiran.panigrahi@tutorialpoint.org"",
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
                "8c22b428da28ace9ccb4a7ca7ef27170",
                new ExistingStudent() {
                    email = ""
                }
            };

            //Existent id, all properties
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
                "8c22b428da28ace9ccb4a7ca7ef27170",
                new ExistingStudent() {
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
