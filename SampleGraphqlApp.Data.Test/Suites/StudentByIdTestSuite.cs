using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleGraphqlApp.Data.Test.Suites
{
    public class StudentByIdTestSuite : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
			//Existent id
			yield return new object[] {
				$@"{{
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
				}}",
				"S1002"
			};

			//Non-existent id
			yield return new object[] {
                $@"null",
                ""
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
