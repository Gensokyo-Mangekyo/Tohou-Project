using System;
using Xunit;
using Tohou_Project.Extensions;
using Tohou_Project.Models;
using System.Collections.Generic;
using System.Linq;

namespace XUnitTestTohouProject
{
    public class TestChapters
    {
        [Fact]
        public void TestSplitPath()
        {
            var arr = new string[] { @"F:\C#\Tohou Project\Tohou Project\wwwroot\DreamVision\Chapter 1\Page 0",
            @"F:\C#\Tohou Project\Tohou Project\wwwroot\DreamVision\Chapter 10\Page 1",@"F:\C#\Tohou Project\Tohou Project\wwwroot\DreamVision\Chapter 11\Page 2"};
            string[] str = arr[0].Split('\\');
            Assert.Equal(8, str.Length);
            Assert.Equal("Chapter 1", str[str.Length-2]);
        }

    }
}
