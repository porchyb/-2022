using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;


namespace SpaceBattle.Lib
{
    public class Endpoint
    {
        static WebApplication? app;
        public static void Run()
        {
            WebApplicationBuilder webApplicationBuilder = WebApplication.CreateBuilder();
            app = webApplicationBuilder.Build();
            app.Map("/", async (context) =>
            {
                var response = context.Response;
                await response.WriteAsync("Void");
            });
            app.MapPost("/message", async (context) =>
            {
                var response = context.Response;
                var request = context.Request;
                Message? message;
                message = await request.ReadFromJsonAsync<Message>();
                if (!(message is null))
                {
                    try
                    {
                        int gameId = message.gameId;
                        object[] cmdParams = message.cmdParams;
                        try
                        {
                            ICommand cmd = IoC.Resolve<ICommand>("Game." + message.cmd, cmdParams);
                            IoC.Resolve<ICommand>("Game.SendCommand", gameId, cmd).Execute();
                        }
                        catch
                        {
                            throw new Exception("command deserealization error");
                        }
                    }
                    catch
                    {
                        throw new Exception("Incorrect view of JSON");
                    }
                    


                }
                else
                {
                    Console.WriteLine("wrong");
                    await response.WriteAsync("wrong");
                }
            });
            app.Run();
        }
        public record Message(string cmd, int gameId, object[] cmdParams);
    }
}
