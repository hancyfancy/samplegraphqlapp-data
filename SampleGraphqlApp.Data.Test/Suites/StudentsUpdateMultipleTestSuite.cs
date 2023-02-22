using SampleGraphqlApp.Data.Interface.Models.Transient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleGraphqlApp.Data.Test.Suites
{
    public class StudentsUpdateMultipleTestSuite : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            //Not populated
            //yield return new object[] {
            //    $@"[]",
            //    new List<IdentifiableExistingStudent>() {}
            //};

            //Not populated
            yield return new object[] {
                $@"[
					{{
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
					}},
					{{
						""id"": ""ea1ded401cc6462c9f6bd25290723c52"",
						""firstName"": ""Ming"",
						""lastName"": ""Hua"",
						""email"": ""ming.hua@gmail.com"",
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
					}}
				]",
                new List<IdentifiableExistingStudent>() {
                    new IdentifiableExistingStudent() { 
                        id = "S1001",
                        student = new ExistingStudent() { 
                            email = "tom.bom@gmail.com",
                            firstName = "Tom",
                            lastName = "Bom",
                            collegeId = "col-102"
                        }
                    },
                    new IdentifiableExistingStudent() { 
                        id = "S1002",
                        student = new ExistingStudent() { 
                            email = "ming.hua@gmail.com",
                            firstName = "Ming",
                            lastName = "Hua",
                            collegeId = "col-101"
                        }
                    }
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
    