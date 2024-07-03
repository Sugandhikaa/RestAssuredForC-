using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using RegExApiTest.RegEx.Response;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using RestSharp;

namespace RegExApiTest.RegEx
{
    public class RegExApi
    {
        private HttpClient restClient = new HttpClient();
        private string URI = "https://api.restful-api.dev/objects";
        //private string RegEx = "";

        public async Task<List<GetListMain>> GetApiList()
        {
            UriBuilder builder = new UriBuilder($"{URI}");
            var Response = await restClient.GetAsync(builder.Uri);
            var context = await Response.Content.ReadAsStringAsync();
            try
            {
                var responseModel = JsonConvert.DeserializeObject<List<GetListMain>>(context);
                return responseModel;
            }
            catch
            {
                return null;
            }
        }
        //add object funtions

        public async Task AddObjectPost()
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
            try
            {
                var responseModel = JsonConvert.SerializeObject(newObject);
                //var client = new RestClient("https://api.restful-api.dev/objects");
                //var request1 = new RestRequest(Method.Post);
                var request = new HttpRequestMessage(HttpMethod.Post, "objects");
                request.Content = new StringContent(responseModel, Encoding.UTF8, "application/json");
                var responceback = await restClient.SendAsync(request);
                //var request=new RestRequest("",Method.Post);
                //request.AddHeader("Content-Type","application/json");
                //request.AddJsonBody(responseModel);
                //var restClient1 =new RestRequest("",)
                // var request=new RestRequest(MethodAccessException.); //return responseModel;
                responceback.EnsureSuccessStatusCode();

                var responceContent = await responceback.Content.ReadAsStringAsync();
                var createdObject = JsonConvert.DeserializeObject<dynamic>(responceContent);
                Assert.Equal("Apple MacBook Pro 16", (string)createdObject.name);
                Assert.Equal("Apple MacBook Pro 16", (string)createdObject.name);
                Assert.Equal(2019, (int)createdObject.data.year);
                Assert.Equal(1849.99, (double)createdObject.data.price);
                Assert.Equal("Intel Core i9", (string)createdObject.data["CPUmodel"]);
                Assert.Equal("1 TB", (string)createdObject.data["HardDiskSize"]);
            }
            catch
            {
                //return null;
            }

        }
    }

    internal class RestRequest
    {
        private object pOST;

        public RestRequest(Method post)
        {
            pOST = post;
        }

        public RestRequest(object pOST, object methodAccessExcept)
        {
            this.pOST = pOST;
        }
    }
}