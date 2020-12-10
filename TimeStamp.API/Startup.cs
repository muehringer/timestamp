using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TimeStamp.Application.ObjectMappers;
using TimeStamp.Infrastructure.Configurations;
using TimeStamp.IoC;

namespace TimeStamp.API
{
    public class Startup
    {
        public IConfigurationRoot configurationRoot { get; }

        public Startup(IHostingEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            
            configurationRoot = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c => {
                c.SwaggerDoc(configurationRoot["SwaggerVersion"].ToString(),
                    new OpenApiInfo
                    {
                        Title = configurationRoot["SwaggerTitle"].ToString(),
                        Version = configurationRoot["SwaggerVersion"].ToString(),
                        Description = configurationRoot["SwaggerDescription"].ToString(),
                        Contact = new OpenApiContact
                        {
                            Name = configurationRoot["SwaggerContactName"].ToString(),
                            Email = configurationRoot["SwaggerContactEmail"].ToString(),
                        }
                    });
            });

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            }).AddJwtBearer("JwtBearer", options => {
                var sec = Encoding.UTF8.GetBytes(configurationRoot["SecretKey"].ToString());

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidAudience = "The name of audience",
                    ValidateIssuer = false,
                    ValidIssuer = "The name of issuer",

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(sec),
                    ValidateLifetime = true,
                };
            });

            services.AddCors();

            services.AddOptions();
            services.Configure<Settings>(configurationRoot);

            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            var ioc = new InjectorContainer();
            services = ioc.GetScope(services);

            services.AddSingleton<IConfiguration>(configurationRoot);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddResponseCompression();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment environment)
        {
            if (environment.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseAuthentication();

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", configurationRoot["SwaggerTitle"].ToString());
            });

            app.UseResponseCompression();
        }
    }
}
