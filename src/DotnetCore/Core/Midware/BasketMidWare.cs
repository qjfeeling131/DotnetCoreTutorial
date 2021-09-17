using IdentityModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DotnetCoreTutorial.Core.Midware
{
    public class BasketMidWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public BasketMidWare(RequestDelegate next,
           ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<BasketMidWare>();
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Do something with context near the beginning of request processing.

            _logger.LogInformation("The basket middle ware is running");
            Claim claim = new Claim("Read", "True");
            var claimIdentity = Identity.Create("Basket Cookie", claim);
            context.User.AddIdentity(claimIdentity);
            //await context.Response.WriteAsync("End basket middleWare");
            context.Response.Redirect("https://wwww.baidu.com");
            //await _next.Invoke(context);
        }


    }

    public static class BasketMiddlewareExtensions
    {
        public static IApplicationBuilder UseBasketMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BasketMidWare>();
        }
    }
}
