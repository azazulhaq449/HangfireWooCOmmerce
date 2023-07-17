using Microsoft.Owin;
using Owin;
using System;
using System.Configuration;
using Hangfire;
using SyncData.Services;

[assembly: OwinStartup(typeof(SyncData.Startup))]

namespace SyncData
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            GlobalConfiguration.Configuration
                .UseSqlServerStorage(ConfigurationManager.ConnectionStrings["SyncDataDb"].ConnectionString);

            app.UseHangfireDashboard();
            var options = new BackgroundJobServerOptions { WorkerCount = Environment.ProcessorCount *  1};
            app.UseHangfireServer(options);
            RecurringJob.AddOrUpdate("WooCommerceScheduleJob",  () =>  ScheduleService.WooCommerceSchedule(), ConfigurationManager.AppSettings["WooCommerceCronExpression"]);
            RecurringJob.AddOrUpdate("CjDropShippingScheduleJob", () => ScheduleService.CjDropShippingSchedule(), ConfigurationManager.AppSettings["CjDropShippingCronExpression"]);

        }
    }
}
