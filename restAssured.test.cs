﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using RegExApiTest.RestAssured;

namespace RestAssuredApiProject.ApiTest.Controllers
{
    public class RestAssuredApiTests
    {

        [Fact]
        //Test to Get list of all objects.
        public async void Get_RestAssured_Info()
        {
            //create instance of api
            RestAssuredApi api = new RestAssuredApi();
            var response = await api.GetApiList();
            Assert.NotNull(response);
            Assert.NotEmpty(response);

            // Iterate through each product and verify its properties
            foreach (var ObjectId in response)
            {
                switch (ObjectId.Id)
                {
                    case "1":
                        var product = response[0];
                        Assert.Equal("Google Pixel 6 Pro", product.Name);
                        Assert.Equal("Cloudy White", product.Data.Color);
                        Assert.Equal("128 GB", product.Data.Capacity);
                        break;
                    case "2":
                        var product1 = response[1];
                        Assert.Equal("Apple iPhone 12 Mini, 256GB, Blue", product1.Name);
                        Assert.Null(product1.Data); // Data is expected to be null
                        break;
                    case "3":
                        var item_3 = response[2];
                        Assert.Equal("Apple iPhone 12 Pro Max", item_3.Name);
                        Assert.Equal("Cloudy White", item_3.Data.Color);
                        break;
                    case "4":
                        var item_4 = response[3];
                        Assert.Equal("Apple iPhone 11, 64GB", item_4.Name);
                        Assert.Equal(389.99, item_4.Data.Price);
                        Assert.Equal("Purple", item_4.Data.Color);
                        break;
                    case "5":
                        var item_5 = response[4];
                        Assert.Equal("Samsung Galaxy Z Fold2", item_5.Name);
                        Assert.Equal(689.99, item_5.Data.Price);
                        Assert.Equal("Brown", item_5.Data.Color);
                        break;
                    case "6":
                        var item_6 = response[5];
                        Assert.Equal("Apple AirPods", item_6.Name);
                        Assert.Equal("3rd", item_6.Data.Generation);
                        Assert.Equal(120, item_6.Data.Price);
                        break;
                    case "7":
                        var item_7 = response[6];
                        Assert.Equal("Apple MacBook Pro 16", item_7.Name);
                        Assert.Equal(2019, item_7.Data.Year);
                        Assert.Equal(1849.99, item_7.Data.Price);
                        Assert.Equal("1 TB", item_7.Data.HardDiskSize);
                        break;
                    case "8":
                        var item_8 = response[7];
                        Assert.Equal("Apple Watch Series 8", item_8.Name);
                        Assert.Equal("41mm", item_8.Data.CaseSize);
                        break;
                    case "9":
                        var item_9 = response[8];
                        Assert.Equal("Beats Studio3 Wireless", item_9.Name);
                        Assert.Equal("High-performance wireless noise cancelling headphones", item_9.Data.Description);
                        break;
                    case "10":
                        var item_10 = response[9];
                        Assert.Equal("Apple iPad Mini 5th Gen", item_10.Name);
                        Assert.Equal(7.9, item_10.Data.ScreenSize);
                        break;
                    case "11":
                        var item_11 = response[10];
                        Assert.Equal("Apple iPad Mini 5th Gen", item_11.Name);
                        Assert.Equal(7.9, item_11.Data.ScreenSize);
                        break;
                    case "12":
                        var item_12 = response[11];
                        Assert.Equal("Apple iPad Air", item_12.Name);
                        break;
                    case "13":
                        var item_13 = response[12];
                        Assert.Equal("Apple iPad Air", item_13.Name);
                        break;
                    default:
                        Assert.Fail($"Unexpected product ID");
                        break;
                }
            }

        }
        [Fact]
        public async Task AddObjectPost()
        {
            RestAssuredApi api = new RestAssuredApi();
            string ObjectId=await api.CreateAnObject();
            await Task.Delay(2000); // Example: Wait for 2 seconds (adjust as needed)

        // Retrieve the object by its ID
        var createdObject = await api.verifyCreatedObject(ObjectId);
            Assert.Equal("Apple MacBook Pro 16", (string)createdObject.name);
            Assert.Equal("Apple MacBook Pro 16", (string)createdObject.name);
            Assert.Equal(2019, (int)createdObject.data.year);
            Assert.Equal(1849.99, (double)createdObject.data.price);
            Assert.Equal("Intel Core i9", (string)createdObject.data["CPUmodel"]);
            Assert.Equal("1 TB", (string)createdObject.data["HardDiskSize"]);
        }
        //catch
        //{
        //return null;
        //}

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

