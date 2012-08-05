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

namespace NOpenInterface.Implementation.AspDotNet.Http
{
	using System.Collections.Generic;
	using System.Web;
	using System.Web.Mvc;
	using NOpenInterface.Http;

	/// <summary>
	/// 	Default implementation of IRestfulResource for use in ASP.NET MVC.
	/// </summary>
	public abstract class RestfulResourceController<TResource> : Controller, IRestfulResource<TResource, ActionResult>
	{
		/// <summary>
		/// 	Maps MIME content-types to functions to generate the response.
		/// </summary>
		public IDictionary<string, ResponseFactoryDelegate<ActionResult>> ResponseFactories { get; private set; }

		protected RestfulResourceController() {
			ResponseFactories = new Dictionary<string, ResponseFactoryDelegate<ActionResult>> {
				{"application/json", NotImplementedResponseFactory},
				//example
			};
		}

		[HttpGet]
		public ActionResult Get() {
			return GetResponseFactory(Request)();
		}

		[HttpGet]
		public ActionResult Get(string resourceId) {
			return GetResponseFactory(Request)(new {Id = resourceId});
		}

		[HttpPut]
		public ActionResult Put(dynamic dto) {
			return GetResponseFactory(Request)(new {Dto = dto});
		}

		[HttpPost]
		public ActionResult Post(dynamic dto) {
			return GetResponseFactory(Request)(new {Dto = dto});
		}

		[HttpHead]
		public ActionResult Head() {
			return GetResponseFactory(Request)();
		}

		[HttpHead]
		public ActionResult Head(dynamic dto) {
			return GetResponseFactory(Request)(new {Dto = dto});
		}

		public ActionResult Head(string resourceId) {
			return GetResponseFactory(Request)(new {Id = resourceId});
		}

		[HttpDelete]
		public ActionResult Delete(string resourceId) {
			return GetResponseFactory(Request)(new {Id = resourceId});
		}

		protected ActionResult NotImplementedResponseFactory(dynamic requestArgs) {
			return new HttpStatusCodeResult(501); //not implemented
		}

		private ResponseFactoryDelegate<ActionResult> GetResponseFactory(HttpRequestBase httpRequest) {
			try {
				return ResponseFactories[httpRequest.ContentType];
			} catch (KeyNotFoundException) {
				return NotImplementedResponseFactory;
			}
		}
	}
}