using System;
using SpaceBattle;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Moq;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http;
using System.Net.Http.Json;

namespace SpaceBattle.Lib.Test
{
    public class EndpointTest
    {
        private readonly HttpClient client = new() {BaseAddress = new Uri("http://localhost:5000") };
        public EndpointTest()
        {
            Mock<ICommand> mockSendCommand = new();
            mockSendCommand.Setup(a => a.Execute());
            Mock<IStrategy> sendStrategy = new();
            sendStrategy.Setup(a => a.UseStrategy(It.IsAny<object[]>())).Returns(mockSendCommand.Object);
            IoC.Resolve<ICommand>("IoC.Add", "Game.SendCommand", sendStrategy.Object).Execute();

            Mock<ICommand> mockTestCommand = new();
            Mock<IStrategy> commandStrategy = new();
            commandStrategy.Setup(a => a.UseStrategy(It.IsAny<object[]>())).Returns(mockTestCommand.Object);
            IoC.Resolve<ICommand>("IoC.Add", "Game.TestCommand", commandStrategy.Object).Execute();

        }

        [Fact]
        public async Task Endpoint_PostMessage_OK()
        {
            /*var thread = new Thread(() => {
                Endpoint.Run();
            });*/
            Endpoint.Run();
            //throw new Exception();
            //Thread.Sleep(500);
            //await Endpoint.Run();
            var expectedStatusCode = System.Net.HttpStatusCode.OK;
            var message = new Message("TestCommand", 1, new[] { "par1", "par2" });
            JsonContent content = JsonContent.Create(message);
            var response = await client.PostAsync("/message", content);

            Assert.Equal(expectedStatusCode, response.StatusCode);
        }
    }
}
