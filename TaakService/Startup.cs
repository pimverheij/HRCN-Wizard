using AutoMapper;
using HRControlnet.Core.Eventbus.RabbitMQ.Extensions;
using HRControlNet.Core.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TaakService.MessageHandlers;
using TaakService.MessageHandlers.CommandHandlers;
using TaakService.MessageHandlers.EventHandlers;
using TaakService.MessageHandlers.QueryHandlers;
using TaakService.Messages.Commands;
using TaakService.Messages.Queries;
using TaakService.Models;
using TaakService.Services;

namespace TaakService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string corsPolicyName = "my_policy";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Taakservice API", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(corsPolicyName,
                builder =>
                {
                    builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });
            });

            services.AddScoped<IMessageExecutor, MessageExecutor>();
            services.AddScoped<ICommandHandler<MaakTaakAanCommand>, MaakTaakAanCommandHandler>();

            services.AddScoped<IQueryHandler<ReadTaakQuery, TaakModel>, ReadTaakQueryHandler>();

            services.AddScoped<ITaakDataRepository, InMemoryTaakDataRepository>();
            services.AddScoped<ITaakService, Services.TaakService>();
            services.AddScoped<ITaakRepository, InMemoryTaakRepository>();
            services.AddScoped<IReintegratieRepository, InMemoryReintegratieRepository>();

            services.AddScoped<ExecuteTaakService<ReintegratieTestTaakModel>, ReintegratieTestTaakService>();

            services.AddScoped<ReintegratieAangemaaktEventHandler>();
            services.AddRabbitMQServiceBus(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(corsPolicyName);

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Taakservice API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.ConfigureServiceBus();
        }
    }
}
