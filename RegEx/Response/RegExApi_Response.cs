using Newtonsoft.Json;
namespace RegExApiTest.RegEx.Response
{
public class ProductData
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

public class Product
{
    [JsonProperty("id")]
    public required string Id { get; set; }

    [JsonProperty("name")]
    public required string Name { get; set; }

    [JsonProperty("data")]
    public required ProductData Data { get; set; }
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

