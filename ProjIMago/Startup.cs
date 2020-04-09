using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjIMago.Data;
using ProjIMago.Infraestructure;
using ProjIMago.Services;

namespace ProjIMago
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }
		readonly string PermissaoEntreOrigens = "_PermissaoEntreOrigens";

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			string connection = "Data Source=(localdb)\\MSSQLLocalDB;" +
				"Initial Catalog=ProjImago;Integrated Security=True;Connect Timeout=30;" +
				"Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

			services.AddDbContext<IMagoContext>(op => op.UseSqlServer(connection));

			services.AddTransient<IUnityOfWork, UnityOfWork>();
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

			services.AddCors(op => { 
				op.AddPolicy(PermissaoEntreOrigens, builder => { builder.WithOrigins("*").WithMethods("*").WithHeaders("*"); }); });

		}


		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{

			app.UseStaticFiles(new StaticFileOptions
			{
				FileProvider = new PhysicalFileProvider(
				Path.Combine(Directory.GetCurrentDirectory(), "arch")),
				RequestPath = "/arch"
			});

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}


			app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

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
