using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using RegExApiTest.RegEx.Response;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

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
                
                var request=new RestRequest(MethodAccessException.T); //return responseModel;
            }
            catch
            {
                return null;
            }

        }
    }

    internal class RestRequest
    {
        private object pOST;

        public RestRequest(object pOST)
        {
            this.pOST = pOST;
        }
    }
}