using balasolu.web.jobs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System.Threading.Tasks;

namespace balasolu.web.extensions
{
    static class ServiceCollectionExtensions
    {
        static bool SupportsSameSiteNone(string userAgent)
        {
            // Cover all iOS based browsers here. This includes:
            //   - Safari on iOS 12 for iPhone, iPod Touch, iPad
            //   - WkWebview on iOS 12 for iPhone, iPod Touch, iPad
            //   - Chrome on iOS 12 for iPhone, iPod Touch, iPad
            // All of which are broken by SameSite=None, because they use the
            // iOS networking stack.
            // Notes from Thinktecture:
            // Regarding https://caniuse.com/#search=samesite iOS versions lower
            // than 12 are not supporting SameSite at all. Starting with version 13
            // unknown values are NOT treated as strict anymore. Therefore we only
            // need to check version 12.
            if (userAgent.Contains("CPU iPhone OS 12") || userAgent.Contains("iPad; CPU OS 12"))
                return false;

            // Cover Mac OS X based browsers that use the Mac OS networking stack.
            // This includes:
            //   - Safari on Mac OS X.
            // This does not include:
            //   - Chrome on Mac OS X
            // because they do not use the Mac OS networking stack.
            // Notes from Thinktecture: 
            // Regarding https://caniuse.com/#search=samesite MacOS X versions lower
            // than 10.14 are not supporting SameSite at all. Starting with version
            // 10.15 unknown values are NOT treated as strict anymore. Therefore we
            // only need to check version 10.14.
            if (userAgent.Contains("Safari") &&
                userAgent.Contains("Macintosh; Intel Mac OS X 10_14") &&
                userAgent.Contains("Version/"))
                return false;

            // Cover Chrome 50-69, because some versions are broken by SameSite=None
            // and none in this range require it.
            // Note: this covers some pre-Chromium Edge versions,
            // but pre-Chromium Edge does not require SameSite=None.
            // Notes from Thinktecture:
            // We can not validate this assumption, but we trust Microsofts
            // evaluation. And overall not sending a SameSite value equals to the same
            // behavior as SameSite=None for these old versions anyways.
            if (userAgent.Contains("Chrome/5") || userAgent.Contains("Chrome/6"))
                return false;

            return true;
        }

        static void CheckSameSite(HttpContext httpContext, CookieOptions options)
        {
            if (options.SameSite == SameSiteMode.None)
            {
                var userAgent = httpContext.Request.Headers["User-Agent"].ToString();
                if (!SupportsSameSiteNone(userAgent))
                    options.SameSite = SameSiteMode.Unspecified;
            }
        }

        public static IServiceCollection ConfigureSameSiteNone(this IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.Unspecified;
                options.OnAppendCookie = cookieContext =>
                    CheckSameSite(cookieContext.Context, cookieContext.CookieOptions);
                options.OnDeleteCookie = cookieContext =>
                    CheckSameSite(cookieContext.Context, cookieContext.CookieOptions);
            });
            return services;
        }

        /// <summary>
        /// adds quartz and related scheduled jobs to the service collection
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static Task AddQuartzAsync(this IServiceCollection services)
        {
            services.AddQuartz(async x =>
            {
                x.UseMicrosoftDependencyInjectionJobFactory();
                // schedule jobs here
                await x.ScheduleItemsJobAsync(ref services);
            });

            // graceful shutdown
            services.AddQuartzHostedService(x =>
            {
                x.WaitForJobsToComplete = true;
            });
            return Task.CompletedTask;
        }

        /// <summary>
        /// registers and schedules a feedly job with the service collection
        /// </summary>
        /// <param name="configurator"></param>
        /// <param name="services"></param>
        /// <returns></returns>
        static Task<IServiceCollectionQuartzConfigurator> ScheduleItemsJobAsync(this IServiceCollectionQuartzConfigurator configurator, ref IServiceCollection services)
        {
            return Task.FromResult(configurator.ScheduleJob<ItemsJob>(x =>
            {
                x.WithIdentity(nameof(ItemsJob))
                .StartNow()
                .WithDescription("items job");
            }));
        }

        ///// <summary>
        ///// registers and schedules a content collection job with the service collection
        ///// </summary>
        ///// <param name="configurator"></param>
        ///// <param name="services"></param>
        ///// <returns></returns>
        //static Task<IServiceCollectionQuartzConfigurator> ScheduleContentCollectionJobAsync(this IServiceCollectionQuartzConfigurator configurator, ref IServiceCollection services)
        //{
        //    services.AddTransient<ContentCollectionJob>();
        //    return Task.FromResult(configurator.ScheduleJob<ContentCollectionJob>(x =>
        //    {
        //        x.WithIdentity(nameof(ContentCollectionJob))
        //        .StartNow()
        //        .WithCronSchedule("0 */30 * * * ?")
        //        .WithDescription("content collections job");
        //    }));
        //}
    }
}
