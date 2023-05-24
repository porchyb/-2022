using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

using Microsoft.AspNetCore.Mvc;

namespace SpaceBattle.Lib
{
    public class Endpoint
    {
        static WebApplication? app;
        public static void Run()
        {
            /*var builder = WebApplication.CreateBuilder();
            var app = builder.Build();
            app.UseHttpsRedirection();*/

            WebApplicationBuilder webApplicationBuilder = WebApplication.CreateBuilder();
            app = webApplicationBuilder.Build();
            app.UseHttpsRedirection();
            app.MapPost("/message", (Message message) =>
            {
                //var response = context.Response;
                //var request = context.Request;
                //Message? message;
                //message = await request.ReadFromJsonAsync<Message>();
                try
                {
                    ICommand cmd = IoC.Resolve<ICommand>("Game." + message.cmd, message.cmdParams);
                    IoC.Resolve<ICommand>("Game.SendCommand", message.gameId, cmd).Execute();
                }
                catch
                {
                    throw new Exception("command deserealization error");
                }
                return Results.Ok(message);
            });
            app.MapGet("/", () =>
            {
                //var response = context.Response;
                //await response.WriteAsync("Void");
                return Results.Ok();
            });
            app.Run();
        }
    }
    public record Message(string cmd, int gameId, object[] cmdParams);
}
