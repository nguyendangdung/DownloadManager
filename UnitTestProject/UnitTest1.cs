using System;
using System.Net.Configuration;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var client = new HttpClient())
            {
                var response =
                    client.GetAsync(
                        "https://dl.dropboxusercontent.com/content_link/163ZlSqbaUGnGEmuCW0Uv6u3FxMhgCMVpSw4USeLiols2WxgDTuiX8BxWKM7Um9J/file?dl=1",
                        HttpCompletionOption.ResponseHeadersRead).Result;

                Assert.AreEqual(1, 1);
            }
        }
    }
}
