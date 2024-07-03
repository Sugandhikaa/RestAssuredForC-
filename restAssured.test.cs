﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using RegExApiTest.RestAssured;

namespace RestAssuredApiProject.ApiTest.Controllers{
public class RestAssuredApiTests 
{
    [Fact]
    //Test to Get list of all objects.
       public async void Get_RestAssured_Info()
    {
        RestAssuredApi api = new RestAssuredApi();
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
    [Fact]
    public async Task CallGetObjectById()
    {
        try
        {
            RestAssuredApi api = new RestAssuredApi();
            int objectId = 1;
            var fetchedObject = await api.GetObjectById(objectId);


        }
        catch (Exception ex)
        {
            // Handle exceptions from GetObjectById method
            Console.WriteLine($"Error fetching object: {ex.Message}");
        }
    }
    [Fact]
    public async Task CallUpdateObject()
    {
        try
        {
            RestAssuredApi api = new RestAssuredApi();
            int objectId = 1; // Replace with the actual ID of the object you want to update
            await api.UpdateObject(objectId);

            // Optionally, continue with other operations after updating the object
        }
        catch (Exception ex)
        {
            // Handle exceptions from UpdateObject method
            Console.WriteLine($"Error updating object: {ex.Message}");
        }
    }
    [Fact]
    public async Task CallDeleteObject()
{
    try
    {
         RestAssuredApi api = new RestAssuredApi();
        int objectId = 1; // Replace with the actual ID of the object you want to delete
        await api.DeleteObject(objectId);

        // Optionally, continue with other operations after deleting the object
    }
    catch (Exception ex)
    {
        // Handle exceptions from DeleteObject method
        Console.WriteLine($"Error deleting object: {ex.Message}");
    }
}

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

