namespace NOpenInterface.Implementation.DotNet.Http
{
	using System.Web;
	using System.Web.Routing;

	public class HttpPostRouteConstraint : IRouteConstraint {
		public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection) {
			return httpContext.Request.RequestType == "POST";
		}
	}
}