using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InvoiceERP.IFilters
{
    public class MyAuthorizationFilter : IAuthorizationFilter
    {
        private readonly string[] _whitelistedPaths = { "/", "/Auth/Login" };

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Get the requested path
            var requestedPath = context.HttpContext.Request.Path;

            // Check if the requested path is whitelisted
            if (_whitelistedPaths.Contains(requestedPath.Value))
            {
                // Allow access to whitelisted paths without any restrictions
                return;
            }

            // Check if the request has a valid referer indicating it was initiated from a link or button
            var referer = context.HttpContext.Request.Headers["Referer"].ToString();
            if (string.IsNullOrEmpty(referer) || (!referer.StartsWith("https://localhost:7130") && !referer.StartsWith("http://localhost:5280")))
            {
                // If the request is not from a button or link on your website, return a 404 Not Found response
                context.Result = new NotFoundResult();
            }
        }
    }
}
