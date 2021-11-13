using balasolu.web.contexts;
using balasolu.web.extensions;
using balasolu.web.models.abstractions;
using balasolu.web.services;
using balasolu.web.services.interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;

namespace balasolu.web
{
    sealed class Startup
    {
        readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public async void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureSameSiteNone();
            var connection = await _configuration.BuildSqlConnectionStringAsync();
            var discordOptions = await _configuration.BuildDiscordOptionsAsync();
            services.AddDbContextPool<DefaultContext>(x =>
            {
                x.UseMySql(connection, ServerVersion.AutoDetect(connection));
                x.EnableSensitiveDataLogging();
                x.EnableDetailedErrors();
            });
            services.AddDbContextFactory<DefaultContext>(x =>
            {
                x.UseMySql(connection, ServerVersion.AutoDetect(connection));
                x.EnableSensitiveDataLogging();
                x.EnableDetailedErrors();
            });
            services.AddIdentity<User, Role>(x =>
            {
                x.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<DefaultContext>()
            .AddDefaultTokenProviders();
            services.AddAuthentication()
            .AddCookie()
            .AddDiscord(x =>
            {
                x.ClientId = discordOptions.ClientId?.Trim();
                x.ClientSecret = discordOptions.ClientSecret?.Trim();
                x.Scope.Add("email");
                x.SaveTokens = true;
            });
            services.AddRazorPages(x =>
            {
                x.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute());
            });
            services.AddServerSideBlazor();
            services.AddHttpContextAccessor();
            services.AddSingleton(new HttpClient());
            services.AddSingleton(discordOptions);
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IPostService, PostService>();
            await services.AddQuartzAsync();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            //#if DEBUG
            app.UseDeveloperExceptionPage();
            //#else
            //                        app.UseExceptionHandler("/Error");
            //#endif
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseCookiePolicy(new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Lax
            });

            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
