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

        public async Task<List<Product>> GetApiList()
        {
            UriBuilder builder = new UriBuilder($"{URI}");
            var Response =await restClient.GetAsync(builder.Uri);
            var context=await Response.Content.ReadAsStringAsync();
            try{
                var responseModel=JsonConvert.DeserializeObject<List<Product>>(context);
                return responseModel;
            }
            catch{
                return null;
            }
        }
    }
}