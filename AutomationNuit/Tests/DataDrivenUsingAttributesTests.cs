using AutomationNunit.DataTypes;
using Newtonsoft.Json;
using RestSharp;

namespace AutomationNunit.Tests
{
    //[TestFixture]
    public class DataDrivenUsingAttributesTests
    {
        private const string BASE_URL = "http://api.zippopotam.us";

        //[TestCase("us", "90210", "Beverly Hills", TestName = "Check that US zipcode 90210 yields Beverly Hills")]
        //[TestCase("us", "12345", "Schenectady", TestName = "Check that US zipcode 12345 yields Schenectady")]
        //[TestCase("ca", "Y1A", "Whitehorse", TestName = "Check that CA zipcode Y1A yields Whitehorse")]
        //[Test]
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
    }
}
