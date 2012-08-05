// Copyright 2012, Ben Aston (ben@bj.ma).
// 
// This file is part of NOpenInterface.
// 
// NOpenInterface is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// NOpenInterface is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with NOpenInterface. If not, see <http://www.gnu.org/licenses/>.

namespace NOpenInterface.Implementation.DotNet.Http
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Web.Mvc;
	using Extensions;
	using NOpenInterface.Http;

	/// <summary>
	/// 	Default implementation of IRestfulResource for use in ASP.NET MVC.
	/// </summary>
	public abstract class RestfulResourceController : Controller
	{
		private IEnumerable<KeyValuePair<string, ResponseFactoryDelegate<ActionResult>>> _responseFactories = new List<KeyValuePair<string, ResponseFactoryDelegate<ActionResult>>>();
		private readonly KeyValuePair<string, ResponseFactoryDelegate<ActionResult>>[] _allResponseFactories;

		public string[] SupportedAcceptHeaders { get; set; }

		protected RestfulResourceController() {
			_allResponseFactories = new [] {
					new KeyValuePair<string, ResponseFactoryDelegate<ActionResult>>("*/*", WildcardResponseFactory),
					new KeyValuePair<string, ResponseFactoryDelegate<ActionResult>>("text/html", TextHtmlResponseFactory),
					new KeyValuePair<string, ResponseFactoryDelegate<ActionResult>>("application/json", ApplicationJsonResponseFactory),
					new KeyValuePair<string, ResponseFactoryDelegate<ActionResult>>("text/xml", TextXmlResponseFactory),
				};
			_responseFactories = _allResponseFactories.Where(f => SupportedAcceptHeaders.Contains(f.Key));
		}

		protected ResponseFactoryDelegate<ActionResult> GetResponseFactory(HttpRequestBase httpRequest) {
			if(httpRequest.AcceptTypes == null) {
				return InvalidRequestResponseFactory;
			}

				foreach (var acceptType in httpRequest.AcceptTypes) {
					if (_responseFactories.Any(f => f.Key == acceptType)) {
						return _responseFactories.First(f => f.Key == acceptType).Value;
					}
				}
			
				return NotImplementedResponseFactory;
		}

		protected ActionResult WildcardResponseFactory(dynamic responseModel)
		{
			return new JsonResult { Data = responseModel, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
		}

		protected ActionResult ApplicationJsonResponseFactory(dynamic responseModel)
		{
			return new JsonResult { Data = responseModel, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
		}

		protected ActionResult TextHtmlResponseFactory(dynamic responseModel)
		{
			dynamic responseModelExpando = ((object)responseModel).ToExpando();

			return PartialView(responseModelExpando.ViewName, responseModelExpando); //the ToExpando because members of anonymous types are internal
		}
		
		protected ActionResult TextXmlResponseFactory(dynamic responseModel)
		{
			return new XmlResult(((object)responseModel).ToXml());
		}

		protected ActionResult NotImplementedResponseFactory(dynamic requestArgs)
		{
			return new HttpStatusCodeResult(501); //not implemented
		}

		protected ActionResult InvalidRequestResponseFactory(dynamic requestArgs)
		{
			return new HttpStatusCodeResult(400); //bad request
		}
	}
}