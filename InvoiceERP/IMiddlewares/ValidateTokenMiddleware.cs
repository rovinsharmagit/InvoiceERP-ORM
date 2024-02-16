using InvoiceERP.IRepositories;
using InvoiceERP.Services;

namespace InvoiceERP.IMiddlewares
{
    public class ValidateTokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IJwtService _jwtService;

        public ValidateTokenMiddleware(RequestDelegate next, IJwtService jwtService)
        {
            _next = next;
            _jwtService = jwtService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Session.GetString("Token");

            // Allow login, logout, and the initial login request to pass through without checking the token
            if (context.Request.Path.Value == "/Auth/Login" || context.Request.Path.Value == "/Auth/Logout" || context.Request.Method == "POST" && context.Request.Path.Value == "/Login")
            {
                await _next(context);
                return;
            }

            if (string.IsNullOrEmpty(token) || _jwtService.GetTokenExpirationTime(token) < DateTime.UtcNow)
            {
                context.Session.Clear();
                context.Response.Redirect("/Auth/Login");
                return;
            }

            await _next(context);
        }

    }

}
