﻿using System.Runtime.CompilerServices;
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

    }}
   // [Fact]
     
