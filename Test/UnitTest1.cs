using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Build.Utilities;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine(ToolLocationHelper.GetPathToBuildToolsFile("msbuild.exe", "12.0", DotNetFrameworkArchitecture.Bitness64));
        }
    }
}
