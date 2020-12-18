using System;
using System.Collections.Generic;
using Colors.WebApi.Controllers;
using Colors.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Colors.Tests
{
    public class ColorControllerTest
    {
        private ColorController _controller;

        public ColorControllerTest()
        {
            _controller = new ColorController();
        }

        [Fact]
        public void GetAllColorsTest()
        {
            var response = _controller.GetAllColors() as OkObjectResult;

            var colors = response.Value as List<Color>;

            Assert.NotNull(colors);
        }

        [Theory]
        [InlineData("red")]
        [InlineData("black")]
        public void GetColorTest(string color)
        {
            var response = _controller.GetByName(color) as OkObjectResult;

            var returnColor = response.Value as Color;

            Assert.NotNull(returnColor);
            Assert.Equal(color.ToUpper(), returnColor.Name.ToUpper());
        }
    }
}
