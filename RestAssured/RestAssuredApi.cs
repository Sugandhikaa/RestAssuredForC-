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

          
            int objectId = createdObject.id; 
            return objectId;
        }
        public async Task<dynamic> verifyCreatedObject(int objectId)
        {
            UriBuilder builder = new UriBuilder(URI); 
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
                UriBuilder builder = new UriBuilder(URI); 
                builder.Path += $"/{objectId}"; // Append objectId to the path

                var request = new HttpRequestMessage(HttpMethod.Get, builder.Uri);

                var response = await restClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<dynamic>(responseContent);


                return responseObject;

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP Request Exception: {ex.Message}");
                throw; // Re-throw the exception or handle it as per your application's error handling strategy
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"JSON Deserialization Exception: {ex.Message}");
                throw; // Re-throw the exception or handle it as per your application's error handling strategy
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                throw; // Handle any other exceptions or log errors
            }

            // Ensure all paths return a value or throw an exception
            throw new InvalidOperationException("Unexpected control flow reached end of method without returning a value.");
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
                UriBuilder builder = new UriBuilder(URI);
                builder.Path += $"/{objectId}";
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
        public async Task<dynamic> verifyUpdatedObject(int objectId)
        {
            UriBuilder builder = new UriBuilder(URI);
            builder.Path += $"/{objectId}";
            var Response = await restClient.GetAsync(builder.Uri);
            var context = await Response.Content.ReadAsStringAsync();


            var verifyUpdatedObject = JsonConvert.DeserializeObject<dynamic>(context);
            return verifyUpdatedObject;
        }
        public async Task DeleteObject(int objectId)
        {
            try
            {
                UriBuilder builder = new UriBuilder(URI);
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
