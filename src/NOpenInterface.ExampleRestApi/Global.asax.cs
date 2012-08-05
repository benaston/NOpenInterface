namespace NOpenInterface.ExampleRestApi
{
	using Implementation.DotNet.Http;
	using System.Web.Mvc;
	using System.Web.Routing;

	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute("Query", "examples/query/", new { controller = "Examples", action = "Query" }, new { isValid = new HttpPostRouteConstraint() });
			routes.MapRoute("ExamplesGet", "examples/{id}", new { controller = "Examples", action = "Get", id = UrlParameter.Optional }, new { isValid = new HttpGetRouteConstraint() });
			routes.MapRoute("ExamplesPostWithId", "examples/{id}", new { controller = "Examples", action = "PostWithId" }, new { isValid = new HttpPostRouteConstraint() });
			routes.MapRoute("ExamplesPost", "examples/", new { controller = "Examples", action = "Post" }, new { isValid = new HttpPostRouteConstraint() });
			routes.MapRoute("ExamplesPut", "examples/", new { controller = "Examples", action = "Put" }, new { isValid = new HttpPutRouteConstraint() });
			
		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);
			ModelBinders.Binders.Add(typeof(object), new DynamicModelBinderJsonOrFormData()); //important
		}
	}
}