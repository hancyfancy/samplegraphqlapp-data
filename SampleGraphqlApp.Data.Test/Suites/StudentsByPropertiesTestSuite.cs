using SampleGraphqlApp.Data.Interface.Models.Transient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleGraphqlApp.Data.Test.Suites
{
    public class StudentsByPropertiesTestSuite : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            //No fields populated
            yield return new object[] {
                $@"[]",
				new ProspectiveStudent() {
                    email = "",
					firstName = "",
					lastName = "",
					collegeId = ""
                }
            };

            //Email populated
            yield return new object[] {
                $@"[
					{{
						""id"": ""S1003"",
						""firstName"": ""Kiran"",
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
					}}
				]",
                new ProspectiveStudent() {
                    email = "kiran.panigrahi@tutorialpoint.org",
                    firstName = "",
                    lastName = "",
                    collegeId = ""
                }
            };

            //FirstName populated
            yield return new object[] {
                $@"[
					{{
						""id"": ""S1001"",
						""firstName"": ""Mohtashim"",
						""lastName"": ""Mohammad"",
						""email"": ""mohtashim.mohammad@tutorialpoint.org"",
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
					}}
				]",
                new ProspectiveStudent() {
                    email = "",
                    firstName = "Mohtashim",
                    lastName = "",
                    collegeId = ""
                }
            };

            //LastName populated
            yield return new object[] {
                $@"[
					{{
						""id"": ""S1002"",
						""firstName"": ""Kannan"",
						""lastName"": ""Sudhakaran"",
						""email"": ""kannan.sudhakaran@tutorialpoint.org"",
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
                new ProspectiveStudent() {
                    email = "",
                    firstName = "",
                    lastName = "Sudhakaran",
                    collegeId = ""
                }
            };

            //CollegeId populated
            yield return new object[] {
                $@"[
					{{
						""id"": ""S1002"",
						""firstName"": ""Kannan"",
						""lastName"": ""Sudhakaran"",
						""email"": ""kannan.sudhakaran@tutorialpoint.org"",
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
					}},
					{{
						""id"": ""S1003"",
						""firstName"": ""Kiran"",
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
					}}
				]",
                new ProspectiveStudent() {
                    email = "",
                    firstName = "",
                    lastName = "",
                    collegeId = "col-101"
                }
            };

            //Fields for different records populated
            yield return new object[] {
                $@"[
					{{
						""id"": ""S1003"",
						""firstName"": ""Kiran"",
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
					}},
					{{
						""id"": ""S1001"",
						""firstName"": ""Mohtashim"",
						""lastName"": ""Mohammad"",
						""email"": ""mohtashim.mohammad@tutorialpoint.org"",
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
					}}
				]",
                new ProspectiveStudent() {
                    email = "kiran.panigrahi@tutorialpoint.org",
                    firstName = "",
                    lastName = "",
                    collegeId = "col-102"
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
