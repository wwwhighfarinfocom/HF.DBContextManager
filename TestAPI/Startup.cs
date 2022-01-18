using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HF.DBContextManager;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace TestAPI
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TestAPI", Version = "v1" });
            });


            //var connets = Configuration.GetSection("AppSetting").GetChildren();

            //var dbDic = new Dictionary<string, DapperClient>();
            //foreach (var item in connets)
            //{
            //    string name = item.GetSection("Name").Value;
            //    string type = item.GetSection("DbType").Value;
            //    string constr = item.GetSection("ConnectionString").Value;

            //    ConnectionConfig conf = new ConnectionConfig();

            //    conf.ConnectionString = constr;
            //    switch (type.ToLower())
            //    {
            //        case "mysql":
            //            conf.DbType = DBStoreType.MySql;
            //            break;
            //        case "oracle":
            //            conf.DbType = DBStoreType.Oracle;
            //            break;
            //        case "sqlite":
            //            conf.DbType = DBStoreType.Sqlite;
            //            break;
            //        case "sqlserver":
            //            conf.DbType = DBStoreType.SqlServer;
            //            break;
            //    }
            //    DapperClient client = new DapperClient(conf);
            //    dbDic.Add(name, client);
            //}
            //services.AddClient(dbDic);



            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
