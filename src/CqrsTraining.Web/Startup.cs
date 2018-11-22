using System.Reflection;

using CqrsTraining.Application.Media.Queries.GetAllMedia;
using CqrsTraining.Persistence.EntityFramework.Concrete;
using CqrsTraining.Persistence.EntityFramework.Context;
using CqrsTraining.Persistence.Repositories;
using CqrsTraining.Web.Infrastructure.Filters;
using CqrsTraining.Web.Infrastructure.Swagger;

using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Swashbuckle.AspNetCore.Swagger;

namespace CqrsTraining.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CqrsTrainingContext>(options => options.UseSqlServer("Data Source=.;Initial Catalog=CqrsTraining;Integrated Security=True;Connect Timeout=30;Encrypt=False;"));
            services.AddTransient<IMediaRepository, MediaRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddScoped<ICqrsTrainingContext, CqrsTrainingContext>();
            services.AddMediatR(typeof(GetAllMediaQueryHandler).GetTypeInfo().Assembly);

            services.AddMvcCore()
                .AddVersionedApiExplorer(o => o.GroupNameFormat = "'v'VVV");

            services
                .AddMvc(options =>
                {
                    options.Filters.Add(new NotFoundExceptionFilterAttribute());
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = ApiVersion.Default;
            });

            services.AddSwaggerGen(options =>
            {
                var provider = services.BuildServiceProvider()
                    .GetRequiredService<IApiVersionDescriptionProvider>();

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(
                        description.GroupName,
                        new Info
                        {
                            Title = $"CQRS Training API {description.ApiVersion}",
                            Version = description.ApiVersion.ToString()
                        });
                }

                options.OperationFilter<SwaggerDefaultValues>();
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseSwagger(options =>
            {
                //options.PreSerializeFilters.Add((document, request) =>
                //{
                //    document.Paths = document.Paths.ToDictionary(p => p.Key.ToLowerInvariant(), p => p.Value);
                //});
            });

            app.UseSwaggerUI(options =>
            {
                options.RoutePrefix = string.Empty;

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint(
                        $"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToLowerInvariant());
                }

            });

            app.UseMvc();
        }
    }
}
