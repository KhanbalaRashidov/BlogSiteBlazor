using Microsoft.Extensions.FileProviders;

namespace BlogSite.Server.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BlogSite.Server v1"));

            return app;
        }
        public static IApplicationBuilder UseCustomFiles(this IApplicationBuilder app)
        {
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot")),
                RequestPath = new PathString("/wwwroot")
            });

            return app;
        }
    }
}
