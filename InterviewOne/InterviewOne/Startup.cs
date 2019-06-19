using AutoMapper;
using Domain;
using InterviewOne.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewOne
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "GemSto API",
                    Description = "GemSto - The Gem Merchant",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "GemSto"/*, Email = "contact@talkingdotnet.com", Url = "www.talkingdotnet.com"*/ }
                });

                var security = new Dictionary<string, IEnumerable<string>>
                                {
                                    {"Bearer", new string[] { }},
                                };

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(security);
            });


            services.AddAuthentication()
              .AddJwtBearer(cfg =>
              {
                  cfg.TokenValidationParameters = new TokenValidationParameters()
                  {
                      ValidIssuer = Configuration["Tokens:Issuer"],
                      ValidAudience = Configuration["Tokens:Audience"],
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))
                  };
              });

            #region dbcontext

            services.AddDbContext<MyContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("MyContext")));

            #endregion

            #region AutoMapper  

            // services.AddAutoMapper();

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<Automapper>();
            });

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new Automapper());
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            #endregion

            #region service injector

            ServiceInjector.InjectServices(services);

            #endregion


          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                //c.InjectJavascript("/swagger/ui/on-complete.js");
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GemSto API V1");
            });

            app.UseCors(builder => builder.WithOrigins("http://localhost:4200")/*.AllowAnyOrigin()*/.AllowAnyHeader().AllowAnyMethod());

            app.UseMvc();
        }
    }
}
