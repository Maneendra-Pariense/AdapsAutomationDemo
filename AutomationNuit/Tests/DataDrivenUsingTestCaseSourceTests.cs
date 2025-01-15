﻿using AutomationNunit.DataTypes;
using Newtonsoft.Json;
using RestSharp;

namespace AutomationNunit.Tests
{
    //[TestFixture]
    public class DataDrivenUsingTestCaseSourceTests
    {
        private const string BASE_URL = "http://api.zippopotam.us";

        //[Test, TestCaseSource("LocationTestData")]
        public void RetrieveDataFor_ShouldYield
            (string countryCode, string zipCode, string expectedPlaceName)
        {
            // arrange
            RestClient client = new RestClient(BASE_URL);
            RestRequest request =
                new RestRequest($"{countryCode}/{zipCode}", Method.Get);

            // act
            RestResponse response = client.Execute(request);

            LocationResponse locationResponse =
                 JsonConvert.DeserializeObject<LocationResponse>(response.Content);

            // assert
            Assert.That(
                locationResponse?.Places[0].PlaceName,
                Is.EqualTo(expectedPlaceName)
            );
        }

        private static IEnumerable<TestCaseData> LocationTestData()
        {
            yield return new TestCaseData("us", "90210", "Beverly Hills").
                SetName("Check that US zipcode 90210 yields Beverly Hills");
            yield return new TestCaseData("us", "12345", "Schenectady").
                SetName("Check that US zipcode 12345 yields Schenectady");
            yield return new TestCaseData("ca", "Y1A", "Whitehorse").
                SetName("Check that CA zipcode Y1A yields Whitehorse");
        }

    }
}
