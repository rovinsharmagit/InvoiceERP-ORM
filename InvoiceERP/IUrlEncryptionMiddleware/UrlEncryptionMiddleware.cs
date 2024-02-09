using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using InvoiceERP.IEncryptionService;

namespace InvoiceERP.IUrlEncryptionMiddleware
{
    public class UrlEncryptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly EncryptUri _encryptUri;

        public UrlEncryptionMiddleware(RequestDelegate next, EncryptUri encryptUri)
        {
            _next = next;
            _encryptUri = encryptUri;
        }

        public async Task Invoke(HttpContext context)
        {
            var originalPath = context.Request.Path;

            // Encrypt the path
            var encryptedPath = _encryptUri.Encrypt(originalPath);

            // Ensure that the encrypted path starts with a '/'
            if (!encryptedPath.StartsWith("/"))
            {
                encryptedPath = "/" + encryptedPath;
            }

            // Set the encrypted path as the new path
            context.Request.Path = encryptedPath;

            // Call the next middleware in the pipeline
            await _next(context);

            // Reset the path to the original path after the response is processed
            context.Request.Path = originalPath;
        }
    }
}
