namespace Web.Configurations;

public static class MiddlewareConfig
{
    public static IApplicationBuilder UseAppMiddleware(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseHsts();
        }

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("./swagger/v1/swagger.json", "DailyValute API v1");
            c.RoutePrefix = string.Empty;
        });


        app.MapControllers();
        return app;
    }
}
