using Newtonsoft.Json;
namespace RegExApiTest.RegEx.Response
{
    public class GetListData
    {
        [JsonProperty("color")]
        public required string Color { get; set; }

        [JsonProperty("capacity")]
        public required string Capacity { get; set; }

        [JsonProperty("capacity GB")]
        public int? CapacityGB { get; set; }

        [JsonProperty("price")]
        public double? Price { get; set; }

        [JsonProperty("generation")]
        public required string Generation { get; set; }

        [JsonProperty("year")]
        public int? Year { get; set; }

        [JsonProperty("CPU model")]
        public required string CpuModel { get; set; }

        [JsonProperty("Hard disk size")]
        public required string HardDiskSize { get; set; }

        [JsonProperty("Strap Colour")]
        public required string StrapColour { get; set; }

        [JsonProperty("Case Size")]
        public required string CaseSize { get; set; }

        [JsonProperty("Color")]
        public required string JsonColor { get; set; }

        [JsonProperty("Description")]
        public required string Description { get; set; }

        [JsonProperty("Capacity")]
        public required string JsonCapacity { get; set; }

        [JsonProperty("Screen size")]
        public double? ScreenSize { get; set; }

        [JsonProperty("Generation")]
        public required string JsonGeneration { get; set; }

        [JsonProperty("Price")]
        public required string JsonPrice { get; set; }
    }

    public class GetListMain
    {
        [JsonProperty("id")]
        public required string Id { get; set; }

        [JsonProperty("name")]
        public required string Name { get; set; }

        [JsonProperty("data")]
        public required GetListData Data { get; set; }
    }


    public class AddItemProperties
    {
        public int year { get; set; }
        public double price { get; set; }

        [JsonProperty("CPU model")]
        public required string CPUmodel { get; set; }

        [JsonProperty("Hard disk size")]
        public required string Harddisksize { get; set; }
    }
    public class AddObjects
    {
        public required string id { get; set; }
        public required string name { get; set; }
        public required AddItemProperties data { get; set; }
        public DateTime createdAt { get; set; }
    }
    public class GetObjectbyIdProperty
    {
        public int year { get; set; }
        public double price { get; set; }

        [JsonProperty("CPU model")]
        public required string CPUmodel { get; set; }

        [JsonProperty("Hard disk size")]
        public required string Harddisksize { get; set; }
    }

    public class GetObjectbyId
    {
        public required string id { get; set; }
        public required string name { get; set; }
        public required GetObjectbyIdProperty data { get; set; }
    }
    public class UpdateByPutPropertiy
    {
        public int year { get; set; }
        public double price { get; set; }

        [JsonProperty("CPU model")]
        public required string CPUmodel { get; set; }

        [JsonProperty("Hard disk size")]
        public required string Harddisksize { get; set; }
        public required string color { get; set; }
    }

    public class UpdateByPut
    {
        public required string id { get; set; }
        public required string name { get; set; }
        public required UpdateByPutPropertiy data { get; set; }
        public DateTime updatedAt { get; set; }
    }


    /*  public class ApiResponse
     {
         public List<Product> Products { get; set; }

         public ApiResponse()
         {
             Products = new List<Product>();
         }
     } */
}