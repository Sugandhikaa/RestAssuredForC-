﻿using Newtonsoft.Json;
using RestSharp;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;
using RegExApiTest.RegEx;
using Xunit;
namespace RegExApiTest;

public class UnitTest1
{
    [Fact]
    public async void Get_RegEx_Info()
    {
        RegExApi api = new RegExApi();
        var response = await api.GetApiList();
        Assert.NotNull(response);
        Assert.NotEmpty(response);

        var product = response[0];
        Assert.Equal("Google Pixel 6 Pro", product.Name); // Check the Name property of the product
        Assert.Equal("Cloudy White", product.Data.Color);
        Console.WriteLine(product.Name);

    }
    [Fact]
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
                      HttpClient restClient = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, "objects");
                request.Content = new StringContent(responseModel);
                var responceback = await restClient.SendAsync(request);
                
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

