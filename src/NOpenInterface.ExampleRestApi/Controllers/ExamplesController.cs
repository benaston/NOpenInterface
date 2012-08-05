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

namespace NOpenInterface.ExampleRestApi.Controllers
{
	using System.Web.Mvc;
	using Implementation.DotNet.Http;

	public class ExamplesController : RestfulResourceController
	{
		public ExamplesController() {
			SupportedAcceptHeaders = new [] { "*/*", "text/html", "text/xml", "application/json", };
		}

		[HttpGet]
		public virtual ActionResult Get(string id = null)
		{
			if(id == null) {
				return GetResponseFactory(Request)(new { ViewName = "View2", Models = new dynamic[] { new { Field1 = "a" }, new { Field1 = "b" } } }); //simulates returning a list when id not specified
			}
			
			return GetResponseFactory(Request)(new { Id = id, ViewName = "View1" });
		}

		[HttpPut]
		public virtual ActionResult Put(dynamic dto)
		{
			return GetResponseFactory(Request)(new { Id = dto.Id });
		}

		[ActionName("PostWithId"), HttpPost]
		public virtual ActionResult Post(string id)
		{
			return new HttpStatusCodeResult(200);
		}

		[HttpPost]
		public virtual ActionResult Post(dynamic dto)
		{
			return new HttpStatusCodeResult(200);
		}
	}
}