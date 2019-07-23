using System;
using System.Net.Http;
using Xunit;
using Moq;
using webapi_sample.Controllers;
using System.Threading.Tasks;
using System.Threading;

namespace webapi_sample_unittests
{
    public class CorreiosControllerUnitTests
    {
        [Fact]
        public async Task DeveriaChamarOSendAsyncPeloMenosUmaVez()
        {
            var client = new Mock<HttpClient>();
            
            client.Setup(x => x.SendAsync(It.IsAny<HttpRequestMessage>(), CancellationToken.None))
            .ReturnsAsync(
                new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Content = new StringContent("{}")
                }
            )
            .Verifiable();
            
            var classToTest = new CorreiosController(client.Object);
            var response = await classToTest.Get();

            client.Verify(x => x.SendAsync(It.IsAny<HttpRequestMessage>(),  CancellationToken.None), Times.AtLeastOnce);
        }
    }
}
