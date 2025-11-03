using LinkDev.IKEA.DAL.Constract;

namespace LinkDev.IKEA.PL.Extensions
{
    public static class InitializerExtensions
    {

        public static IApplicationBuilder UseDbInitializer(this IApplicationBuilder app)
        {

            using var scope = app.ApplicationServices.CreateScope();
            var services= scope.ServiceProvider;
            var dbInitializer = services.GetRequiredService<IDbIntializer>();
            dbInitializer.Initialize();
            dbInitializer.seed();
            return app;
        }
    }
}
