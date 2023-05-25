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
        public static async Task Run()
        {
            /*var builder = WebApplication.CreateBuilder();
            var app = builder.Build();
            app.UseHttpsRedirection();*/

            WebApplicationBuilder webApplicationBuilder = WebApplication.CreateBuilder();
            app = webApplicationBuilder.Build();
            app.UseHttpsRedirection();
            app.Map("/message", (Message message) =>
            {
                //var response = context.Response;
                //var request = context.Request;
                //Message? message;
                //message = await request.ReadFromJsonAsync<Message>();
                try
                {
                    //ICommand cmd = IoC.Resolve<ICommand>("Game." + message.cmd, message.cmdParams);
                    //IoC.Resolve<ICommand>("Game.SendCommand", message.gameId, cmd).Execute();
                    return Results.Ok(message);
                }
                catch
                {
                    return Results.BadRequest();
                }
                
            });
            app.MapGet("/", () =>
            {
                //var response = context.Response;
                //await response.WriteAsync("Void");
                return Results.Ok();
            });
            await app.RunAsync();
        }
        public static async Task Stop()
        {
            app.StopAsync();
        }
    }
    public record Message(string cmd, int gameId, object[] cmdParams);
}
