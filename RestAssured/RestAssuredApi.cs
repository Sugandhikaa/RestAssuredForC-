using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using RegExApiTest.RestAssured.Response;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using RestSharp;

namespace RegExApiTest.RestAssured
{
    public class RestAssuredApi
    {
        private HttpClient restClient = new HttpClient();
        private string URI = "https://api.restful-api.dev/objects";
        //private string RegEx = "";

        public async Task<List<GetListMain>> GetApiList()
        {
            UriBuilder builder = new UriBuilder($"{URI}");
            var Response = await restClient.GetAsync(builder.Uri);
            var context = await Response.Content.ReadAsStringAsync();
            //   try
            // {
            var responseModel = JsonConvert.DeserializeObject<List<GetListMain>>(context);
            return responseModel;
            //}
            //catch
            // {
            //   return null;
            //}
        }
        //add object funtions

        public async Task<int> CreateAnObject()
        {
            var newObject = new
            {
                name = "Apple MacBook Pro 16",
                data = new
                {
                    year = 2019,
                    price = 849.99,
                    CPUmodel = "Intel Core 19",
                    HardDiskSize = "1 TB"
                }
            };
            UriBuilder builder = new UriBuilder($"{URI}");
            var responseModel = JsonConvert.SerializeObject(newObject);
            var request = new HttpRequestMessage(HttpMethod.Post, builder.Uri);
            request.Content = new StringContent(responseModel, Encoding.UTF8, "application/json");
            var responceback = await restClient.SendAsync(request);
            responceback.EnsureSuccessStatusCode();

            var responseContent = await responceback.Content.ReadAsStringAsync();
            var createdObject = JsonConvert.DeserializeObject<dynamic>(responseContent);

            // Extract and return the ID of the created object
            int objectId = createdObject.id; // Adjust this based on your actual response structure
            return objectId;
        }
        public async Task<dynamic> verifyCreatedObject(int objectId)
        {
            UriBuilder builder = new UriBuilder(URI); // Replace URI with your actual base URI
            builder.Path += $"/{objectId}";
            var Response = await restClient.GetAsync(builder.Uri);
            var context = await Response.Content.ReadAsStringAsync();


            //var responceContent = await responceback.Content.ReadAsStringAsync();
            var createdObject = JsonConvert.DeserializeObject<dynamic>(context);
            return createdObject;

        }

        public async Task<object> GetObjectById(int objectId)
        {
            try
            {
                UriBuilder builder = new UriBuilder(URI); // Assuming URI is a string holding your base URI
                builder.Path += $"/{objectId}"; // Append objectId to the path

                var request = new HttpRequestMessage(HttpMethod.Get, builder.Uri);

                var response = await restClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<dynamic>(responseContent);

                // Example: Assuming the API returns an object with properties 'name' and 'data'
                var objectName = (string)responseObject.name;
                var objectYear = (int)responseObject.data.year;
                var objectPrice = (double)responseObject.data.price;
                var objectCPUModel = (string)responseObject.data.CPUmodel;
                var objectHardDiskSize = (string)responseObject.data.HardDiskSize;

                Console.WriteLine($"Object details:");
                Console.WriteLine($"Name: {objectName}");
                Console.WriteLine($"Year: {objectYear}");
                Console.WriteLine($"Price: {objectPrice}");
                Console.WriteLine($"CPU Model: {objectCPUModel}");

                return responseObject; // Return the deserialized object if needed


            }
            catch (Exception ex)
            {
                // Handle any exceptions or log errors
                //  throw new ApplicationException($"Error fetching object with ID {objectId}.", ex);
            }
        }
        public async Task UpdateObject(int objectId)
        {
            var updatedObject = new
            {
                name = "Updated MacBook Pro 16",
                data = new
                {
                    year = 2021,
                    price = 1999.99,
                    CPUmodel = "Intel Core i9",
                    HardDiskSize = "2 TB"
                }
            };

            try
            {
                UriBuilder builder = new UriBuilder(URI); // Replace URI with your actual base URI
                builder.Path += $"/{objectId}";
                // var Response = await restClient.GetAsync(builder.Uri);
                var request = new HttpRequestMessage(HttpMethod.Put, builder.Uri);

                // Serialize the updated object to JSON
                var json = JsonConvert.SerializeObject(updatedObject);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await restClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var updatedResponse = JsonConvert.DeserializeObject<dynamic>(responseContent);

                // Example: Verify the updated object properties
                Assert.Equal("Updated MacBook Pro 16", (string)updatedResponse.name);
                Assert.Equal(2021, (int)updatedResponse.data.year);
                Assert.Equal(1999.99, (double)updatedResponse.data.price);
                Assert.Equal("Intel Core i9", (string)updatedResponse.data.CPUmodel);
                Assert.Equal("2 TB", (string)updatedResponse.data.HardDiskSize);
            }
            catch (Exception ex)
            {
                // Handle any exceptions or log errors
                throw new ApplicationException($"Error updating object with ID {objectId}.", ex);
            }


        }
        public async Task DeleteObject(int objectId)
        {
            try
            {
                UriBuilder builder = new UriBuilder(URI); // Replace URI with your actual base URI
                builder.Path += $"/{objectId}";
                // var Response = await restClient.GetAsync(builder.Uri);
                var request = new HttpRequestMessage(HttpMethod.Delete, builder.Uri);

                var response = await restClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                // Optionally, handle response content if needed
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Object with ID {objectId} deleted successfully.");
            }
            catch (Exception ex)
            {
                // Handle any exceptions or log errors
                throw new ApplicationException($"Error deleting object with ID {objectId}.", ex);
            }
        }

    }


}
