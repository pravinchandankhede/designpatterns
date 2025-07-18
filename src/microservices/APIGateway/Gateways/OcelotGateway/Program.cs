namespace OcelotGateway;

using Ocelot.DependencyInjection;
using Ocelot.Middleware;

public class Program
{
    public static void Main(String[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Add Ocelot configuration
        builder.Configuration
            .AddOcelot("ocelot.json", optional: false, reloadOnChange: true)
            ;
        builder.Services.AddOcelot(builder.Configuration);

        // Add Swagger for Ocelot
        //builder.Services.AddSwaggerForOcelot(builder.Configuration);

        WebApplication app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapControllers();

        // Use Ocelot middleware
        app.UseOcelot().Wait();

        app.Run();
    }
}
