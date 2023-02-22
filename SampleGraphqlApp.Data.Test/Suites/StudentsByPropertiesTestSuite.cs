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
            //Non fields populated
            yield return new object[] {
                $@"[]",
                "",
                "",
                "",
                ""
            };

            //Existent id
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
							""rating"": 5,
							""books"": 
							[
								{{
									""id"": ""bok-103"",
									""name"": ""The Last Flair Bender"",
									""author"": ""Manny Abuduo""
								}},
								{{
									""id"": ""bok-105"",
									""name"": ""On the wild side"",
									""author"": ""Harriett Osbyorne""
								}}
							]
						}}
					}}
				]",
                "kiran.panigrahi@tutorialpoint.org",
                "",
                "",
                ""
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
