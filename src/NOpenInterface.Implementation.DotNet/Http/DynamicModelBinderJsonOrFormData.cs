namespace NOpenInterface.Implementation.DotNet.Http
{
	using System;
	using System.Collections.Generic;
	using System.Dynamic;
	using System.IO;
	using System.Web;
	using System.Web.Mvc;
	using Newtonsoft.Json;

	public class DynamicModelBinderJsonOrFormData : DefaultModelBinder
	{
		protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
		{
			dynamic model = new ExpandoObject();

			if(HttpContext.Current.Request.ContentType == "application/json") {
				HttpContext.Current.Request.InputStream.Position = 0;
				var sr = new StreamReader(HttpContext.Current.Request.InputStream);
				var content = sr.ReadToEnd();
				model = JsonConvert.DeserializeObject<ExpandoObject>(content);
			}
			else if (HttpContext.Current.Request.ContentType == "application/x-www-form-urlencoded" || HttpContext.Current.Request.ContentType == "multipart/form-data")
			{ //try forms encoded
				foreach (var key in HttpContext.Current.Request.Form.AllKeys) {
					((IDictionary<String, Object>) model).Add(key, HttpContext.Current.Request.Form.Get(key));
				}
			}

			return model;
		}
	}
}