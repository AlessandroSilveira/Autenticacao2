using System;
using System.Net;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Application2.Domain.Interfaces.Repository;
using Application2.Domain.Interfaces.Service;
using Application2.Domain.Services;
using Autenticacao2.Application;
using Autenticacao2.Application.Interfaces;
using Autenticacao2.Domain.Services;
using Autenticacao2.Infra.Data.Interfaces;
using Autenticacao2.Infra.Data.Repository;
using Autenticacao2.Infra.Data.UoW;
using Autenticacao2.Infra.Security;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;

namespace Autenticacao2
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			var config = new HttpConfiguration();
			ConfigureWebApi(config);
			ConfigureOAuth(app);
			app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
			app.UseWebApi(config);
			app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(config);
		}
		private static StandardKernel CreateKernel()
		{
			var kernel = new StandardKernel();
			kernel.Load(Assembly.GetExecutingAssembly());
			RegisterServices(kernel);
			GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
			return kernel;
		}

		private static void RegisterServices(StandardKernel kernel)
		{
			kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));
			kernel.Bind<IUsuarioAppService>().To<UsuarioAppService>();
			kernel.Bind<IUsuarioService>().To<UsuarioService>().InTransientScope();
			kernel.Bind<IUsuarioRepository>().To<UsuarioRepository>();
			kernel.Bind<ITelefoneAppService>().To<TelefoneAppService>();
			kernel.Bind<ITelefoneService>().To<TelefoneService>();
			kernel.Bind<ITelefoneRepository>().To<TelefoneRepository>();
			kernel.Bind<ICriptografia>().To<Criptografia>();
			kernel.Bind<IJwt>().To<Jwt>().InRequestScope();
			kernel.Bind<IConfiguration>().To<Configuration>();
			kernel.Bind<ICustomMessage>().To<CustomMessage>();
			kernel.Bind<IEmailBuilder>().To<EmailBuilder>();
			kernel.Bind<IEmailSender>().To<EnviaEmailBuilder>();
			kernel.Bind<IGerenciadorEmail>().To<GerenciadorEmail>();
			kernel.Bind<IHttpActionResult>().To<CustomMessage>();
			kernel.Bind<IEnviadorEmail>().To<EnviardorDeEmail>();
			kernel.Bind<IRestClientDomain>().To<RestClientDomain>();
			kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
			kernel.Bind<HttpStatusCode>();
			kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
			kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
		}
		
		public static void ConfigureWebApi(HttpConfiguration config)
		{
			config.MapHttpAttributeRoutes();
			var formatters = config.Formatters;
			formatters.Clear();
			formatters.Add(new JsonMediaTypeFormatter());
			var jsonFormatter = formatters.JsonFormatter;
			var settings = jsonFormatter.SerializerSettings;
			settings.Formatting = Formatting.Indented;
			settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
		}

		public void ConfigureOAuth(IAppBuilder app)
		{
			OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
			{
				AllowInsecureHttp = true,
				TokenEndpointPath = new PathString("/api/security/token"),
				AccessTokenExpireTimeSpan = TimeSpan.FromHours(2),
				Provider = new AuthorizationServerProvider()
			};

			app.UseOAuthAuthorizationServer(OAuthServerOptions);
			app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
		}
	}
}